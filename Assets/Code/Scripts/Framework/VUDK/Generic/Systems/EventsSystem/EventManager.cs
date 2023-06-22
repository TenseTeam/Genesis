namespace VUDK.Generic.Systems.EventsSystem
{
    using System;
    using System.Collections.Generic;

    public static class EventManager
    {
        private static Dictionary<string, Delegate> s_EventListeners = new Dictionary<string, Delegate>();

        public static void AddListener(string eventKey, Action listener)
        {
            RegisterEvent(eventKey, listener);
        }

        public static void AddListener<T>(string eventKey, Action<T> listener)
        {
            RegisterEvent(eventKey, listener);
        }

        public static void AddListener<T1, T2>(string eventKey, Action<T1, T2> listener)
        {
            RegisterEvent(eventKey, listener);
        }

        public static void RemoveListener(string eventKey, Action listener)
        {
            UnregisterEvent(eventKey, listener);
        }

        public static void RemoveListener<T>(string eventKey, Action<T> listener)
        {
            UnregisterEvent(eventKey, listener);
        }

        public static void RemoveListener<T1, T2>(string eventKey, Action<T1, T2> listener)
        {
            UnregisterEvent(eventKey, listener);
        }

        public static void TriggerEvent(string eventKey)
        {
            if (s_EventListeners.ContainsKey(eventKey))
            {
                Action del = s_EventListeners[eventKey] as Action;
                del.Invoke();
            }
        }

        public static void TriggerEvent<T>(string eventKey, T parameter)
        {
            if (s_EventListeners.ContainsKey(eventKey))
            {
                Action<T> del = s_EventListeners[eventKey] as Action<T>;
                del.Invoke(parameter);
            }
        }

        public static void TriggerEvent<T1, T2>(string eventKey, T1 param1, T2 param2)
        {
            if (s_EventListeners.ContainsKey(eventKey))
            {
                Action<T1, T2> del = s_EventListeners[eventKey] as Action<T1, T2>;
                del.Invoke(param1, param2);
            }
        }

        private static void RegisterEvent(string eventKey, Delegate listener)
        {
            if (s_EventListeners.ContainsKey(eventKey))
                s_EventListeners[eventKey] = Delegate.Combine(s_EventListeners[eventKey], listener);
            else
                s_EventListeners.Add(eventKey, listener);
        }

        private static void UnregisterEvent(string eventKey, Delegate listener)
        {
            if (s_EventListeners.ContainsKey(eventKey))
                s_EventListeners[eventKey] = Delegate.Remove(s_EventListeners[eventKey], listener);
        }
    }
}
