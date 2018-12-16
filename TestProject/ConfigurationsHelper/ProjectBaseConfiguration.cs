using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace seleniumtestexample
{
    public static class ProjectBaseConfiguration
    {
        private static readonly string CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string DataDrivenFile
        {
            get
            {
                return Path.Combine(CurrentDirectory + ConfigurationHelper.Get<String>("DataDrivenFile"));
            }
        }

    }
}
