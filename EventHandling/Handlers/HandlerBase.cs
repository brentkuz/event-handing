using EventHandling.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EventHandling.Handlers
{
    public abstract class HandlerBase : IHandler
    {
        protected Dictionary<Type, MethodInfo> handlers = new Dictionary<Type, MethodInfo>();

        public HandlerBase()
        {
            //Register event handler methods on instance.
            //Public methods with a single parameter that is derived from EventBase.
            Type thisType = this.GetType();
            foreach (var handler in thisType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
            {
                var parameters = handler.GetParameters();
                Type parameterType = parameters.First().ParameterType;
                if (parameterType.IsSubclassOf(typeof(EventBase)) && parameters.Count() == 1)
                {
                    handlers.Add(parameterType, handler);
                }
            }
        }

        public void Handle(EventBase e)
        {
            Type eventType = e.GetType();
            if (handlers.ContainsKey(eventType))
            {
                handlers[eventType].Invoke(this, new object[] { e });
            }               
        }
    }
    
}
