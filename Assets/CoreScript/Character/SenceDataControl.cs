using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenceDataControl : Singleton<SenceDataControl>
{
    #region 储藏室
    public bool RightDoor = false;
    public bool BedroomDoor = false;
    #endregion

    #region 顶楼三角杂货间
    public bool FrontDoor = false;
    #endregion

    #region 二楼阳台
    public bool CatAppear = false;
    #endregion
}
