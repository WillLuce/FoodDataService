using System;
using System.IO;
using System.Reflection;

namespace FoodDataService.Utils
{
    public static class StreamUtils
    {
        public static Stream GetResourceStream(Type scope, string resourceName, Assembly assembly = null)
        {
            scope.CheckNull(nameof(scope));
            resourceName.CheckNullOrEmpty(nameof(resourceName));

            resourceName = $"{scope.Namespace}.{resourceName}";
            assembly = scope?.GetTypeInfo().Assembly ?? Assembly.GetEntryAssembly();

            Stream result = assembly.GetManifestResourceStream(resourceName);
            if (result == null)
            {
                throw new ArgumentException($"Resource '{resourceName}' was not found");
            }
            return result;
        }

        public static string AsString(this Stream input, bool resetAfter = false)
        {
            string result = String.Empty;
            if (input != null && input.CanRead)
            {
                var sr = new StreamReader(input);
                result = sr.ReadToEnd();
                if (resetAfter)
                {
                    input.Seek(0, SeekOrigin.Begin);
                }
            }
            return result;
        }
    }
}
