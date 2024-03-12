namespace pizzeriaS7L.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Articoli")]
    public partial class Articoli
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articoli()
        {
            OrdiniArticoli = new HashSet<OrdiniArticoli>();
        }
        // ricorda di aggiungere key nel caso non funzioni nulla a tutti i model
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Foto { get; set; }

        public decimal Prezzo { get; set; }

        [Required]
        [StringLength(10)]
        public string TempoConsegna { get; set; }

        [Required]
        [StringLength(10)]
        public string Ingredienti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdiniArticoli> OrdiniArticoli { get; set; }
    }
}
