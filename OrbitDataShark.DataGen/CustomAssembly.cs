﻿using System.Reflection;
using System.Reflection.Emit;
using OrbitDataShark.DataGen.Models;

namespace OrbitDataShark.DataGen
{
    internal class CustomAssembly
    {
        private static CustomAssembly? _instance;
        private AssemblyBuilder AssemblyBuilder { get; }
        private ModuleBuilder ModuleBuilder { get; }
        private AssemblyName AssemblyName { get; }
        private const string _assemblyName = "OrbitDataShark.Emit";
        private CustomAssembly()
        {
            AssemblyName = new AssemblyName("OrbitDataShark.CodeGet.Il");
            AssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(AssemblyName,
                AssemblyBuilderAccess.RunAndCollect);
            ModuleBuilder = AssemblyBuilder.DefineDynamicModule(AssemblyName + ".TypeDef");
        }

        public TypeBuilder DefineType(string typeName, TypeAttributes attributes)
        {
            var builder = ModuleBuilder.DefineType($"{CustomAssembly._assemblyName}.{typeName}", attributes);
            builder.SetParent(typeof(GeneratedType));
            return builder;
        }
        public static CustomAssembly Instance {
            get {
                _instance ??= new CustomAssembly();
                return _instance;
            }
        }
    }
}

