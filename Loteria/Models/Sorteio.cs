namespace Loteria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sorteio")]
    public partial class Sorteio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sorteio()
        {
            Acerto = new HashSet<Acerto>();
            Aposta = new HashSet<Aposta>();
            ItemSorteio = new HashSet<ItemSorteio>();
        }

        public int Id { get; set; }

        public int IdTipo { get; set; }

        public int NumSorteio { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DhCriacao { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DhSorteio { get; set; }

        public int CodStatus { get; set; }

        public int QtdApostas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acerto> Acerto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aposta> Aposta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemSorteio> ItemSorteio { get; set; }

        public virtual StatusSorteio StatusSorteio { get; set; }

        public virtual TipoSorteio TipoSorteio { get; set; }
    }
}
