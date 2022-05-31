This library offers C# Objects that are generated from XSD schema published alongside ISO/IEC 19770-2:2015 Software identification tag. It includes SWID Tag Extensions from NISTIR 8060. Additionally, there are some utility functions for extracting hash attributes.

This project is intended to save others the step of converting the SWID XSDs. The library is available via Nuget https://www.nuget.org/packages/SWIDFromXSD.

The [README.md on the project page](https://www.github.com/andrewmedak/SWIDFromXSD/SWIDFromXSD/README.md) outlines the steps taken to convert the XSD into C#. 

#### Usage
Loading a SWID XML file is fairly simple
```
using org.iso.standards.swid;

namespace YourNamespace {
    public class YourClass {
	    public void YourMethod {
		    SoftwareIdentity swid = SoftwareIdentity.Load("/path/to/swidtag");
			...
		}
	}
}
```
From that point, you can drill down and access any elements defined in the ISO SWID schema.

Additional elements and attributes can also be accessed. The unit tests under SWIDFromXSDTests provide some example code for accessing Hash attributes.
