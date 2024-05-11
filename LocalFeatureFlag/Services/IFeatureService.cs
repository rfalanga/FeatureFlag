// I am taking this from fffffatah:fffffatah/getting-features-from-database-example
using LocalFeatureFlag.Database;

namespace LocalFeatureFlag.Services;

public interface IFeatureService
{
    Task<Feature?> GetFeatureAsync(string featureName);
    Task<IEnumerable<Feature>> GetFeatureAsync();
}
