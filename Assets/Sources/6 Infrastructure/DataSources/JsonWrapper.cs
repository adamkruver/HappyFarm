using System;

namespace HappyFarm.Infrastructure.Sources._6_Infrastructure.DataSources
{
    [Serializable]
    public class JsonWrapper<T>
    {
        public T[] Collection;
    }
}