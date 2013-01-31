using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;

namespace DotNet.Common
{
    public class Ioc
    {
        private static UnityContainer _container;

        public static UnityContainer Container
        {
            get { return _container; }
        }

        public static void InitUntiy(String configPath)
        {
            ExeConfigurationFileMap exeConfigMap = new ExeConfigurationFileMap();
            exeConfigMap.ExeConfigFilename = configPath;

            Configuration unityConfig = ConfigurationManager.OpenMappedExeConfiguration(exeConfigMap, ConfigurationUserLevel.None);
            UnityConfigurationSection unitySection = (UnityConfigurationSection)unityConfig.GetSection("unity");            

            _container = new UnityContainer();
            unitySection.Configure(_container);
            
        }

        public static T Resolve<T>(params ResolverOverride[] overrides)
        {
            return _container.Resolve<T>(overrides);
        }

        public static T Resolve<T>(string name, params ResolverOverride[] overrides)
        {
            return _container.Resolve<T>(name, overrides);
        }

        public static object Resolve(Type t, params ResolverOverride[] overrides)
        {
            return _container.Resolve(t, overrides);
        }

        public static object Resolve(Type t, string name, params ResolverOverride[] overrides)
        {
            return _container.Resolve(t, name, overrides);
        }
    }
}
