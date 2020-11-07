using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Xunit;


namespace Waiting4Rain.ReflectonStudy
{
    public class ReadRepository01Tests
    {
        [Fact]
        public void Constructor_QueryRepositoryNull_ThrowsNullArgumentException()
        {
            var configuration = Substitute.For<IConfiguration>();

            Assert.Throws<ArgumentNullException>(() => new ReadRepository(null, configuration));
        }

        [Fact]
        public void Constructor_ConfigurationNull_ThrowsNullArgumentException()
        {
            var queryRepositoryFactory = Substitute.For<IQueryRepositoryFactory>();

            Assert.Throws<ArgumentNullException>(() => new ReadRepository(queryRepositoryFactory, null));
        }

        [Fact]
        public void Constructors_Throw_ArgumentNullException()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.ExportedTypes)
            {
                if (type.Name == "ReadRepository")
                {
                    IEnumerable<ConstructorInfo> ctors = type.GetTypeInfo().
                        DeclaredMembers.
                        Where(mi => mi is ConstructorInfo).
                        Select(mi => (ConstructorInfo)mi);
                    foreach (var ctor in ctors)
                    {
                        var parameters = ctor.GetParameters();
                        for (var i = 0; i < parameters.Length; i++)
                        {
                            Debug.WriteLine(parameters[i].Name);
                        }
                    }
                    var tr = ctors.ToList()[1].Invoke(new object[] { "HELLO" });
                    Debug.WriteLine("STOP");
                }
            }
        }
    }

    public class ReadRepository
    {
        private IQueryRepositoryFactory readRepository;
        private IConfiguration configuration;

        public ReadRepository(IQueryRepositoryFactory readRepository, IConfiguration configuration)
        {
            this.readRepository = readRepository;
            this.configuration = configuration;
        }
    }

    public interface IQueryRepositoryFactory
    {
    }

    public interface IConfiguration
    {
    }
}
