using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VisitedPlaces.Shared
{
    public class Common
    {
        private static readonly Lazy<string?> _exePath_Lazy = new Lazy<string?>(() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        public static string ExePath => _exePath_Lazy.Value ?? "";
    }
}
