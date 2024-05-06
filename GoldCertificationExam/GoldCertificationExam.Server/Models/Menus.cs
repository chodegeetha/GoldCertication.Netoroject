using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoldCertificationExam.Server.Models
{
    public class Menus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuID { get; set; }
        public int PackageID { get; set; }
        public string MenuName { get; set; }
        public string MenuType { get; set; }

        [ForeignKey("PackageID")]
        public Packages Package { get; set; }
        public List<Dishes> Dishes { get; set; }
    }
}
