using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Ebuy.Models
{
    public class Auction
    {
        public long Id { get; set; }
        [Required, StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(1,10000, ErrorMessage = "The auction's starting price must be at least $1")]
        public decimal StartPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime StartTime { get; set; }
        [Range (typeof(DateTime), "1/1/2012", "12/31/9998")]
        public DateTime EndTime { get; set; }
    }

    public class EbuyDataContext : DbContext
    {
        public EbuyDataContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Auction> Auctions { get; set; }
    }
}