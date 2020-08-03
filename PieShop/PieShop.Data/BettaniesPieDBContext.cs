using Ingenico.Data.Entities;
using Ingenico.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ingenico.DB
{
    public class BettaniesPieDBContext : DbContext
    {
        DbSet<Pies> Pies { get; set; }
        DbSet<Users> Users { get; set; }
        DbSet<PaymentOptions> PaymentOptions { get; set; }
        DbSet<OrderLines> OrderLines { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<SavingsCard> SavingsCards { get; set; }

        public BettaniesPieDBContext(DbContextOptions options) : base(options)
        {
        }

        public BettaniesPieDBContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=be-pf1jbmvd.database.windows.net;Initial Catalog=PieShop;User ID=mgerardi2;Password=!lkTZ3X1989!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateDefaultUser(modelBuilder);
            CreatePaymentOptions(modelBuilder);
            CreateDefaultPies(modelBuilder);
        }
        private void CreateDefaultUser(ModelBuilder modelBuilder)
        {
            string folderPath = @"C:\Users\mgerardi2\source\repos\PieShop\PieShop\PieShop.Data\Assets\Users\";
            modelBuilder.Entity<Users>().HasData(
              new Users
              {
                  Id = 1,
                  FirstName = "Maikel",
                  LastName = "Gerardi",
                  Image = GetPicture(String.Concat(folderPath, "Maikel", "Gerardi", ".jpg")),
                  SavingsCardId = null
              }
          );
        }
        private void CreatePaymentOptions(ModelBuilder modelBuilder)
        {
            string folderPath = @"C:\Users\mgerardi2\source\repos\PieShop\PieShop\PieShop.Data\Assets\PaymentOptions\";
            string[] fileEntries = Directory.GetFiles(folderPath);
    
            for (int i = 0; i < fileEntries.Length; i++)
            {
                string filePath = fileEntries[i];
                string fileName = Path.GetFileName(fileEntries[i]);

                modelBuilder.Entity<PaymentOptions>().HasData(
                 new PaymentOptions
                 {
                     Id = i+1,
                     Name = fileName.Remove(fileName.IndexOf("."), fileName.Length - fileName.IndexOf(".")),
                     Image = GetPicture(filePath)
                 }
             );
            }
        }
        private void CreateDefaultPies(ModelBuilder modelBuilder)
        {
            string folderPath = @"C:\Users\mgerardi2\source\repos\PieShop\PieShop\PieShop.Data\Assets\Pies\";
            string[] fileEntries = Directory.GetFiles(folderPath);

            for (int i = 0; i < fileEntries.Length; i++)
            {
                string filePath = fileEntries[i];
                string fileName = Path.GetFileName(fileEntries[i]);
                modelBuilder.Entity<Pies>().HasData(new Entities.Pies()
                {
                    Id = i+1,
                    Name = fileName.Remove(fileName.IndexOf("."), fileName.Length - fileName.IndexOf(".")),
                    Price = 12,
                    Image = GetPicture(filePath)
                });
            }
        }
        private byte[] GetPicture(string filePath)
        {
            byte[] imageByteArray = null;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                imageByteArray = new byte[reader.BaseStream.Length];
                for (int i = 0; i < reader.BaseStream.Length; i++)
                    imageByteArray[i] = reader.ReadByte();
            }

            return imageByteArray;
        }
    }
}
