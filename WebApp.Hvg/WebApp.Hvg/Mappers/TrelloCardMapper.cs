using WebApp.Hvg.Domain;
using WebApp.Hvg.Interfaces.Mappers;

namespace WebApp.Hvg.Mappers
{
    public class TrelloCardMapper : IBaseMapper<TrelloCard, Models.TrelloCard>
    {
        private readonly IBaseMapper<Commit, Models.Commit> _commitMapper;

        public TrelloCardMapper()
        {
            _commitMapper = new CommitMapper();
        }

        public TrelloCard Map(Models.TrelloCard entity)
        {
            if (entity == null)
                return null;

            var trelloCard = new TrelloCard
            {
                Name = entity.Name
            };

            if (entity.Commit != null)
            {
                trelloCard.Commit = _commitMapper.Map(entity.Commit);
            }

            return trelloCard;
        }

        public Models.TrelloCard Map(TrelloCard domain)
        {
            if (domain == null)
                return null;

            var dbTrelloCard = new Models.TrelloCard
            {
                Name = domain.Name
            };

            if (domain.Commit != null)
            {
                dbTrelloCard.Commit = _commitMapper.Map(domain.Commit);
            }

            if (domain.Card != null)
            {
                dbTrelloCard.UrlId = domain.Card.ShortUrl;
            }

            return dbTrelloCard;
        }
    }
}