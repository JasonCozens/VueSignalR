using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Waiting4Rain.ReflectonStudy
{
    public class MemberRepository
    {
        public MemberRepository() { }
        public MemberRepository(object message, object configuration)
        {
            if (message == null) throw new ArgumentNullException("BLAH");
            Debug.WriteLine(message);
            Console.WriteLine("MESSAGE");
        }
    }

    public class MemberDataTests
    {
        private readonly ITestOutputHelper output;

        public MemberDataTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [MemberData(nameof(GetMembers), MemberType = typeof(MemberDataTests))]
        public void NullTests(Action<ITestOutputHelper> action)
        {
            action(output);
        }

        public static IEnumerable<object[]> GetMembers()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.ExportedTypes)
            {
                if (type.Name == $"{nameof(MemberRepository)}")
                {
                    var ctors = type.GetTypeInfo().
                        DeclaredMembers.
                        Where(mi => mi is ConstructorInfo).
                        Select(mi => (ConstructorInfo)mi);
                    foreach (var ctor in ctors)
                    {
                        Action<ITestOutputHelper> action = (output) =>
                        {
                            output.WriteLine($"{type.Name} - Default Constructor.");
                            ctor.Invoke(null);
                        };
                        if (ctor.GetParameters().Length == 2)
                        {
                            action = (output) =>
                            {
                                output.WriteLine($"{ctor.GetParameters()[1].Name}");
                                Assert.Throws<ArgumentNullException>(
                                   ctor.GetParameters()[1].Name,
                                   () => ctor.Invoke(new object[] { null, null }));
                            };
                        }
                        yield return new object[] { action };
                    }
                }
            }
        }

    }
}
