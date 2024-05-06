using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoldCertificationExam.Server.Models
{
    public class Packages
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<Menus> Menus { get; set; }
    }

}

