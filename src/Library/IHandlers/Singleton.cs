using System;

namespace Library
{
    /// <summary>
    /// Se usa en los handlers que requieren la utilización del patron singleton.
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : new ()
    {
        private static T instance; 
        public static T Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new T(); 
                }
                return instance;
            }
        }
    }
}