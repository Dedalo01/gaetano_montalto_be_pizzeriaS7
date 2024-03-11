namespace pizzeriaS7L.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordini")]
    public partial class Ordini
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ordini()
        {
            OrdiniArticoli = new HashSet<OrdiniArticoli>();
        }

        public int Id { get; set; }

        public int UtenteId { get; set; }

        [Required]
        public string IndirizzoSpedizione { get; set; }

        [StringLength(1000)]
        public string Nota { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DataOrdine { get; set; }

        [Required]
        [StringLength(10)]
        public string IsCompleto { get; set; }

        public virtual Utenti Utenti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdiniArticoli> OrdiniArticoli { get; set; }
    }
}
