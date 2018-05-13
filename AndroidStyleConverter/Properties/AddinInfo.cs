using System;
using Mono.Addins;
using Mono.Addins.Description;

[assembly: Addin(
	"AndroidStyleConverter",
	Namespace = "AndroidStyleConverter",
    Version = "1.0"
)]

[assembly: AddinName("AndroidStyleConverter")]
[assembly: AddinCategory("Android")]
[assembly: AddinDescription("Android Style Converter")]
[assembly: AddinAuthor("Vito Pistelli")]

[assembly: AddinDependency("::MonoDevelop.Core", MonoDevelop.BuildInfo.Version)]
[assembly: AddinDependency("::MonoDevelop.Ide", MonoDevelop.BuildInfo.Version)]