using CRM.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRM.Data
{
    public class CRMContext : DbContext
    {
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public CRMContext()
        {
            Debug.WriteLine("Создание экземпляра CRMContext");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=crm.db");
            Debug.WriteLine("Контекст базы данных настроен: crm.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientModel>().HasKey(c => c.FullName);
            modelBuilder.Entity<UserModel>().HasKey(u => u.Username);

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Username = "admin", Password = "admin123", Role = UserRole.Admin.ToString() },
                new UserModel { Username = "manager", Password = "manager123", Role = UserRole.Manager.ToString() }
            );

            modelBuilder.Entity<ClientModel>().HasData(
                new ClientModel { FullName = "Иван Иванов", PhoneNumber = "+375441234567", Email = "ivan@example.com", ClientType = "Физическое лицо" },
                new ClientModel { FullName = "Мария Петрова", PhoneNumber = "+375447654321", Email = "maria@example.com", ClientType = "VIP" }
            );

            Debug.WriteLine("Модель базы данных создана с начальными данными");
        }
    }
}