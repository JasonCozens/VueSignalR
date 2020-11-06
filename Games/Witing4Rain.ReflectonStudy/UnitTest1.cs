using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Xunit;

namespace Witing4Rain.ReflectonStudy
{
    public class UnitTest1
    {
        [Fact]
        public void TestListAssemblies()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                Debug.WriteLine(assembly.FullName);
            }
        }

        [Fact]
        public void DumpAssemblyInfo()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                Debug.WriteLine($"Assembly: ${assembly}");

                if (assembly.IsDynamic)
                {
                    Debug.WriteLine("    Dynamic assembly");
                }
                else
                {
                    foreach (var t in assembly.ExportedTypes)
                    {
                        Debug.WriteLine($"    Type: {t}");

                        foreach (var memberInfo in t.GetTypeInfo().DeclaredMembers)
                        {
                            //var typeNameMap = new Dictionary<MemberInfo, string>
                            //{
                            //    { typeof(Type), "(Nested) Type" },
                            //    { typeof(FieldInfo), "FieldInfo" },
                            //    { typeof(MethodInfo), "MethodInfo" },
                            //    { typeof(ConstructorInfo), "ConstructorInfo" },
                            //    { typeof(PropertyInfo), "PropertyInfo" },
                            //    { typeof(EventInfo), "EventInfo" }
                            //};
                            //if (typeNameMap.ContainsKey(memberInfo))
                            //{
                            //    Debug.WriteLine($"        {typeNameMap[memberInfo]}: {memberInfo}");
                            //}
                            Debug.WriteLine($"        {memberInfo.GetType().BaseType.Name}: {memberInfo}");
                        }
                    }
                }
            }
        }
    }
}
