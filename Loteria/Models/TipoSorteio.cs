namespace Loteria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoSorteio")]
    public partial class TipoSorteio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoSorteio()
        {
            Sorteio = new HashSet<Sorteio>();
            TipoAcerto = new HashSet<TipoAcerto>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        public int NumSorteioCorrente { get; set; }

        public int MinNumerosPorJogo { get; set; }

        public int MaxNumerosPorJogo { get; set; }

        public int MinValorNumero { get; set; }

        public int MaxValorNumero { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sorteio> Sorteio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TipoAcerto> TipoAcerto { get; set; }
    }
}
