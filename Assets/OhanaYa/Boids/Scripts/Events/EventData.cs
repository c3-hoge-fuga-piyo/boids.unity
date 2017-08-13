using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

using System;

namespace OhanaYa.Boids.Events
{
    public abstract class BaseEvetnData<T> : BaseEventData
        where T : BaseEvetnData<T>, new()
    {
        protected static readonly T cachedInstance = new T();

        #region Constructors
        protected BaseEvetnData() : base(null) {}
        #endregion
    }

    public sealed class EventData<T1> : BaseEvetnData<EventData<T1>>
    {
        public static EventData<T1> Get(T1 item1)
        {
            cachedInstance.Item1 = item1;
            return cachedInstance;
        }

        public T1 Item1 { get; private set; }
    }

    public sealed class EventData<T1, T2> : BaseEvetnData<EventData<T1, T2>>
    {
        public static EventData<T1, T2> Get(T1 item1, T2 item2)
        {
            cachedInstance.Item1 = item1;
            cachedInstance.Item2 = item2;
            return cachedInstance;
        }

        public T1 Item1 { get; private set; }
        public T2 Item2 { get; private set; }
    }

    public sealed class EventData<T1, T2, T3> : BaseEvetnData<EventData<T1, T2, T3>>
    {
        public static EventData<T1, T2, T3> Get(T1 item1, T2 item2, T3 item3)
        {
            cachedInstance.Item1 = item1;
            cachedInstance.Item2 = item2;
            cachedInstance.Item3 = item3;
            return cachedInstance;
        }

        public T1 Item1 { get; private set; }
        public T2 Item2 { get; private set; }
        public T3 Item3 { get; private set; }
    }

    public sealed class EventData<T1, T2, T3, T4> : BaseEvetnData<EventData<T1, T2, T3, T4>>
    {
        public static EventData<T1, T2, T3, T4> Get(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            cachedInstance.Item1 = item1;
            cachedInstance.Item2 = item2;
            cachedInstance.Item3 = item3;
            cachedInstance.Item4 = item4;
            return cachedInstance;
        }

        public T1 Item1 { get; private set; }
        public T2 Item2 { get; private set; }
        public T3 Item3 { get; private set; }
        public T4 Item4 { get; private set; }
    }

    public static class EventData
    {
        public static EventData<T1> Get<T1>(T1 item1)
            => EventData<T1>.Get(item1);

        public static EventData<T1, T2> Get<T1, T2>(T1 item1, T2 item2)
            => EventData<T1, T2>.Get(item1, item2);

        public static EventData<T1, T2, T3> Get<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
            => EventData<T1, T2, T3>.Get(item1, item2, item3);

        public static EventData<T1, T2, T3, T4> Get<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
            => EventData<T1, T2, T3, T4>.Get(item1, item2, item3, item4);
    }
}