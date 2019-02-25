﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections;
using System.Reflection;
using System.Linq.Expressions;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Helper methods for finding and instantiating objects through reflection.
    /// </summary>
    public static class TypeHelper
    {
        #region Fields

        private static List<Type> _scriptAssemblyTypes;
        private static Dictionary<string, List<Type>> _typeDictionary;

        #endregion

        #region Methods                

        /// <summary>
        /// Initializes the list of assembly types. 
        /// </summary>
        public static void InitializeAssemblyTypes()
        {
            _scriptAssemblyTypes = new List<Type>();
            _typeDictionary = new Dictionary<string, List<Type>>();

            // look for types in all assemblies
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                _scriptAssemblyTypes.AddRange(assembly.GetLoadableTypes().ToList());
            }

            // initialize dictionary
            foreach (var type in _scriptAssemblyTypes)
            {
                var key = type.Name;
                if (!_typeDictionary.ContainsKey(key))
                {
                    _typeDictionary.Add(key, new List<Type>());
                }

                _typeDictionary[key].Add(type);
            }

            // add common types to dictionary
            _typeDictionary.Add("string", new List<Type> { typeof(string) });
            _typeDictionary.Add("int", new List<Type> { typeof(int) });
            _typeDictionary.Add("bool", new List<Type> { typeof(bool) });
            _typeDictionary.Add("float", new List<Type> { typeof(float) });
        }

        /// <summary>
        /// Gets all types derived from specified base type.
        /// </summary>
        public static IEnumerable<Type> FindDerivedTypes(Type baseType)
        {
            if (_scriptAssemblyTypes == null)
            {
                InitializeAssemblyTypes();
            }

            var derivedTypes = new List<Type>();
            foreach (var type in _scriptAssemblyTypes)
            {
                if (baseType.IsAssignableFrom(type))
                {
                    derivedTypes.Add(type);
                }
            }
            return derivedTypes;
        }

        /// <summary>
        /// Extension method for getting loadable types from an assembly.
        /// </summary>
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if (assembly == null)
            {
                return Enumerable.Empty<Type>();
            }

            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        /// <summary>
        /// Instiantiates a type.
        /// </summary>
        public static object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }

        // TODO clean up
        public static void GetGenericType(string typeName)
        {
            if (_typeDictionary == null)
            {
                InitializeAssemblyTypes();
            }

            foreach (var type in _typeDictionary)
            {
                if (!type.Key.Contains(typeName))
                    continue;
                
                foreach (var t in type.Value)
                {
                    Debug.Log(t.Name + " | " + t.FullName);
                }
            }
        }

        /// <summary>
        /// Gets type with the specified name and namespace. 
        /// </summary>
        public static Type GetType(string typeName, string typeNamespace = null)
        {
            if (_typeDictionary == null)
            {
                InitializeAssemblyTypes();
            }

            List<Type> types;
            if (!_typeDictionary.TryGetValue(typeName, out types))
                return null;

            if (String.IsNullOrEmpty(typeNamespace))
            {
                return types.FirstOrDefault();
            }

            return types.FirstOrDefault(x => x.Namespace == typeNamespace);
        }

        #endregion
    }
}