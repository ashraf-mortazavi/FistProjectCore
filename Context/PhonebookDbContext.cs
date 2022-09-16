using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhonBook.Context
{
  public class PhonebookDbContext: DbContext
  {

    public PhonebookDbContext(DbContextOptions<PhonebookDbContext> options)
    :base(options)
    {
      
    }
    public DbSet<PhoneBooks> PhoneBooks {get;set;}

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
        modelBuilder.Entity<PhoneBooks>().HasKey(c => c.Id);
         modelBuilder.Entity<PhoneBooks>().HasMany(a => a.PhoneBookImages)
         .WithOne(a => a.PhoneBook).HasForeignKey(a => a.PhoneBookId);

         base.OnModelCreating(modelBuilder);
     }
  }  
}
