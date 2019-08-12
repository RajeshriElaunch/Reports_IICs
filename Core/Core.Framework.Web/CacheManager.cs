using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Web.Caching;
using System.Web;

namespace Core.Framework.Web
{
    public static class CacheManager
    {
        /// <summary>
        /// Gets the cache key for a particular method
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static string getCacheKey(params object[] parameters)
        {
            StackTrace stackTrace = new StackTrace();
            MethodBase methodBase = stackTrace.GetFrame(2).GetMethod();
            StringBuilder cacheKey = new StringBuilder();

            //the start of the key will be the full method namespace underscore the method name
            cacheKey.AppendFormat("{0}_{1}", methodBase.ReflectedType.FullName, methodBase.Name);

            //add any parameters as trailing values in the key
            if (parameters != null && parameters.Length > 0)
                foreach (object parameter in parameters)
                    cacheKey.AppendFormat("_{0}", parameter);

            //return the key we've generated
            return cacheKey.ToString();
        }

        /// <summary>
        /// Gets the cache key 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static string getCacheKey2(params object[] parameters)
        {
            StringBuilder cacheKey = new StringBuilder();
            cacheKey.Append("Hubble");

            //add any parameters as trailing values in the key
            if (parameters != null && parameters.Length > 0)
                foreach (object parameter in parameters)
                    cacheKey.AppendFormat("_{0}", parameter);

            //return the key we've generated
            return cacheKey.ToString();
        }

        /// <summary>
        /// Gets an item from the cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static T Get<T>(params object[] parameters)
        {
            //generate the "key" for the cached item
            string key = getCacheKey2(parameters);

            //set the return item to it's default
            T returnValue = default(T);

            //make sure the current http context is not null
            if (HttpContext.Current != null)
                if (HttpContext.Current.Cache.Get(key) != null)
                    returnValue = (T)HttpContext.Current.Cache.Get(key);

            //return the value
            return returnValue;
        }


        
        /// <summary>
        /// Adds the relevant item to the cache and returns it as well
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemToCache"></param>
        /// <param name="hoursToCache"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static T Add<T>(T itemToCache, int hoursToCache, params object[] parameters)
        {
            //generate the "key" for the cached item
            string key = getCacheKey2(parameters);

            //make sure the current http context is not null
            if (HttpContext.Current != null && itemToCache != null)
                HttpContext.Current.Cache.Add(key, itemToCache, null, DateTime.Now.AddHours(hoursToCache), TimeSpan.Zero, CacheItemPriority.BelowNormal, null);

            //return the cached item
            return itemToCache;
        }

        /// <summary>
        /// Reads all the settings and returns a list of them
        /// </summary>
        /// <returns></returns>
        public static List<Setting> ReadAll()
        {
            //try and get the list of items from the cache
            List<Setting> settings = CacheManager.Get<List<Setting>>();

            //if we found something in the cache, return it
            if (settings != null && settings.Count > 0)
                return settings;

            //if we get here, we haven't found anything so connect to the database and populate the list of settings from there, but first initialize the list
            settings = new List<Setting>();

            //now populate from the database
            //using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EngineDatabase"].ConnectionString))
            //{
            //    connection.Open();

            //    using (SqlCommand command = new SqlCommand("SettingReadAll", connection))
            //    {
            //        command.CommandType = System.Data.CommandType.StoredProcedure;

            //        using (SqlDataReader dataReader = command.ExecuteReader())
            //            while (dataReader.Read())
            //                settings.Add(populateSettingFromReader(dataReader));
            //    }

            //    connection.Close();
            //}

            //now add the list to the cache for 24 hours, and return it
            return CacheManager.Add<List<Setting>>(settings, 24);
        }

        /// <summary>
        /// Reads the setting for a specified setting name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Setting ReadByName(string name)
        {
            //get the value from the cache passing in the name as a parameter to generate the unique key
            Setting setting = CacheManager.Get<Setting>(name);

            if (setting != null)
                return setting;

            ////if we get here, we haven't found anything so connect to the database and populate the list of settings from there
            //using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EngineDatabase"].ConnectionString))
            //{
            //    connection.Open();

            //    using (SqlCommand command = new SqlCommand("SettingReadByName", connection))
            //    {
            //        command.CommandType = System.Data.CommandType.StoredProcedure;
            //        command.Parameters.Add(new SqlParameter("@Name", name));

            //        using (SqlDataReader dataReader = command.ExecuteReader())
            //            if (dataReader.Read())
            //                setting = populateSettingFromReader(dataReader);
            //    }

            //    connection.Close();
            //}

            //here I call the cache method passing in the "name" variable passed into this method as a parameter
            //which will be used as part of the cache key
            return CacheManager.Add<Setting>(setting, 24, name);
        }

        /// <summary>
        /// Setting entity
        /// </summary>
        public class Setting
        {
            /// <summary>
            /// Gets or sets the Id
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// Gets or sets the Name
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Gets or sets the Value
            /// </summary>
            public string Value { get; set; }
        }
    }
}
