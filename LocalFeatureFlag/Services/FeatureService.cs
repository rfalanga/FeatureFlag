// I am taking this from fffffatah:fffffatah/getting-features-from-database-example
// Note: when I started this project I wanted to use the full SQL Server. Today (5/11/2024) I've decided to
// use SQLite for this project, following the tutorial from fffffatah:fffffatah/getting-features-from-database-example

using LocalFeatureFlag.Database;

namespace LocalFeatureFlag.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly SqliteDbContext _sqliteDbContext;

        public FeatureService(SqliteDbContext sqlliteDbContext)
        {
            _sqliteDbContext = sqlliteDbContext;
        }
        public Task<Feature?> GetFeatureAsync(string featureName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Feature>> GetFeatureAsync()
        {
            throw new NotImplementedException();
        }
    }
}
