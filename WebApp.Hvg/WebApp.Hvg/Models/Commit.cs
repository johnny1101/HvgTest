namespace WebApp.Hvg.Models
{
    public class Commit
    {
        public int Id { get; set; }

        public string Sha1Id { get; set; }

        public string Message { get; set; }

        public string BranchName { get; set; }

        public string TrelloCardShortUrl { get; set; }
    }
}