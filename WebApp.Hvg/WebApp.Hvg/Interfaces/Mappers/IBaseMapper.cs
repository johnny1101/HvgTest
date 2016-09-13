namespace WebApp.Hvg.Interfaces.Mappers
{
    public interface IBaseMapper<TDomain, TEntity>
        where TDomain : class
        where TEntity : class
    {
        TEntity Map(TDomain domain);
        TDomain Map(TEntity entity);
    }
}