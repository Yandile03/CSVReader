using CSVReader.Models;
using Microsoft.EntityFrameworkCore;


namespace CSVReader.Data
{
    public class AppDbContex : DbContext
    {
          
        public DbSet<DataScores> DataScores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=scores.db");

    }
}
