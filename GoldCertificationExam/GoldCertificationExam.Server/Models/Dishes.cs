using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoldCertificationExam.Server.Models
{
    public class Dishes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DishID { get; set; }
        public int MenuID { get; set; }
        public string DishName { get; set; }
        public string DishDescription { get; set; }
        public string ServingSize { get; set; }

        [ForeignKey("MenuID")]
        public Menus Menu { get; set; }

        public List<Ingredients> Ingredients { get; set; }

    }
}
