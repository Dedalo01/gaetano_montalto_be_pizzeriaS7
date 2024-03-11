namespace pizzeriaS7L.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrdiniArticoli")]
    public partial class OrdiniArticoli
    {
        public int Id { get; set; }

        public int OrdineId { get; set; }

        public int ArticoloId { get; set; }

        public int Quantita { get; set; }

        public virtual Articoli Articoli { get; set; }

        public virtual Ordini Ordini { get; set; }
    }
}
