using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports_IICs.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        IContactRepository _repository;
        public HomeController() : this(new EF_ContactRepository()) { }
        public HomeController(IContactRepository repository)
        {
            _repository = repository;
        }
        public ViewResult Index()
        {
            throw new NotImplementedException();
        }
    }
}