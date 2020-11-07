using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace Waiting4Rain.ReflectonStudy
{
    public class CtorFixture
    {
        public CtorFixture()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.ExportedTypes)
            {
                if (type.Name == "TestRepository")
                {
                    Constructors = type.GetTypeInfo().
                        DeclaredMembers.
                        Where(mi => mi is ConstructorInfo).
                        Select(mi => (ConstructorInfo)mi);
                }
            }
        }

        public IEnumerable<ConstructorInfo> Constructors { get; private set; }
    }

    public class ClassFixtureTests : IClassFixture<CtorFixture>
    {
        public ClassFixtureTests(CtorFixture fixture)
        {
            Fixture = fixture;
        }

        public CtorFixture Fixture { get; }

        [Theory]
        [InlineData("CTOR")]
        public void CtorTest(string ctor)
        {
           Debug.WriteLine(Fixture.Constructors.Count());
        }

    }
}
