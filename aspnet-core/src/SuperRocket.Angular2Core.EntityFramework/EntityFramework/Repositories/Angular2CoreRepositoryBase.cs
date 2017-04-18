using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace SuperRocket.Angular2Core.EntityFramework.Repositories
{
    public abstract class Angular2CoreRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<Angular2CoreDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected Angular2CoreRepositoryBase(IDbContextProvider<Angular2CoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class Angular2CoreRepositoryBase<TEntity> : Angular2CoreRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected Angular2CoreRepositoryBase(IDbContextProvider<Angular2CoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
