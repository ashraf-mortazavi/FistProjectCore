using Microsoft.AspNetCore.Mvc;
using PhonBook.Services;
using PhoneBook.Models;

namespace PhonBook.Controllers;

    public class PhoneBooksEFController: Controller
    { 
        IPhoneBookServices iphonbookservices;
       

         public PhoneBooksEFController(IPhoneBookServices _iphonbookservices)
         {
            iphonbookservices = _iphonbookservices;
         }

         public IActionResult Index()
         {
            var phonbooklist = iphonbookservices.Read();
            ViewBag.ThisPageTitle = "PhoneBook-List";
            return View(phonbooklist);
         }

        
         public IActionResult Update(int id)
         {
                
             var phonebook  =  iphonbookservices.Detail(id);                           
            return View(phonebook);    
         }

         [HttpPost]
         [ValidateAntiForgeryToken]
         public IActionResult Update(int id, [Bind("Id,Name,PhoneNumber")] PhoneBooks phonebooks )
         {
            if (phonebooks != null)
            {
                iphonbookservices.Update(id, phonebooks);
            }
            return RedirectToAction(nameof(Index));
        
         }
               
         public IActionResult Create()
         {            
                return View();           
         }


         [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult Create( [Bind("Name,PhoneNumber")] PhoneBooks phonebooks)
         {
            if ( phonebooks != null)
            {
                 iphonbookservices.Create(phonebooks);
            }
             return RedirectToAction(nameof(Index));  
         }


         public IActionResult Delete(int id)
         {
            iphonbookservices.Delete(id);
            return RedirectToAction(nameof(Index));
         }
         public IActionResult Detail(int id)
         {
             var phonebook = iphonbookservices.Detail(id);
             return View(phonebook);
         }

    }
