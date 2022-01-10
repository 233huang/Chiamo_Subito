//读表，暂未写完


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleDatebase
{
    public int Id;
    public string Name;
    public string Des;
}


public class RoleTable : Singleton<RoleTable>
{
    Dictionary<int, RoleDatebase> _cache = new Dictionary<int, RoleDatebase>();

    public RoleTable()
    {
        
    }

    public RoleDatebase GetData(int id)
    {
        RoleDatebase db;
        _cache.TryGetValue(id, out db);
        return db;
    }

    public RoleDatebase this[int index]
    {
        get
        {
            RoleDatebase db;
            _cache.TryGetValue(index, out db);
            return db;
        }
    }
}
