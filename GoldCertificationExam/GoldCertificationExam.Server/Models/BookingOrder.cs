using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldCertificationExam.Server.Models
{
    public class BookingOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public int Guests { get; set; }

        public String MobileNumber { get; set; }

        public DateTime? Created { get; set; }

        public int PackageId{ get; set; }

        [ForeignKey("PackageId")]

        public Packages Packages { get; set; }
        public string Location { get; set; }

        public string EatingMode { get; set; }

        public String Message { get; set; }
    }
}



    