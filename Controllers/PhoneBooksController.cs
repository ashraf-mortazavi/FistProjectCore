using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static PhoneBook.Models.PhoneBooks;
using Newtonsoft.Json;


namespace PhoneBook.Controllers;


public class PhoneBooksController : Controller
{

    private readonly IPhonBook iphonebook;
    private List<PhoneBooks> list;

    public PhoneBooksController(IPhonBook _iphonbook)
    {
        iphonebook = _iphonbook;
    }

    public IActionResult Index(PhoneBooks phonebookparameter)
    {

        if (phonebookparameter.Id == null && phonebookparameter.Name == null && phonebookparameter.PhoneNumber == null)
        {
            list = iphonebook.GetAllPhoneBooksItems();

        }

        else if (phonebookparameter.Id == null && phonebookparameter.Name != null && 
        phonebookparameter.PhoneNumber != null)
        {
            list = iphonebook.GetAllPhoneBooksItems();
             phonebookparameter.Id = list.Select(x =>x.Id).Last();
             list.Add(phonebookparameter);
        }

        else
        {
            var phonbook = iphonebook.GetAllPhoneBooksItems().Where(s => s.Id == phonebookparameter.Id).FirstOrDefault();
            if (phonbook.Name == phonebookparameter.Name && phonbook.PhoneNumber == phonebookparameter.PhoneNumber)
            {
                list = iphonebook.GetAllPhoneBooksItems();
                var bol = list.RemoveAll(x => x.Id == phonbook.Id);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        list = iphonebook.GetAllPhoneBooksItems();
                        var bol = list.RemoveAll(x => x.Id == phonbook.Id);
                        phonbook.Name = phonebookparameter.Name;
                        phonbook.PhoneNumber = phonebookparameter.PhoneNumber;
                        list.Add(phonbook);

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                }
            }
        }
        return View(list);

        //if (TempData["Friend"] != null) 
        //{
        //var friend1 = JsonConvert.DeserializeObject<Friend>((string)TempData["Friend"]);
        //}
        //TempData.Keep("Friend"); 

    }
    public IActionResult EditOrAdd(int? Id, string? Name, string? PhoneNumber)
    {
        ViewBag.PageName = Id == null ? "CreatePhoneBook" : "EditPhoneBook";
        ViewBag.IsEdit = Id == null ? false : true;
        if (Id == null)
        {
            return View();
        }
        else
        {
            var phonebookdetail = iphonebook.GetAllPhoneBooksItems().Where(s => s.Id == Id).FirstOrDefault();
            phonebookdetail.Name = Name;
            phonebookdetail.PhoneNumber = PhoneNumber;
            if (phonebookdetail == null)
            {
                return NotFound();
            }
            return View(phonebookdetail);
        }


    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditOrAdd(int id, [Bind("Id,Name,PhoneNumber")] PhoneBooks phonebook)
    {

        ViewBag.IsEdit = id == null ? false : true;
        if(ModelState.IsValid)
        {

        PhoneBooks newphonebook = new PhoneBooks();
        return RedirectToAction("Index", "PhoneBooks", newphonebook = phonebook);
        
        }
        return View();
      
        //TempData["Friend"] = JsonConvert.SerializeObject(friend);
    }



    public IActionResult Detail(int Id, string Name, string PhoneNumber)
    {
        PhoneBooks phonebook = new PhoneBooks();
        if (Id == null)
        {
            return NotFound();
        }
        phonebook.Name = Name;
        phonebook.PhoneNumber = PhoneNumber;

        return View(phonebook);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
        {

            return NotFound();
        }
        else
        {
            var phoneBook = iphonebook.GetAllPhoneBooksItems().Where(s => s.Id == id).FirstOrDefault();
            return RedirectToAction("Index", "PhoneBooks", phoneBook);
        }




    }

}

