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
            Type thisType = this.GetType();
            foreach (var handler in thisType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
            {
                var parameter = handler.GetParameters().First();
                Type parameterType = parameter.ParameterType;
                handlers.Add(parameterType, handler);
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
