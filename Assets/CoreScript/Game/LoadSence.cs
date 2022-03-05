using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSence : MonoBehaviour
{
    
    public void load1()
    {
        SenceLoadManager.instance.LoadSence("Hall", PlayerManager.instance.PlayerCreatVector["Hall"][0]);
    }
    public void load2()
    {
        SenceLoadManager.instance.LoadSence("Level1", PlayerManager.instance.PlayerCreatVector["Level1"][0]);
    }
    public void load3()
    {
        SenceLoadManager.instance.LoadSence("顶楼三角杂货间", PlayerManager.instance.PlayerCreatVector["顶楼三角杂货间"][0]);
    }
    public void load4()
    {
        SenceLoadManager.instance.LoadSence("二楼阳台", PlayerManager.instance.PlayerCreatVector["二楼阳台"][0]);
    }
    public void load5()
    {
        SenceLoadManager.instance.LoadSence("格瑞实验室", PlayerManager.instance.PlayerCreatVector["格瑞实验室"][0]);
    }
}
