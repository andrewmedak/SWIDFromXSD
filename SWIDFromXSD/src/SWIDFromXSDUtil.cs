using System.Xml.Linq;
using Xml.Schema.Linq;

namespace SWIDFromXSD {
    public class SWIDFromXSDUtil {
        public static readonly string HashAttributeKey = "hash";

        public static XAttribute? FindFirstUntypedHashAttributeInElement(XTypedElement item) {
            IEnumerable<XAttribute> attributes = item.Untyped.Attributes();
            IEnumerable<SupportedDigestAlgorithms> digestAlgs = SupportedDigestAlgorithms.Values;
            XAttribute? result = null;
            foreach (XAttribute attribute in attributes) {
                SupportedDigestAlgorithms? alg = digestAlgs.SingleOrDefault(s => s.Namespace.Equals(attribute.Name.Namespace.ToString(), StringComparison.InvariantCultureIgnoreCase));
                if (alg != null) {
                    result = attribute;
                    break;
                }
            }
            return result;
        }

        public static XAttribute? FindUntypedSHA1HashAttributeInElement(XTypedElement item) {
            return FindSpecificUntypedHashAttributeInElement(SupportedDigestAlgorithms.SHA1, item);
        }

        public static XAttribute? FindUntypedSHA256HashAttributeInElement(XTypedElement item)
        {
            return FindSpecificUntypedHashAttributeInElement(SupportedDigestAlgorithms.SHA256, item);
        }

        public static XAttribute? FindUntypedSHA384HashAttributeInElement(XTypedElement item)
        {
            return FindSpecificUntypedHashAttributeInElement(SupportedDigestAlgorithms.SHA384, item);
        }

        public static XAttribute? FindUntypedSHA512HashAttributeInElement(XTypedElement item)
        {
            return FindSpecificUntypedHashAttributeInElement(SupportedDigestAlgorithms.SHA512, item);
        }

        public static XAttribute? FindSpecificUntypedHashAttributeInElement(SupportedDigestAlgorithms digestAlg, XTypedElement item)
        {
            IEnumerable<XAttribute> attributes = item.Untyped.Attributes();
            XAttribute? result = null;
            foreach (XAttribute attribute in attributes) {
                bool found = digestAlg.Namespace.Equals(attribute.Name.Namespace.ToString(), StringComparison.InvariantCultureIgnoreCase);
                if (found) {
                    result = attribute;
                    break;
                }
            }
            return result;
        }

        public static SupportedDigestAlgorithms? GetDigestAlgFromHashAttribute(XAttribute hashAttribute) {
            SupportedDigestAlgorithms? alg = SupportedDigestAlgorithms.Values.SingleOrDefault(s => s.Namespace.Equals(hashAttribute.Name.Namespace.ToString(), StringComparison.InvariantCultureIgnoreCase));
            return alg;
        }

        public static string GetDigestFromHashAttribute(XAttribute hashAttribute) {
            return hashAttribute.Value;
        }
    }
}
