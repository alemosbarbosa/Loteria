using Loteria.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Models
{
    public class LoteriaDAL
    {
        public const int KStatusSorteioAberto = 1;
        public const int KStatusSorteioFechado = 2;
        public const int KStatusSorteioProcessado = 3;

        private LoteriaEntity entity;

        public LoteriaDAL()
        {
            entity = new LoteriaEntity();
        }

        public Sorteio CriaSorteio(int idTipo)
        {
            var tipoSorteio = entity.TipoSorteio.Where(x => x.Id == idTipo).SingleOrDefault();
            if (tipoSorteio == null)
            {
                throw new Exception("Modalidade de jogo não disponibilizada");
            }
            var numSorteioCorrente = tipoSorteio.NumSorteioCorrente;
            var sorteioCorrente = entity.Sorteio.Where(x => x.IdTipo == idTipo && x.NumSorteio == numSorteioCorrente).SingleOrDefault();
            if (sorteioCorrente != null && sorteioCorrente.CodStatus == KStatusSorteioAberto)
            {
                throw new Exception("Sorteio corrente ainda não foi finalizado");
            }
            numSorteioCorrente = ++tipoSorteio.NumSorteioCorrente;
            var sorteio = new Sorteio() { IdTipo = idTipo, NumSorteio = numSorteioCorrente, CodStatus = KStatusSorteioAberto, DhCriacao = DateTime.Now };
            entity.Sorteio.Add(sorteio);
            entity.SaveChanges();
            return sorteio;
        }

        public Sorteio FechaSorteio(int idSorteio)
        {
            int[] numeros = { };
            var sorteio = entity.Sorteio.Where(x => x.Id == idSorteio).SingleOrDefault();
            if (sorteio == null)
            {
                throw new Exception("Sorteio não encontrado");
            }
            if (sorteio.CodStatus == KStatusSorteioFechado)
            {
                throw new Exception("Sorteio já fechado");
            }
            if (sorteio.CodStatus == KStatusSorteioProcessado)
            {
                throw new Exception("Sorteio já processado");
            }
            var tipoSorteio = sorteio.TipoSorteio;
            numeros = SorteiaNumeros(tipoSorteio);
            return FechaSorteio(idSorteio, numeros);
        }

        private static int[] SorteiaNumeros(TipoSorteio tipoSorteio)
        {
            int[] numeros;
            var minValor = tipoSorteio.MinValorNumero;
            var maxValor = tipoSorteio.MaxValorNumero;
            if (maxValor < minValor)  // Não é para acontecer
            {
                var msg = String.Format("Inconsistência da configuração de valor mínimo e máximo do Tipo de Sorteio de Id {0}", tipoSorteio.Id);
                throw new Exception(msg);
            }
            if (maxValor - minValor < tipoSorteio.MinNumerosPorJogo)  // Não é para acontecer
            {
                var msg = String.Format("Inconsistência da configuração na quantidade de números por Aposta para o Tipo de Sorteio de Id {0}", tipoSorteio.Id);
                throw new Exception(msg);
            }
            var listaNumeros = new List<int>();
            maxValor++;  // Ajuste para usar na chamada do método Next de Random
            var random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < tipoSorteio.MinNumerosPorJogo;)
            {
                var num = random.Next(minValor, maxValor);
                if (!listaNumeros.Any(x => x == num))
                {
                    listaNumeros.Add(num);
                    i++;
                }
            }
            numeros = listaNumeros.ToArray();
            return numeros;
        }

        public Sorteio FechaSorteio(int idSorteio, int[] numeros)
        {
            var sorteio = entity.Sorteio.Where(x => x.Id == idSorteio).SingleOrDefault();
            if (sorteio == null)
            {
                throw new Exception("Sorteio não encontrado");
            }
            if (sorteio.CodStatus == KStatusSorteioProcessado)
            {
                throw new Exception("Sorteio já processado");
            }
            var tipoSorteio = sorteio.TipoSorteio;
            var qtdNumeros = numeros.Length;
            // Considera-se que a quantindade mínima de número é a quantidade de números do sorteio
            if (qtdNumeros != tipoSorteio.MinNumerosPorJogo)
            {
                throw new Exception("Quantidade de números diferente do esperado");
            }
            var valoresInferiores = numeros.Where(x => x < tipoSorteio.MinValorNumero);
            if (valoresInferiores.Count() > 0)
            {
                var valorInferior = valoresInferiores.First();
                var msg = String.Format("Valor de número {0} inferior ao permitido de {1}", valorInferior, tipoSorteio.MinValorNumero);
                throw new Exception(msg);
            }
            var valoresSuperiores = numeros.Where(x => x > tipoSorteio.MaxValorNumero);
            if (valoresSuperiores.Count() > 0)
            {
                var valorInferior = valoresInferiores.First();
                var msg = String.Format("Valor de número {0} superior ao permitido de {1}", valorInferior, tipoSorteio.MaxValorNumero);
                throw new Exception(msg);
            }
            var numerosOrdenados = numeros.OrderBy(x => x).ToArray();
            for (int i = 0; i < qtdNumeros - 1; i++)
            {
                if (numerosOrdenados[i] == numerosOrdenados[i + 1])
                {
                    var msg = String.Format("Número {0} está repetido", numerosOrdenados[i]);
                    throw new Exception(msg);
                }
            }
            var itens = numerosOrdenados.Select(x => new ItemSorteio() { Numero = x }).ToArray();
            sorteio.ItemSorteio = itens;
            sorteio.CodStatus = KStatusSorteioFechado;
            entity.SaveChanges();
            return sorteio;
        }

        public Sorteio ProcessaSorteio(int idSorteio)
        {
            var sorteio = entity.Sorteio.Where(x => x.Id == idSorteio).SingleOrDefault();
            if (sorteio == null)
            {
                throw new Exception("Sorteio não encontrado");
            }
            if (sorteio.CodStatus == KStatusSorteioAberto)
            {
                throw new Exception("Sorteio ainda aberto");
            }
            if (sorteio.CodStatus == KStatusSorteioProcessado)
            {
                throw new Exception("Sorteio já processado");
            }
            var tiposAcertosSorteio = entity.TipoAcerto.Where(x => x.IdTipo == sorteio.IdTipo);
            var apostasSorteio = entity.Aposta.Where(x => x.IdSorteio == idSorteio);
            foreach (var aposta in apostasSorteio)
            {
                var numAcertos = aposta.ItemAposta.Where(x => sorteio.ItemSorteio.Any(y => x.Numero == y.Numero)).Count();
                var tipoAcerto = tiposAcertosSorteio.Where(x => x.QtdNumerosAcertados == numAcertos).SingleOrDefault();
                if (tipoAcerto != null)
                {
                    aposta.IdTipoAcerto = tipoAcerto.Id;
                    var newAcerto = new Acerto() { IdAposta = aposta.Id, IdSorteio = idSorteio };
                    entity.Acerto.Add(newAcerto);
                }
            }
            sorteio.CodStatus = KStatusSorteioProcessado;
            entity.SaveChanges();
            return sorteio;
        }

        public Apostador CriaApostador(string nome)
        {
            var apostador = entity.Apostador.Where(x => x.Nome == nome).SingleOrDefault();
            if (apostador != null)
            {
                var msg = String.Format("Apostador '{0}' já cadastrado", nome);
                throw new Exception(msg);
            }
            var newApostador = new Apostador() { Nome = nome, DhCadastro = DateTime.Now };
            entity.Apostador.Add(newApostador);
            entity.SaveChanges();
            return newApostador;
        }

        public Aposta CriaAposta(int idApostador, int idSorteio)
        {
            int[] numeros;
            var apostador = entity.Apostador.Where(x => x.Id == idApostador).SingleOrDefault();
            if (apostador == null)
            {
                throw new Exception("Apostador não encontrado");
            }
            var sorteio = entity.Sorteio.Where(x => x.Id == idSorteio).SingleOrDefault();
            if (sorteio == null)
            {
                throw new Exception("Sorteio não encontrado");
            }
            if (sorteio.CodStatus != KStatusSorteioAberto)
            {
                throw new Exception("Sorteio já finalizado");
            }
            numeros = SorteiaNumeros(sorteio.TipoSorteio);
            return CriaAposta(idApostador, idSorteio, numeros);
        }

        public Aposta CriaAposta(int idApostador, int idSorteio, int[] numeros)
        {
            var apostador = entity.Apostador.Where(x => x.Id == idApostador).SingleOrDefault();
            if (apostador == null)
            {
                throw new Exception("Apostador não encontrado");
            }
            var sorteio = entity.Sorteio.Where(x => x.Id == idSorteio).SingleOrDefault();
            if (sorteio == null)
            {
                throw new Exception("Sorteio não encontrado");
            }
            if (sorteio.CodStatus != KStatusSorteioAberto)
            {
                throw new Exception("Sorteio já finalizado");
            }
            var tipoSorteio = sorteio.TipoSorteio;
            var qtdNumeros = numeros.Length;
            if (qtdNumeros < tipoSorteio.MinNumerosPorJogo)
            {
                throw new Exception("Quantidade de números inferior ao permitido");
            }
            if (qtdNumeros > tipoSorteio.MaxNumerosPorJogo)
            {
                throw new Exception("Quantidade de números superior ao permitido");
            }
            var valoresInferiores = numeros.Where(x => x < tipoSorteio.MinValorNumero);
            if (valoresInferiores.Count() > 0)
            {
                var valorInferior = valoresInferiores.First();
                var msg = String.Format("Valor de número {0} inferior ao permitido de {1}", valorInferior, tipoSorteio.MinValorNumero);
                throw new Exception(msg);
            }
            var valoresSuperiores = numeros.Where(x => x > tipoSorteio.MaxValorNumero);
            if (valoresSuperiores.Count() > 0)
            {
                var valorInferior = valoresInferiores.First();
                var msg = String.Format("Valor de número {0} superior ao permitido de {1}", valorInferior, tipoSorteio.MaxValorNumero);
                throw new Exception(msg);
            }
            var numerosOrdenados = numeros.OrderBy(x => x).ToArray();
            for (int i = 0; i < qtdNumeros - 1; i++)
            {
                if (numerosOrdenados[i] == numerosOrdenados[i + 1])
                {
                    var msg = String.Format("Número {0} está repetido", numerosOrdenados[i]);
                    throw new Exception(msg);
                }
            }
            var newAposta = new Aposta()
            {
                IdApostador = idApostador,
                IdSorteio = idSorteio,
                DhAposta = DateTime.Now
            };
            var itens = numeros.Select(x => new ItemAposta() { Numero = x }).ToArray();
            newAposta.ItemAposta = itens;
            entity.Aposta.Add(newAposta);
            entity.SaveChanges();
            return newAposta;
        }

        public IEnumerable<AcertoDTO> BuscaAcertos(int idSorteio)
        {
            IEnumerable<AcertoDTO> ret;
            var acertos = entity.Acerto.Where(p => p.IdSorteio == idSorteio).ToArray();
            ret = acertos.Select(x =>
            {
                var y = (AcertoDTO)x;
                y.NomeAcertador = x.Aposta.Apostador.Nome;
                y.DescricaoTipoAcerto = x.Aposta.TipoAcerto.Descricao;
                return y;
            }).ToArray();
            return ret;
        }

    }
}