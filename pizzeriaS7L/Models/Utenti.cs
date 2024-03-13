namespace pizzeriaS7L.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Utenti")]
    public partial class Utenti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utenti()
        {
            Ordini = new HashSet<Ordini>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Devi inserire l'Username.")]
        [StringLength(100, ErrorMessage = "L'Username può avere massimo 100 caratteri.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Devi inserire la Password.")]
        [StringLength(50, ErrorMessage = "La password può avere massimo 50 caratteri.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Devi inserire l'Email.")]
        [StringLength(200, ErrorMessage = "L'Email può avere massimo 200 caratteri.")]
        public string Email { get; set; }

        public int RuoloId { get; set; } = 2;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordini> Ordini { get; set; }

        public virtual Ruoli Ruoli { get; set; }
    }
}
