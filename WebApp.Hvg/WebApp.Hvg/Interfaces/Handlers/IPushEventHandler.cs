using WebApp.Hvg.Domain;

namespace WebApp.Hvg.Interfaces.Handlers
{
    public interface IPushEventHandler
    {
        void Save(PushEvent pushEvent);

        Commit[] GetCommitsByShortUrl(string shortUrl);
    }
}