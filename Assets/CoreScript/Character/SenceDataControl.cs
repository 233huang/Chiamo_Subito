using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenceDataControl : Singleton<SenceDataControl>
{
    #region 通用
    public bool[] BoPian = new bool[20];
    #endregion


    #region 储藏室 
    public bool RightDoor = false;
    public bool BedroomDoor = false;

    public bool Picture = false;

    #endregion

    #region 顶楼三角杂货间
    public bool FrontDoor = false;
    public bool Painting = false;
    #endregion

    #region 二楼阳台
    public bool CatAppear = false;
    public bool Diary = false;
    #endregion

    #region 实验室
    public bool OverCoat = false;
    public bool GeRuiRoom = false;
    #endregion
}
