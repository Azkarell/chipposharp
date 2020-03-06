using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Chippo.Core.Resources
{
    public class ResourceLoader
    {
        private readonly Assembly assembly = Assembly.GetCallingAssembly();

        public ResourceLoader()
        {
        }

        public ResourceLoader(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public Stream Load(string name)
        {
            foreach (var manifestResourceName in assembly.GetManifestResourceNames())
            {
                if (manifestResourceName.Contains(name))
                {
                    return assembly.GetManifestResourceStream(manifestResourceName);
                }
            }
            throw new KeyNotFoundException($"Resource {name} not found" );
        }
    }
}