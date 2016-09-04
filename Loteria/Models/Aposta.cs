namespace Loteria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aposta")]
    public partial class Aposta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aposta()
        {
            Acerto = new HashSet<Acerto>();
            ItemAposta = new HashSet<ItemAposta>();
        }

        public int Id { get; set; }

        public int IdApostador { get; set; }

        public int IdSorteio { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DhAposta { get; set; }

        public int? IdTipoAcerto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acerto> Acerto { get; set; }

        public virtual Apostador Apostador { get; set; }

        public virtual Sorteio Sorteio { get; set; }

        public virtual TipoAcerto TipoAcerto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemAposta> ItemAposta { get; set; }
    }
}
