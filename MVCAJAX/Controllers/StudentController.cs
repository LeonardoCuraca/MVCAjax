using System.Threading.Tasks;
using System.Web.Mvc;
using MvcAjax.Models;

namespace MvcAjax.Controllers
{
    public class StudentController : Controller
    {
        Proxy.StudentProxy proxy = new Proxy.StudentProxy();
        public ActionResult IndexRazor()
        {
            var response = Task.Run(() => proxy.GetStudentAsync());
            return View(response.Result.listado);
        }

        public JsonResult getStudent(string id)
        {
            var response = Task.Run(() => proxy.GetStudentAsync());
            return Json(response.Result.listado, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult createStudent(StudentModel std)
        {
            var response = Task.Run(() => proxy.InsertAsync(std));
            string message = response.Result.Mensaje;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}