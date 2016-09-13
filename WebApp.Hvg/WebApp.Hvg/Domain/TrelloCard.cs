using Manatee.Trello;

namespace WebApp.Hvg.Domain
{
    public class TrelloCard
    {
        public string Name { get; set; }

        public Commit Commit { get; set; }

        public Card Card { get; set; }
    }
}
