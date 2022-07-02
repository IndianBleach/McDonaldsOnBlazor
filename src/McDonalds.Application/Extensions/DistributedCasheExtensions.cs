using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace McDonaldsOnWeb.Application.Extensions
{
    public static class DistributedCasheExtensions
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cashe,
            string recordId,
            T value,
            TimeSpan? expireTime = null,
            TimeSpan? unusedExpireTime = null)
        {
            DistributedCacheEntryOptions opt = new()
            {
                AbsoluteExpirationRelativeToNow = expireTime ?? TimeSpan.FromSeconds(60),
                SlidingExpiration = unusedExpireTime
            };

            var json = JsonSerializer.Serialize(value);
            await cashe.SetStringAsync(recordId, json, opt);
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cashe,
            string recordId)
        {
            var json = await cashe.GetStringAsync(recordId);

            if (json is null) return default(T);

            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
