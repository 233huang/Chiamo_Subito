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

    public void AddEventListener(string name,UnityAction action)
    {
        if (actionDic.ContainsKey(name))
        {
            (actionDic[name] as EventInfo).action += action;
        }
        else
        {
            actionDic.Add(name, new EventInfo(){ action = action});
        }
    }

    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
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
        }
    }

    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (actionDic.ContainsKey(name))
        {
            (actionDic[name] as EventInfo<T>).action -= action;
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

    public void Clean()
    {
        actionDic.Clear();
    }
}
