using GoldCertificationExam.Server.Models;
using GoldCertificationExam.Server.RequestModels;

namespace GoldCertificationExam.Server
{
    public class BookOrderMapper
    {

        public static BookingOrder maptoorder(BookOrderRequestModel model)
        {
            BookingOrder bb = new BookingOrder();
            {
                bb.Name=model.Name;
                bb.Email=model.Email;
                bb.Created=DateTime.Now;
                bb.EatingMode = model.EatingMode;
                bb.Guests=model.Guests;
                bb.Location=model.Location;
                bb.Message = model.Message;
                bb.PackageId=model.PackageId;
                bb.MobileNumber = model.MobileNumber;
                return bb;
            }
        }
    } 
}

 