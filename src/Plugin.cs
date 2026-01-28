[assembly: System.Reflection.AssemblyTitle("HelloWorld")]
[assembly: System.Reflection.AssemblyDescription ("Generates a Hello World entry")]
[assembly: System.Reflection.AssemblyProduct("KeePass Plugin")]
[assembly: System.Reflection.AssemblyVersion ("0.1.2")]

namespace HelloWorld
{
	public class HelloWorldExt : KeePass.Plugins.Plugin
	{
		public override string UpdateUrl => "https://example.com/update.txt";

		public override bool Initialize(KeePass.Plugins.IPluginHost host)
		{
			host.FileFormatPool.Add(new Adrium.Snippets.HelloWorldFormatProvider());
			return true;
		}
	}
}
