using Microsoft.AspNetCore.Mvc;
using TP3.Services;
using TP3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TP3.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMembershipTypeService _MembershipTypeService;

        public CustomerController(ICustomerService _customerService, IMembershipTypeService membershipTypeService)
        {
            this._customerService = _customerService;
            _MembershipTypeService = membershipTypeService;
           
        }
        public IActionResult Index()
        {
            return View(_customerService.GetAll());
        }
        public IActionResult Details(Guid id)
        {
            return View(_customerService.GetById(id));


        }
        public IActionResult Delete(Guid id)
        {
               _customerService.Delete(_customerService.GetById(id));
             return RedirectToAction("Index");


        }

        public IActionResult Edit(Guid id)

        {
           var members = _MembershipTypeService.getAll();
            /*Ici on a utilise le viewBag pour pouvoire creer une liste deroulante dans le form de creation d'un user
             ou il peut choisir le nom du membership au quel il sera abonne (associe) et vu que on peut pas envoyer a une 
            seule vie plusieurs type de model donc on utlise cet methode interdmediare */
            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = members.id.ToString(),
                Value = members.id.ToString() 
            });
            return View(_customerService.GetById(id));


        }
        public IActionResult AddCustomer(uint id) {
            var members = _MembershipTypeService.getAll();
            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = members.id.ToString(),
                Value = members.id.ToString() 
            });
            return View();
        }
        
        public IActionResult CustomerAdd(Customer customer)
        {
            if (!ModelState.IsValid)
             {

                 return RedirectToAction("Index");
             }

             _customerService.Add(customer);
             return RedirectToAction("Index");


        }
        public IActionResult SaveCanchges(Customer customer) {
         _customerService.Update(customer);
            return RedirectToAction("Index");
        }
    }
}