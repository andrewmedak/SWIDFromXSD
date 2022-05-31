Procedures to generate the source files:

#### Gather source XSD files
* Create a folder ```xsd``` in the root directory of the project.
* Download these files to that xsd directory
     * http://standards.iso.org/iso/19770/-2/2015-current/schema.xsd
     * https://csrc.nist.gov/schema/swid/2015-extensions/swid-2015-extensions-1.0.xsd

#### Install LinqToXsdCore
This project uses [LinqToXSDCore](https://github.com/mamift/LinqToXsdCore) to generate the C# code files.
```dotnet tool install LinqToXsdCore -g```

#### Create LinqToXsdCore namespace config files
These commands are run from the root directory of the project with the XSD files downloaded to .\xsd.
```linqtoxsd config -e .\xsd\iso-19770-2-schema-1.0.xsd .\xsd\swid-2015-extensions-1.0.xsd```
This will output *LinqToXsdConfig.config*

#### Change generated namespaces in LinqToXsdConfig.config
##### Change
```
    <Namespace DefaultVisibility="public" Schema="http://standards.iso.org/iso/19770/-2/2015/schema.xsd" Clr="standards.iso.org.iso.19770.2.2015.schema.xsd" />
    <Namespace DefaultVisibility="public" Schema="http://www.w3.org/2000/09/xmldsig#" Clr="www.w3.org.2000.09.xmldsig" />
    <Namespace DefaultVisibility="public" Schema="http://www.w3.org/XML/1998/namespace" Clr="www.w3.org.XML.1998.namespace" />
    <Namespace DefaultVisibility="public" Schema="http://csrc.nist.gov/ns/swid/2015-extensions/1.0" Clr="csrc.nist.gov.ns.swid.2015.extensions.1.0" />
```
##### To
```
    <Namespace DefaultVisibility="public" Schema="http://standards.iso.org/iso/19770/-2/2015/schema.xsd" Clr="org.iso.standards.swid" />
    <Namespace DefaultVisibility="public" Schema="http://www.w3.org/2000/09/xmldsig#" Clr="org.w3.ds" />
	<Namespace DefaultVisibility="public" Schema="http://www.w3.org/2001/XMLSchema" Clr="org.w3.xs" />
    <Namespace DefaultVisibility="public" Schema="http://www.w3.org/XML/1998/namespace" Clr="org.w3.xml" />
    <Namespace DefaultVisibility="public" Schema="http://csrc.nist.gov/ns/swid/2015-extensions/1.0" Clr="gov.nist.csrc.swid.extensions" />
```

#### Convert XSD to C#
```linqtoxsd gen .\xsd\iso-19770-2-schema-1.0.xsd .\xsd\swid-2015-extensions-1.0.xsd -c .\LinqToXsdConfig.config -o .\src\ ```

#### Convert Line endings of Files to Unix (LF)

#### Replace lang.TypeDefinition with null
There is a bug in either the schema or during conversion that results in iso-19770-2-schema-1.0.xsd.cs using a type that does not exist. There are two references to ```lang.TypeDefinition``` that need to be replaced with ```null```.

#### Install XObjectsCore from Nuget

#### Useful library methods
```SoftwareIdentity swid = SoftwareIdentity.Load("/path/to/swidtag");```
```byte[] bytes = Convert.FromHexString(string);```

### Useful links
* Newer versions of XSD files may be listed here: https://csrc.nist.gov/Projects/Software-Identification-SWID/resources
* NIST SWID tools available here: https://github.com/usnistgov/swid-tools
