using System;
using Manatee.Trello;
using WebApp.Hvg.Domain;
using WebApp.Hvg.Interfaces.Handlers;
using WebApp.Hvg.Repositories;

namespace WebApp.Hvg.Handlers
{
    public class TrelloCardHandler : ITrelloCardHandler
    {
        private readonly TrelloCardRepository _trelloCardRepository;
        public TrelloCardHandler()
        {
            _trelloCardRepository = new TrelloCardRepository();
        }

        public TrelloCard Get(string sha1Key)
        {
            if (string.IsNullOrWhiteSpace(sha1Key))
                return null;

            return _trelloCardRepository.Get(sha1Key);
        }

        public void Save(TrelloCard card)
        {
            _trelloCardRepository.Save(card);
        }

        public Manatee.Trello.Action AddCommitToCard(Commit commit)
        {
            if (commit == null)
                throw new ArgumentNullException("commit");

            var card = GetCardByShortUrl(commit.ShortUrl);
            if (card == null)
                throw new Exception("The card does not exist.");
            
            var comment = string.Format(Properties.Settings.Default.CommitFormat, commit.Sha, commit.BranchName, commit.Message);

            return card.Comments.Add(comment);
        }

        private static Card GetCardByShortUrl(string shortUrl)
        {
            return string.IsNullOrWhiteSpace(shortUrl) ? null : new Card(shortUrl);
        }
    }
}