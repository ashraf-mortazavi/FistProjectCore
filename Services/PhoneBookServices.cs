using PhonBook.Context;
using PhoneBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PhonBook.Services
{

    public class PhoneBookServices : Controller, IPhoneBookServices
    {
        PhonebookDbContext phonebookdbcontext;
        public PhoneBookServices(PhonebookDbContext _phonebookdbcontext)
        {
            this.phonebookdbcontext = _phonebookdbcontext;
        }

        public List<PhoneBooks> Read()
        {
            return phonebookdbcontext.PhoneBooks.ToList();
        }

       
        [ValidateAntiForgeryToken]
        public void Create(PhoneBooks phonebooks)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    phonebookdbcontext.PhoneBooks.Add(phonebooks);
                    Save();

                }
                catch (System.Exception)
                {

                    throw;
                }

            }


        }
        
        [ValidateAntiForgeryToken]
        public void Update(int id,  PhoneBooks phonebooks)
        {

            if ( phonebookdbcontext.PhoneBooks.AsNoTracking().
            FirstOrDefault(x => x.Id == phonebooks.Id) != null)
             {
                if (ModelState.IsValid)
                {
                    try
                    {                        
                        //phonebookdbcontext.Entry(phonebooks).State = EntityState.Detached;
                        phonebookdbcontext.PhoneBooks.Update(phonebooks);
                        Save();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                 }
            }

        }

        public void Delete(int id)
        {
            if (id != null)
            {
                PhoneBooks phoneBooks = phonebookdbcontext.PhoneBooks.Find(id);
                phonebookdbcontext.PhoneBooks.Remove(phoneBooks);
                Save();
            }

        }

        public PhoneBooks Detail(int id )
        {
            return phonebookdbcontext.PhoneBooks.Find(id);
        }

        private void Save()
        {
            phonebookdbcontext.SaveChanges();
        }


    }
}