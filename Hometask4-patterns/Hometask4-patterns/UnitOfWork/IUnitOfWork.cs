using Hometask4_patterns.Data.Entities;
using Hometask4_patterns.Repository.Abstractions;

namespace Hometask4_patterns.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<Posts, int> postRepository { get; set; }
        public IRepository<Blog, int> blogRepository { get; set; }

        public Task Commit();
    }
}
