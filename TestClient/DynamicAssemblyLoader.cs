using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Reflection;

namespace Neuron.TestClient
{
    public class DynamicAssemblyLoader
    {
        // Holds references to loaded assembly files.
        public static Hashtable AssemblyReferences = new Hashtable();

        // Holds and instance of a class and it's type.
        public class DynamicClassInfo
        {
            public Type type;
            public Object ClassObject;

            public DynamicClassInfo() { }

            public DynamicClassInfo(Type t, Object c)
            {
                type = t;
                ClassObject = c;
            }
        }

        public static DynamicClassInfo GetClassReference(string AssemblyName, string ClassName)
        {
            Assembly assembly;
            // Determine if a cached assembly can be used.
            if (AssemblyReferences.ContainsKey(AssemblyName) == false)
            {
                AssemblyReferences.Add(AssemblyName, assembly = Assembly.LoadFrom(AssemblyName));
            }
            else assembly = (Assembly)AssemblyReferences[AssemblyName];

            // Walk through each class type in the assembly and look for a class match
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass == true)
                {
                    // Must match the full class name
                    if(type.FullName == ClassName)
                    {
                        DynamicClassInfo ci = new DynamicClassInfo(type, Activator.CreateInstance(type));
                        return (ci);
                    }
                }
            }
            throw (new System.Exception("Could not instantiate class " + ClassName + ". It may not exist in the assembly."));
        }

        public static Object InvokeMethod(DynamicClassInfo ci, string MethodName, Object[] args)
        {
            // Dynamically Invoke the method
            Object Result = ci.type.InvokeMember(MethodName, BindingFlags.Default | BindingFlags.InvokeMethod, null, ci.ClassObject, args);
            return (Result);
        }

        public static Object InvokeMethod(string AssemblyName, string ClassName, string MethodName, Object[] args)
        {
            DynamicClassInfo ci = GetClassReference(AssemblyName, ClassName);
            return (InvokeMethod(ci, MethodName, args));
        }

        public static Object InvokeMethodSlow(string AssemblyName, string ClassName, string MethodName, Object[] args)
        {
            Assembly assembly = Assembly.LoadFrom(AssemblyName);

            // Walk through each type in the assembly looking for the class
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass == true)
                {
                    if (type.FullName == ClassName)
                    {
                        object ClassObj = Activator.CreateInstance(type);

                        object Result = type.InvokeMember(MethodName, BindingFlags.Default | BindingFlags.InvokeMethod, null, ClassObj, args);
                        return (Result);
                    }
                }
            }
            throw (new Exception("Could not invoke method"));
        }
    }

}

