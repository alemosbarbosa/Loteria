namespace Loteria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Acerto")]
    public partial class Acerto
    {
        public int Id { get; set; }

        public int IdSorteio { get; set; }

        public int IdAposta { get; set; }

        public virtual Aposta Aposta { get; set; }

        public virtual Sorteio Sorteio { get; set; }
    }
}
