using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Factory1
{
    internal class Factory<I> where I : class
    {
        private static Dictionary<string, Type> typeMap;

        static Factory()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes()
                        .Where(t => t.IsClass
                               && t.GetCustomAttribute<DialogFactoryAttribute>() != null
                               && t.GetInterfaces().Any(t2=>t2 == typeof(I)));

            typeMap = new Dictionary<string, Type>();
            foreach (var type in types)
            {
                var att = type.GetCustomAttribute<DialogFactoryAttribute>();
                typeMap.Add(att.Designator, type);
            }
        }

        public I Create(string name)
        {
            typeMap.TryGetValue(name, out var type);
            if (type == null)
            {
                throw new Exception($"Factory cannot create type of for type designator {name}.");
            }
            var result = Activator.CreateInstance(type);
            return result as I;
        }
    }
}
