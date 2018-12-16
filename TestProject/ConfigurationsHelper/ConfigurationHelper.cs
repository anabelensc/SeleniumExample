using System;
using System.Configuration;


namespace seleniumtestexample
{
    public static class ConfigurationHelper
    {
        public static T Get<T>(String name)
        {
            var value = ConfigurationManager.AppSettings[name];
            if (typeof(T).IsEnum)
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}

