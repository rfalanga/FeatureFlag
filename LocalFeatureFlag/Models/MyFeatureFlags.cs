using Microsoft.FeatureManagement;

namespace LocalFeatureFlag.Models
{
    public class MyFeatureFlags : IFeatureDefinitionProvider
    {
        public IAsyncEnumerable<FeatureDefinition> GetAllFeatureDefinitionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FeatureDefinition> GetFeatureDefinitionAsync(string featureName)
        {
            throw new NotImplementedException();
        }
    }
}
