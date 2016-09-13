using WebApp.Hvg.Domain;
using WebApp.Hvg.Interfaces.Mappers;

namespace WebApp.Hvg.Mappers
{
    public class CommitMapper : IBaseMapper<Commit, Models.Commit>
    {
        public Commit Map(Models.Commit entity)
        {
            if (entity == null)
                return null;

            var commit = new Commit
            {
                Message = entity.Message,
                BranchName = entity.BranchName,
                Sha = entity.Sha1Id,
                ShortUrl = entity.TrelloCardShortUrl
            };
            
            return commit;
        }

        public Models.Commit Map(Commit domain)
        {
            if (domain == null)
                return null;

            var dbCommit = new Models.Commit
            {
                Sha1Id = domain.Sha,
                Message = domain.Message,
                TrelloCardShortUrl = domain.ShortUrl,
                BranchName = domain.BranchName
            };

            return dbCommit;
        }
    }
}