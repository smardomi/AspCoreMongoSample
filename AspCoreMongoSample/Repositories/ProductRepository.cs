using AspCoreMongoSample.Data;
using AspCoreMongoSample.Entities;
using MongoDB.Driver;

namespace AspCoreMongoSample.Repositories
{
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(IDatabaseSettings settings) : base(settings)
        {
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await Entities.Find(s => true).ToListAsync();
        }
        public async Task<Product> GetByIdAsync(string id)
        {
            return await Entities.Find<Product>(s => s.Id == id).FirstOrDefaultAsync();
        }
        public async Task CreateAsync(Product product)
        {
            await Entities.InsertOneAsync(product);
        }
        public async Task UpdateAsync(string id, Product product)
        {
            await Entities.ReplaceOneAsync(s => s.Id == id, product);
        }
        public async Task DeleteAsync(string id)
        {
            await Entities.DeleteOneAsync(s => s.Id == id);
        }
    }
}
