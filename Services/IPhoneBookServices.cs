using PhoneBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace PhonBook.Services
{
    public interface IPhoneBookServices
    {
        void Create(PhoneBooks phoneBooks);
        void Delete(int id);
        List<PhoneBooks> Read();
        void Update(int id , PhoneBooks phonebooks); 
        PhoneBooks Detail(int id);
    }
}