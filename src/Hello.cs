using System.IO;
using System.Reflection;
using KeePass.DataExchange;
using KeePass.Resources;
using KeePassLib;
using KeePassLib.Interfaces;
using KeePassLib.Security;

[assembly: System.Reflection.AssemblyTitle("HelloWorld")]
[assembly: System.Reflection.AssemblyDescription ("Generates a Hello World entry")]
[assembly: System.Reflection.AssemblyProduct("KeePass Plugin")]
[assembly: System.Reflection.AssemblyVersion ("0.1.2")]

namespace HelloWorld
{
	public class HelloWorldExt : KeePass.Plugins.Plugin
	{
		public override string UpdateUrl { get { return "https://example.com/update.txt"; } }

		public override bool Initialize(KeePass.Plugins.IPluginHost host)
		{
			host.FileFormatPool.Add(new Adrium.Snippets.HelloWorldFormatProvider());
			return true;
		}
	}
}

namespace Adrium.Snippets
{
	public class HelloWorldFormatProvider : FileFormatProvider
	{
		public override bool SupportsImport => true;
		public override bool SupportsExport => false;
		public override bool ImportAppendsToRootGroupOnly => true;
		public override bool RequiresFile => false;
		public override string ApplicationGroup => KPRes.PasswordManagers;
		public override string FormatName => "The Hello World Entry";

		public override void Import(PwDatabase pwStorage, Stream sInput, IStatusLogger slLogger)
		{
			var entry = new PwEntry(true, true);

			entry.Strings.Set(PwDefs.TitleField, new ProtectedString(false, "Hello World"));
			entry.Strings.Set(PwDefs.UserNameField, new ProtectedString(false, "hello"));
			entry.Strings.Set(PwDefs.PasswordField, new ProtectedString(true, "world"));

			pwStorage.RootGroup.AddEntry(entry, true);
			slLogger.SetText("Hello World Entry added", LogStatusType.Info);
		}
	}
}
