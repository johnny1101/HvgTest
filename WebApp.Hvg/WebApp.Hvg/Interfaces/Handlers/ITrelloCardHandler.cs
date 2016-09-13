using WebApp.Hvg.Domain;

namespace WebApp.Hvg.Interfaces.Handlers
{
    public interface ITrelloCardHandler
    {
        TrelloCard Get(string sha1Key);

        void Save(TrelloCard card);

        Manatee.Trello.Action AddCommitToCard(Commit commit);
    }
}