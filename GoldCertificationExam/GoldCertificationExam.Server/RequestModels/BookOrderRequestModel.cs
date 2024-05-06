using GoldCertificationExam.Server.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldCertificationExam.Server.RequestModels
{
    public class BookOrderRequestModel
    {

        public String Name { get; set; }
        public String Email { get; set; }
        public int Guests { get; set; }

        public DateTime? Created { get; set; }

        public String MobileNumber { get; set; }
        public int PackageId { get; set; }

        public string Location { get; set; }

        public string EatingMode { get; set; }

        public String Message { get; set; }
    }
}
