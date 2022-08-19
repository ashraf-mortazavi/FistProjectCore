using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FistProjectCore.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FistProjectCore.Controllers;


public class FriendsController : Controller
{

    List<Friend> friends = new List<Friend>
      {
          new Friend {
              Id =1,
              Name = "Ali",
              PhoneNumber= "0946546468",
              Picture = "/images/icons8-image-80.png"
          },
          new Friend {
              Id =2,
              Name ="ashi",
              PhoneNumber ="5542347987",
              Picture = "/images/icons8-men-64.png"
          },
          new Friend {
              Id = 3,
              Name= "mohammad",
              PhoneNumber= "123658947",
              Picture= "/images/icons8-standing-man-100.png"

          },
          new Friend  {
              Id = 4,
              Name= "parvin",
              PhoneNumber = "178563247",
              Picture = "/images/icons8-standing-man-50.png"
          },
          new Friend {
                  Id = 5,
                  Name= "saeed",
                  PhoneNumber = "889511123",
                  Picture = "/images/icons8-men-64.png"
            },
          new Friend {
                 Id= 6,
                 Name="ashi",
                 PhoneNumber = "7102594235",
                 Picture= "/images/icons8-man-with-kiss-50.png"
            },
          new Friend
              {
                  Id = 7,
                  Name="ahmad",
                  PhoneNumber="22359874",
                  Picture = "/images/icons8-listening-to-music-on-headphones-48.png"
              },
          new Friend
              {
                  Id = 8,
                  Name="sara",
                  PhoneNumber="032589666",
                  Picture = "/images/icons8-image-80.png"
              },
          new Friend
              {
                  Id = 9 ,
                  Name="simin",
                  PhoneNumber="44778934579",
                  Picture = "/images/icons8-man-with-kiss-50.png"
              }
          

      };

   
    public IActionResult Index()
    {

         return View(friends);

    }

   
    public IActionResult EditOrAdd(int? id)
    {
        ViewBag.PageName = id == null ? "CreateFriend" : "EditFriend";
        ViewBag.IsEdit = id == null ? false : true;
        if ( id == null)
        {
            return View();
        }
        else
        {
           var freienddetail = friends.Where(s => s.Id == id).FirstOrDefault();
           if (freienddetail == null)
           {
              return NotFound();
           }
            return View(freienddetail);
        }
        
       
    }


    [HttpPost]
    [ValidateAntiForgeryToken]  
    public IActionResult EditOrAdd(int id, [Bind("Name,PhoneNumber")] Friend friend)
    {
        ViewBag.IsEdit = id == null ? false : true;
       var frienddetail =  friends.Where(s => s.Id == id).FirstOrDefault();
        friends.Remove(frienddetail);
       
       if (ModelState.IsValid)
       {
           try
           {

        
                frienddetail.Name = friend.Name;
                frienddetail.PhoneNumber = friend.PhoneNumber;
                frienddetail.Picture = (string)friends.Where(s => s.Id == id).Select(p => p.Picture).FirstOrDefault();             
                friends.Add(frienddetail);
               
              
           }
           catch (DbUpdateConcurrencyException)            
           {
              throw;
           }

           

          
        }
        return RedirectToAction("Index", new{friends});
       
    } 


    public IActionResult Detail(int? id)
    {
        if(id== null)
        {
            return NotFound();
        }

       var friend = friends.FirstOrDefault(m => m.Id == id);
       if (friend == null)
       {
        return NotFound();
       }
       return View(friend);
    }        
  
}

