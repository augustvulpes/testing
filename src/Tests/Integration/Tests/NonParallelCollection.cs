using Xunit;

namespace LibraryApp.Tests.Integration.Tests
{
    [CollectionDefinition(nameof(NonParallelCollection), DisableParallelization = true)]
    public class NonParallelCollection
    {
    }
}
