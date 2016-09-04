using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loteria.Models;
using System.Linq;

namespace LoteriaTest
{
    [TestClass]
    public class ContextTest
    {
        //[TestMethod]
        //public void TipoSorteioTest()
        //{
        //    var db = new LoteriaEntity();
        //    var apostas = db.Aposta.ToArray();
        //    var tipoSorteio = db.TipoSorteio;
        //    var newTipoSorteio = new TipoSorteio() { Descricao = "Teste" };
        //    tipoSorteio.Add(newTipoSorteio);
        //    db.SaveChanges();
        //    var tipoSorteio2 = db.TipoSorteio.ToArray();
        //}

        [TestMethod]
        public void CriaSorteioTest()
        {
            var dal = new LoteriaDAL();
            var sorteio = dal.CriaSorteio(1);
        }

        [TestMethod]
        public void CriaApostadorTest()
        {
            var dal = new LoteriaDAL();
            var apostador = dal.CriaApostador("Pedro");
        }

        [TestMethod]
        public void CriaApostaTest()
        {
            var dal = new LoteriaDAL();
            var idApostador = 1; // Pedro
            var idSorteio = 6;
            int[] numeros = { 2, 5, 11, 23, 31, 45 };

            var apostador = dal.CriaAposta(idApostador, idSorteio, numeros);
        }

        [TestMethod]
        public void FechaSorteioTest()
        {
            var dal = new LoteriaDAL();
            var idSorteio = 6;

            var sorteio = dal.FechaSorteio(idSorteio);
        }

        [TestMethod]
        public void ProcessaSorteioTest()
        {
            var dal = new LoteriaDAL();
            var idSorteio = 6;

            var sorteio = dal.ProcessaSorteio(idSorteio);
        }
    }
}
