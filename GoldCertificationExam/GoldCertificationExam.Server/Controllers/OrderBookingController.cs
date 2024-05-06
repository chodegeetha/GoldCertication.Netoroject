using GoldCertificationExam.Server.Repositories;
using GoldCertificationExam.Server.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace GoldCertificationExam.Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class OrderBookingController : Controller
    {

        private readonly IBookRepository bookRepository;

        public OrderBookingController(IBookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }
        [HttpPost("Orderdetails")]
        public IActionResult postbooking(BookOrderRequestModel model)
        {
            try
            {
                var mm = BookOrderMapper.maptoorder(model);

                
                if (mm.PackageId == null || mm.PackageId == 0)
                {
                    return BadRequest("Invalid PackageId");
                }

                var order = bookRepository.postorder(mm);
                return Ok(new { suucess = "true", data = order });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet("getallpackages")]
        public IActionResult Getallpackages()
        {
            try
            {
                var details = bookRepository.Getdetails();
                return Ok(new { suucess = "true", data = details });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("getpackagebyId")]
        public IActionResult GetpackagebyId(int Id)
        {
            try
            {
                var details = bookRepository.GetPackageById(Id);
                return Ok(new { suucess = "true", data = details });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("MenuslistByPackageId")]
        public IActionResult GetMenusList(int Id)
        {
            try
            {
                if (Id != null)
                {

                    var data = bookRepository.getlistOfMenusByPackId(Id);
                    return Ok(new { success = "true", result = data });
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
