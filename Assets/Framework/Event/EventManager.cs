using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo { }
public class EventInfo : IEventInfo
{
    public UnityAction action;
}
public class EventInfo<T> : IEventInfo 
{ 
    public UnityAction<T> action;
}

public class EventManger : Singleton<EventManger>
{
    public Dictionary<string, IEventInfo> actionDic = new Dictionary<string, IEventInfo>();

    public void AddEventListener(string name,UnityAction action,bool single = true)
    {
        if (actionDic.ContainsKey(name) && single)
        {
            //重复注册，这种情况一般只有切换场景后的再次注册,删除原有的事件，进行覆盖
            actionDic.Remove(name);
        }

        if (actionDic.ContainsKey(name))
        {
            (actionDic[name] as EventInfo).action += action;
        }
        else
        {
            actionDic.Add(name, new EventInfo(){ action = action});
        }
    }

    public void AddEventListener<T>(string name, UnityAction<T> action, bool single = true)
    {
        if (actionDic.ContainsKey(name) && single)
        {
            //重复注册，这种情况一般只有切换场景后的再次注册,删除原有的事件，进行覆盖
            actionDic.Remove(name);
        }

        if (actionDic.ContainsKey(name))
        {
            (actionDic[name] as EventInfo<T>).action += action;
        }
        else
        {
            actionDic.Add(name, new EventInfo<T>() { action = action });
        }
    }

    public void RemoveEventListener(string name, UnityAction action)
    {
        if (actionDic.ContainsKey(name))
        {
            (actionDic[name] as EventInfo).action -= action;

            if ((actionDic[name] as EventInfo).action == null)
            {
                actionDic.Remove(name);
            }
        }
    }

    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (actionDic.ContainsKey(name))
        {
            (actionDic[name] as EventInfo<T>).action -= action;

            if ((actionDic[name] as EventInfo<T>).action == null)
            {
                actionDic.Remove(name);
            }
        }
    }

    public void TriggerEventListener(string name)
    {
        if (actionDic.ContainsKey(name))
        {
            (actionDic[name] as EventInfo).action?.Invoke();
        }
    }

    public void TriggerEventListener<T>(string name,T par)
    {
        if (actionDic.ContainsKey(name))
        {
            (actionDic[name] as EventInfo<T>).action?.Invoke(par);
        }
    }

    public bool ContainEvent(string name)
    {
        return actionDic.ContainsKey(name);
    }

    public void Clean()
    {
        actionDic.Clear();
    }
}
