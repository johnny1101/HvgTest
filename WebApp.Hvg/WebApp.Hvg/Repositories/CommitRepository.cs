using System.Linq;
using WebApp.Hvg.Interfaces.Mappers;
using WebApp.Hvg.Mappers;
using WebApp.Hvg.Models;

namespace WebApp.Hvg.Repositories
{
    public class CommitRepository
    {
        private readonly IBaseMapper<Domain.Commit, Commit> _commitMapper;

        public CommitRepository()
        {
            _commitMapper = new CommitMapper();
        }

        public void Save(Domain.Commit commit, string trelloLink)
        {
            using (var context = new WebAppDbContext())
            {
                var dbCommit = _commitMapper.Map(commit);
                context.Commit.Add(dbCommit);

                context.SaveChanges();
            }
        }

        public Domain.Commit[] GetAll(string shortUrl)
        {
            using (var context = new WebAppDbContext())
            {
                return context.Commit.Where(commit => commit.TrelloCardShortUrl.Contains(shortUrl))
                    .Select(_commitMapper.Map)
                    .ToArray();
            }
        }
    }
}