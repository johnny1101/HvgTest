using System.Linq;
using WebApp.Hvg.Interfaces.Mappers;
using WebApp.Hvg.Mappers;
using WebApp.Hvg.Models;

namespace WebApp.Hvg.Repositories
{
    public class TrelloCardRepository
    {
        private readonly IBaseMapper<Domain.TrelloCard, TrelloCard> _trelloCardMapper;

        public TrelloCardRepository()
        {
            _trelloCardMapper = new TrelloCardMapper();
        }

        public Domain.TrelloCard Get(string sha1Key)
        {
            using (var dbContext = new WebAppDbContext())
            {
                var dbTrelloCard = dbContext.TrelloCard.FirstOrDefault(card => card.Commit.Sha1Id == sha1Key);
                return _trelloCardMapper.Map(dbTrelloCard);
            }
        }

        public void Save(Domain.TrelloCard card)
        {
            using (var dbContext = new WebAppDbContext())
            {
                var dbTrelloCard = _trelloCardMapper.Map(card);
                dbContext.TrelloCard.Add(dbTrelloCard);

                dbContext.SaveChanges();
            }
        }
    }
}