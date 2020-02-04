using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace Orgella.Infrastructure
{
    public static class SessionExtensions
    {
        // marametry metody SetJson to parametry które przyjmuje metoda SetString !
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        //parametry metody GetJson to parametry które przyjmuje metoga GetString
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}
