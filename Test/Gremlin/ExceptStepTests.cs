using NUnit.Framework;
using Neo4jClient.Gremlin;

namespace Neo4jClient.Test.Gremlin
{
    [TestFixture]
    public class ExceptStepTests
    {
        [Test]
        public void ExceptVShouldAppendStep()
        {
            var query = new NodeReference(123).ExceptV<object>("foo");
            Assert.AreEqual("g.v(p0).except(foo)", query.QueryText);
            Assert.AreEqual(123, query.QueryParameters["p0"]);
        }

        [Test]
        public void ExceptVShouldReturnTypedNodeEnumerable()
        {
            var query = new NodeReference(123).ExceptV<object>("foo");
            Assert.IsInstanceOf<GremlinNodeEnumerable<object>>(query);
        }

        [Test]
        public void ExceptEShouldAppendStep()
        {
            var query = new NodeReference(123).ExceptE("foo");
            Assert.AreEqual("g.v(p0).except(foo)", query.QueryText);
            Assert.AreEqual(123, query.QueryParameters["p0"]);
        }

        [Test]
        public void ExceptEShouldReturnRelationshipEnumerable()
        {
            var query = new NodeReference(123).ExceptE("foo");
            Assert.IsInstanceOf<GremlinRelationshipEnumerable>(query);
        }

        [Test]
        public void ExceptEWithTDataShouldAppendStep()
        {
            var query = new NodeReference(123).ExceptE<object>("foo");
            Assert.AreEqual("g.v(p0).except(foo)", query.QueryText);
            Assert.AreEqual(123, query.QueryParameters["p0"]);
        }

        [Test]
        public void ExceptEWithTDataShouldReturnRelationshipEnumerable()
        {
            var query = new NodeReference(123).ExceptE<object>("foo");
            Assert.IsInstanceOf<GremlinRelationshipEnumerable<object>>(query);
        }
    }
}