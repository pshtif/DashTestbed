/*
 *	Created by:  Peter @sHTiF Stefcek
 */

using System;
using System.Reflection;

namespace Examples.Scripts
{
    public class ActionUtils
    {
        public static void ClearEvents(object p_instance)
        {
            var eventsToClear = p_instance.GetType().GetEvents(BindingFlags.Public | BindingFlags.NonPublic |
                                                               BindingFlags.Instance | BindingFlags.Static);

            foreach (var eventInfo in eventsToClear)
            {
                var fieldInfo = p_instance.GetType().GetField(
                    eventInfo.Name, 
                    BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            
                if (fieldInfo.GetValue(p_instance) is Delegate eventHandler)
                    foreach (var invocatedDelegate in eventHandler.GetInvocationList())
                        eventInfo.GetRemoveMethod(fieldInfo.IsPrivate).Invoke(
                            p_instance, 
                            new object[] { invocatedDelegate });
            }
        }
    }
}