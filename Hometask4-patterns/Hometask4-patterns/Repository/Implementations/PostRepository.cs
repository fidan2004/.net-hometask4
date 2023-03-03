using Hometask4_patterns.Data.Context;
using Hometask4_patterns.Data.Entities;
using Hometask4_patterns.Repository.Abstractions;

namespace Hometask4_patterns.Repository.Implementations
{
    public class PostRepository:EfRepository<Posts,int>,IPostRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostRepository(AppDbContext appDbContext):base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
