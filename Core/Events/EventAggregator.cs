namespace Core.Events
{


    public static class EventAggregator
    {
        public static void Subscribe<TEvent>(System.Action<object, TEvent> eventHandler)
        {
            EventHolder<TEvent>.Event += eventHandler;
        }

        public static void Unsubscribe<TEvent>(System.Action<object, TEvent> eventHandler)
        {
            EventHolder<TEvent>.Event -= eventHandler;
        }

        public static void Post<TEvent>(object sender, TEvent eventData)
        {
            EventHolder<TEvent>.Post(sender, eventData);
        }

        private static class EventHolder<T>
        {
            public static event System.Action<object, T> Event;

            public static void Post(object sender, T eventData)
            {
                Event?.Invoke(sender, eventData);
            }
        }
    }
}