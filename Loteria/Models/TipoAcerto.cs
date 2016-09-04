namespace Loteria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoAcerto")]
    public partial class TipoAcerto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoAcerto()
        {
            Aposta = new HashSet<Aposta>();
        }

        public int Id { get; set; }

        public int IdTipo { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public int QtdNumerosAcertados { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aposta> Aposta { get; set; }

        public virtual TipoSorteio TipoSorteio { get; set; }
    }
}
