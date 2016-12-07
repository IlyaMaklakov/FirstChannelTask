using System;
using System.Collections.Generic;
using System.Reflection;

namespace FirstChannelTask.Application
{
    public abstract class GenericFactory<TEnity>
    {
        public abstract TEnity GetObject(string type);
    }

    public class SearcherFactory : GenericFactory<BaseSearcher>
    {

        Dictionary<string, BaseSearcher> parsers = new Dictionary<string, BaseSearcher>();


        public SearcherFactory()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();


            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsSubclassOf(typeof(BaseSearcher)) && (!type.IsAbstract))
                {
                    var parser = Activator.CreateInstance(type) as BaseSearcher;
                    parsers.Add(parser.ToString(), parser);
                }
            }
        }

        public override BaseSearcher GetObject(string type)
        {
            return parsers[type];
        }
    }


}


