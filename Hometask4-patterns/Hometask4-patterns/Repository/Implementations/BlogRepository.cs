using Hometask4_patterns.Data.Context;
using Hometask4_patterns.Data.Entities;
using Hometask4_patterns.Repository.Abstractions;

namespace Hometask4_patterns.Repository.Implementations
{
    public class BlogRepository:EfRepository<Blog,int>,IBlogRepository
    {

        private readonly AppDbContext _appDbContext;

        public BlogRepository(AppDbContext appDbContext):base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
