namespace WebApp.Hvg.Models
{
    public class TrelloCard
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlId { get; set; }

        public virtual Commit Commit { get; set; }
    }
}
