using BuzzyBox_Web_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace BuzzyBox_Web_Api.Data
{
    public class DataContext : DbContext
    {
      public DataContext(DbContextOptions<DataContext> options) : base(options) { }
      public DbSet<Users> Users { get; set; }

      public DbSet<Role> Roles { get; set; }
      public DbSet<Food> Foods { get; set; }

      public DbSet<Foodorder> Foodorders { get; set; }

      public DbSet<Booking> Bookings { get; set; }

      public DbSet<Bookingtype> Bookingtypes { get; set; }
      public DbSet<Transaction> Transactions { get; set; }
      public DbSet<Transactiontype> Transactiontypes { get; set; }
      public DbSet<Timestamp> Timestamps { get; set; }

      public DbSet<Duration> Durations { get; set; }

      public DbSet<Coupans> Coupans { get; set; }
      







    }
}
