namespace Loteria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemAposta")]
    public partial class ItemAposta
    {
        public long Id { get; set; }

        public int IdAposta { get; set; }

        public int Numero { get; set; }

        public virtual Aposta Aposta { get; set; }
    }
}
