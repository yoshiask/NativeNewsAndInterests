using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace NativeNewsAndInterests.Skia.Tizen
{
	class Program
	{
		static void Main(string[] args)
		{
			var host = new TizenHost(() => new NativeNewsAndInterests.App(), args);
			host.Run();
		}
	}
}
