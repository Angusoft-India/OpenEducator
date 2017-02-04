using React;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OpenEducator.ReactConfig), "Configure")]
namespace OpenEducator
{
	public static class ReactConfig
	{
		public static void Configure()
		{
            ReactSiteConfiguration.Configuration
                .AddScript("~/Scripts/Components/DataBind.jsx");
		}
	}
}