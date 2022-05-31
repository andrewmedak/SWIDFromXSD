using NUnit.Framework;
using org.iso.standards.swid;

namespace SWIDFromXSDTests {
    public class XSDConversionTests {
        public static readonly string authoritativeFilename = "./Resources/authoritative.swidtag";
        public static readonly string nonauthoritativeFilename = "./Resources/non-authoritative.swidtag";

        [SetUp]
        public void Setup() {
        }

        [Test]
        public void TestReadAuthoritative() {
            SoftwareIdentity swid = SoftwareIdentity.Load(authoritativeFilename);
            Assert.That(swid, Is.Not.Null);
            Assert.That(swid.Entity[0].role, Has.Count.EqualTo(2));
            Assert.That(swid.Entity[0].role[1], Is.EqualTo("softwareCreator"));
            Assert.That(swid.Payload[0].File, Has.Count.EqualTo(1));
        }

        [Test]
        public void TestReadNonAuthoritative() {
            SoftwareIdentity swid = SoftwareIdentity.Load(nonauthoritativeFilename);
            Assert.That(swid, Is.Not.Null);
            Assert.That(swid.Entity[0].role, Has.Count.EqualTo(1));
            Assert.That(swid.Entity[0].role[0], Is.EqualTo("tagCreator"));
        }
    }
}
