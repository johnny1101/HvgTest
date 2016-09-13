using System;
using WebApp.Hvg.Domain;
using WebApp.Hvg.Interfaces.Handlers;
using WebApp.Hvg.Repositories;

namespace WebApp.Hvg.Handlers
{
    public class PushEventHandler : IPushEventHandler
    {
        private readonly CommitRepository _commitRepository;
        private readonly TrelloCardHandler _trelloCardHandler;

        public PushEventHandler()
        {
            _commitRepository = new CommitRepository();
            _trelloCardHandler = new TrelloCardHandler();
        }

        public Domain.Commit[] GetCommitsByShortUrl(string shortUrl)
        {
            return _commitRepository.GetAll(shortUrl);
        }

        public void Save(PushEvent pushEvent)
        {
            if (pushEvent == null || pushEvent.Commits == null)
                return;

            foreach (var commit in pushEvent.Commits)
            {
                commit.ShortUrl = GetTrelloLink(commit.Message);

                _commitRepository.Save(commit, commit.ShortUrl);

                var action = _trelloCardHandler.AddCommitToCard(commit);
                _trelloCardHandler.Save(new Domain.TrelloCard
                {
                    Commit = commit,
                    Card = action.Data.Card
                });
            }
        }

        private static string GetTrelloLink(string text)
        {
            try
            {
                //TODO: Regexp
                if (!text.Contains(Properties.Settings.Default.TrelloCardUrl))
                    return null;

                var startIndex = text.IndexOf(Properties.Settings.Default.TaskIdCardUrlSeparator, StringComparison.Ordinal) + 1;
                var endIndex = text.IndexOf(" ", StringComparison.Ordinal) - startIndex;
                if (startIndex <= 0 || endIndex <= 0 || endIndex <= startIndex)
                    return null;

                var trelloCardLink = text.Substring(startIndex, endIndex);
                var lastIndexOfBackSlash = trelloCardLink.LastIndexOf("/", StringComparison.Ordinal);
                return lastIndexOfBackSlash <= 0 ? null : trelloCardLink.Substring(lastIndexOfBackSlash + 1);
            }
            catch (Exception)
            {
                //TODO: Log
                return null;
            }
        }
    }
}