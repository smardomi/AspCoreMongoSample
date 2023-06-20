using MongoDB.Driver;

namespace AspCoreMongoSample.Data
{
    public abstract class RepositoryBase<TEntity> where TEntity : class
    {
        protected readonly IMongoCollection<TEntity> Entities;
        protected RepositoryBase(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Entities = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
    }
}
