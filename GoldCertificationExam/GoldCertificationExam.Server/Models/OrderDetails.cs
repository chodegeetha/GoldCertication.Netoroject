using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoldCertificationExam.Server.Models
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int DishID { get; set; }
        public int Quantity { get; set; }
        public decimal Prices { get; set; }

        [ForeignKey("OrderID")]
        public Orders Order { get; set; }

        [ForeignKey("DishID")]
        public Dishes Dish { get; set; }
    }
}
