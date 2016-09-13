using System.Data.Entity;

namespace WebApp.Hvg.Models
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext() 
            : base("name=HvgTrelloManagementEntities")
        {
        }

        public DbSet<Commit> Commit { get; set; }
        public DbSet<TrelloCard> TrelloCard { get; set; }
    }
}