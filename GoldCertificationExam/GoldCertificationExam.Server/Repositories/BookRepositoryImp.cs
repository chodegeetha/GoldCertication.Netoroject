using System.Reflection.Metadata.Ecma335;
using GoldCertificationExam.Server.Contexts;
using GoldCertificationExam.Server.Models;

namespace GoldCertificationExam.Server.Repositories
{
    public class BookRepositoryImp:IBookRepository
    {
        private readonly ApplicationDbContext context;

        public BookRepositoryImp(ApplicationDbContext _context)
        {
            context = _context;

        }

        public async Task<BookingOrder> postorder(BookingOrder order)
        {
            try
            {
                if (order != null)
                {
                    context.BookingOrders.AddAsync(order);
                    await context.SaveChangesAsync();
                    return order;
                }
                else 
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            

        }

        public List<Packages> Getdetails()
        {
            try
            {
                return context.Packages.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Packages> GetPackageById(int id)
        {
            try
            {
                if (id != null)
                {
                    var data = context.Packages.FirstOrDefault(e => e.PackageId == id);
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public  List<Menus> getlistOfMenusByPackId(int Id)
        {
            try
            {
                if (Id != null)
                {
                    var data = context.Menus.Where(e => e.PackageID == Id).ToList();
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
