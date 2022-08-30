
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.Models;

public class PhoneBooks
{
    [Required(ErrorMessage = "Please Enter Your Name")]
    [MaxLength(50)]
    [Display(Name = "Name")]
   
    public string Name { get; set; }

    [Required(ErrorMessage = "Please Enter Your PhoneNumber")]
    [Display(Name = "PhoneNumber")]
   
    public string PhoneNumber { get; set; }

    
    public int? Id { get; set; }

    public interface IPhonBook
    {
        List<PhoneBooks> GetAllPhoneBooksItems();

    }


    public class PhoneBookItems : IPhonBook
    {
        public List<PhoneBooks> GetAllPhoneBooksItems()
        {
            List<PhoneBooks> phonebooks = new List<PhoneBooks>
            {
          new PhoneBooks {
              Id =1,
              Name = "Ali",
              PhoneNumber= "0946546468"

          },
          new PhoneBooks {
              Id =2,
              Name ="Amir",
              PhoneNumber ="5542347987"
          },
          new PhoneBooks {
              Id = 3,
              Name= "Mohammad",
              PhoneNumber= "123658947"

          },
          new PhoneBooks  {
              Id = 4,
              Name= "Ahmad",
              PhoneNumber = "178563247"
          },
          new PhoneBooks {
                  Id = 5,
                  Name= "Sina",
                  PhoneNumber = "889511123"
            },
          new PhoneBooks {
                 Id= 6,
                 Name="Sara",
                 PhoneNumber = "7102594235"
            },
          new PhoneBooks
              {
                  Id = 7,
                  Name="Amin",
                  PhoneNumber="22359874"
              },
          new PhoneBooks
              {
                  Id = 8,
                  Name="Ramin",
                  PhoneNumber="032589666"
              },
          new PhoneBooks
              {
                  Id = 9 ,
                  Name="Mina",
                  PhoneNumber="44778934579"
              }


            };
            return phonebooks;
        }

    }


    // override object.Equals
    /* public override bool Equals(Object obj)
    {
        //
        // See the full list of guidelines at
        //   http://go.microsoft.com/fwlink/?LinkID=85237
        // and also the guidance for operator== at
        //   http://go.microsoft.com/fwlink/?LinkId=85238
        //

        var f = (Friend) obj;
        
        if (Id == f.Id)
        {
            return true;
        }
        
        // TODO: write your implementation of Equals() here
        throw new System.NotImplementedException();
        return base.Equals (obj);
    }
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        // TODO: write your implementation of GetHashCode() here
        throw new System.NotImplementedException();
        return base.GetHashCode();
    } */
}
