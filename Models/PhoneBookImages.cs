using PhoneBook.Models;

namespace PhonBook.Model
{
    public class PhoneBookImages
    {
      public int Id { get; set; }
      public string ImageUrl {get;set;}
      
      public int PhoneBookId {get;set;}
      public PhoneBooks PhoneBook { get; set; }
    }
}