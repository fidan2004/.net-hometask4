using Hometask4_patterns.Data.Context;
using Hometask4_patterns.Data.Entities;
using Hometask4_patterns.Repository.Abstractions;
using Hometask4_patterns.Repository.Implementations;

namespace Hometask4_patterns.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Posts, int> postRepository { get; set; }
        public IRepository<Blog, int> blogRepository { get; set; }

        private readonly AppDbContext _appDbContext;   

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

            postRepository = new EfRepository<Posts, int>(_appDbContext);
            blogRepository = new EfRepository<Blog, int>(_appDbContext);
        }

        public async Task Commit()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
