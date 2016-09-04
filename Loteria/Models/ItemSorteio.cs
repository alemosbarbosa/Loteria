namespace Loteria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemSorteio")]
    public partial class ItemSorteio
    {
        public int Id { get; set; }

        public int IdSorteio { get; set; }

        public int Numero { get; set; }

        public virtual Sorteio Sorteio { get; set; }
    }
}
