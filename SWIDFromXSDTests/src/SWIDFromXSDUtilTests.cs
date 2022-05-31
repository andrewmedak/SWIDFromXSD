using NUnit.Framework;
using org.iso.standards.swid;
using SWIDFromXSD;
using System.Xml.Linq;

namespace SWIDFromXSDTests {
    public class SWIDFromXSDUtilTests {
        public static readonly string fileHash256 = "abab9565a2593aa037b0054d0a84dbf4d23795840f1321e9476fa7b8eb5d432b";
        public static readonly string fileHash512 = "5787658e68139e4c0b46033930362a14fea58c5bcd3063440d49e9a268f5741a6cacafd3d0512228bb081394afb14a5c1e4dcce6ac0db50189a9160d737fe862";

        [Test]
        public void FindFirstUntypedHashAttributeInElement()
        {
            SoftwareIdentity swid = SoftwareIdentity.Load(XSDConversionTests.authoritativeFilename);
            Assert.That(swid, Is.Not.Null);
            XAttribute? attribute = SWIDFromXSDUtil.FindUntypedSHA256HashAttributeInElement(swid.Payload[0].File[0]);
            Assert.That(attribute, Is.Not.Null);
            string digest = SWIDFromXSDUtil.GetDigestFromHashAttribute(attribute);
            Assert.That(digest, Is.EqualTo(fileHash256));
        }

        [Test]
        public void TestFindUntypedSHA1HashAttributeInElement()
        {
            SoftwareIdentity swid = SoftwareIdentity.Load(XSDConversionTests.nonauthoritativeFilename);
            Assert.That(swid, Is.Not.Null);
            XAttribute? attribute = SWIDFromXSDUtil.FindUntypedSHA1HashAttributeInElement(swid.Payload[0].File[0]);
            Assert.That(attribute, Is.Null);
        }

        [Test]
        public void TestFindUntypedSHA256HashAttributeInElement() {
            SoftwareIdentity swid = SoftwareIdentity.Load(XSDConversionTests.authoritativeFilename);
            Assert.That(swid, Is.Not.Null);
            XAttribute? attribute = SWIDFromXSDUtil.FindUntypedSHA256HashAttributeInElement(swid.Payload[0].File[0]);
            Assert.That(attribute, Is.Not.Null);
            string digest = SWIDFromXSDUtil.GetDigestFromHashAttribute(attribute);
            Assert.That(digest, Is.EqualTo(fileHash256));
        }

        [Test]
        public void TestFindUntypedSHA512HashAttributeInElement()
        {
            SoftwareIdentity swid = SoftwareIdentity.Load(XSDConversionTests.nonauthoritativeFilename);
            Assert.That(swid, Is.Not.Null);
            XAttribute? attribute = SWIDFromXSDUtil.FindUntypedSHA512HashAttributeInElement(swid.Payload[0].File[0]);
            Assert.That(attribute, Is.Not.Null);
            string digest = SWIDFromXSDUtil.GetDigestFromHashAttribute(attribute);
            Assert.That(digest, Is.EqualTo(fileHash512));
        }
    }
}
