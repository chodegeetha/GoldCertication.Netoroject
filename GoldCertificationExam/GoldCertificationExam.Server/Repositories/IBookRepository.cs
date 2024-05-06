using GoldCertificationExam.Server.Contexts;
using GoldCertificationExam.Server.Models;

namespace GoldCertificationExam.Server.Repositories
{
    public interface IBookRepository
    {

        public Task<BookingOrder> postorder(BookingOrder order);
        public Task<Packages> GetPackageById(int id);
        public List<Packages> Getdetails();
        public List<Menus> getlistOfMenusByPackId(int Id);

    }
}
