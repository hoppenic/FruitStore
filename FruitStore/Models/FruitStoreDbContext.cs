using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FruitStore.Models;


namespace FruitStore.Models
{
    public class FruitStoreDbContext : IdentityDbContext<FruitStoreUser>
    {
        public FruitStoreDbContext() : base()
        {


        }

        public FruitStoreDbContext(DbContextOptions options): base(options)
        {


        }

        public DbSet<Product> Products { get; set; }
    }

    public class FruitStoreUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }

}
