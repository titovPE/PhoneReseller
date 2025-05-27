using System;
using System.Collections.Generic;

namespace PhoneReseller
{
  public static class Cache
  {
    private static readonly Dictionary<Type, object> _cache = new Dictionary<Type,object>();

    public static void PutSingle<TEntity>(TEntity entity)
    {
      _cache[typeof(TEntity)] = entity;
    }

    public static TEntity GetSingle<TEntity>()
    {
      object result;
      _cache.TryGetValue(typeof(TEntity),out result);
      return (TEntity)result;
    }
  }
}
