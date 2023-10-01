namespace Movielens.FaaS.IntegrationTest.Setup;

[CollectionDefinition(Name)]
public class IntegrationTestsCollection : ICollectionFixture<TestsInitializer>
{
    public const string Name = nameof(IntegrationTestsCollection);
}