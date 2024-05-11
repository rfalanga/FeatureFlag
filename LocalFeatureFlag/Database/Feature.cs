// I am taking this from fffffatah:fffffatah/getting-features-from-database-example
namespace LocalFeatureFlag.Database
{
    public class Feature
    {
        public required string Name { get; set; }   // Visual Studio suggested adding 'required' here
        public bool IsEnabled { get; set; }
    }
}
