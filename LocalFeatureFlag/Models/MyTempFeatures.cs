using Microsoft.FeatureManagement;

/*
 * I'm using this class to explore the various interfaces and classes that comprise the Microsoft.FeatureManagement namespace.
 * It's all just temporary.
 */
namespace LocalFeatureFlag.Models
{
    public class MyTempFeatures
    {
        public MyTempFeatures()
        {
            var fd = new FeatureDefinition()
            {
                Name = "MyFeature",
                //Description = "This is my feature",
                //EnabledFor = new string[] { "MyUser" }
                EnabledFor = new System.Collections.Generic.IEnumerable<Microsoft.FeatureManagement.FeatureFilterConfiguration>() { new FeatureFilterConfiguration() { Name = "Percentage", Parameters = new System.Collections.Generic.Dictionary<string, string>() { { "Value", "50" } } } }
            };
        }
        //public FeatureDefinition fd? { get; set; }
    }
}
