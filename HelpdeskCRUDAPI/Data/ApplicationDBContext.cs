using System;
using HelpdeskCRUDAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskCRUDAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
    }
}
