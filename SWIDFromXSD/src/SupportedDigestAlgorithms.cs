namespace SWIDFromXSD
{
    public class SupportedDigestAlgorithms {

        public static readonly SupportedDigestAlgorithms SHA1 = new ("SHA-1", "http://www.w3.org/2001/04/xmlenc#sha1");
        public static readonly SupportedDigestAlgorithms SHA256 = new ("SHA-256", "http://www.w3.org/2001/04/xmlenc#sha256");
        public static readonly SupportedDigestAlgorithms SHA384 = new ("SHA-384", "http://www.w3.org/2001/04/xmlenc#sha384");
        public static readonly SupportedDigestAlgorithms SHA512 = new ("SHA-512", "http://www.w3.org/2001/04/xmlenc#sha512");

        public static IEnumerable<SupportedDigestAlgorithms> Values
        {
            get
            {
                yield return SHA1;
                yield return SHA256;
                yield return SHA384;
                yield return SHA512;
            }
        }

        public string Name { get; private set; }
        public string Namespace { get; private set; }

        SupportedDigestAlgorithms(string name, string nameSpace) =>
            (Name, Namespace) = (name, nameSpace);
    }
}
