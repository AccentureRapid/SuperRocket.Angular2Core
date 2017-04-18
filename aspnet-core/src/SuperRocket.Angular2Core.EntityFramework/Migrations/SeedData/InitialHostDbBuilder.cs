using SuperRocket.Angular2Core.EntityFramework;
using EntityFramework.DynamicFilters;

namespace SuperRocket.Angular2Core.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly Angular2CoreDbContext _context;

        public InitialHostDbBuilder(Angular2CoreDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
