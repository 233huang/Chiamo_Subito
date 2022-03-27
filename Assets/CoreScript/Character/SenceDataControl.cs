using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SenceDataControl : Singleton<SenceDataControl>
{
    #region 通用
   
    private bool[] _BoPian = new bool[20];
    public bool[] BoPian {
        get { return _BoPian; }
        set
        {
            _BoPian = value;
            SendDate("_BoPian");
        }
    }
    
    #endregion

    #region 储藏室

    private bool _RightDoor = false;
    public bool RightDoor
    {
        get { return _RightDoor; }
        set
        {
            _RightDoor = value;
            SendDate("_RightDoor");
        }
    }

    private bool _BedroomDoor = false;
    public bool BedroomDoor
    {
        get { return _BedroomDoor; }
        set
        {
            _BedroomDoor = value;
            SendDate("_BedroomDoor");
        }
    }

    private bool _Picture = false;
    public bool Picture
    {
        get { return _Picture; }
        set
        {
            _Picture = value;
            SendDate("_Picture");
        }
    }

    private bool _BathroomDoor = false;
    public bool BathroomDoor
    {
        get { return _BathroomDoor; }
        set
        {
            _BathroomDoor = value;
            SendDate("_BathroomDoor");
        }
    }

    #endregion

    #region 顶楼三角杂货间

    private bool _FrontDoor = false;
    public bool FrontDoor
    {
        get { return _FrontDoor; }
        set
        {
            _FrontDoor = value;
            SendDate("_FrontDoor");
        }
    }

    private bool _Painting = false;
    public bool Painting
    {
        get { return _Painting; }
        set
        {
            _Painting = value;
            SendDate("_Painting");
        }
    }


    #endregion

    #region 二楼阳台

    private bool _CatAppear = false;
    public bool CatAppear
    {
        get { return _CatAppear; }
        set
        {
            _CatAppear = value;
            SendDate("_CatAppear");
        }
    }
    
    private bool _Diary = false;
    public bool Diary
    {
        get { return _Diary; }
        set
        {
            _Diary = value;
            SendDate("_Diary");
        }
    }
    
    #endregion

    #region 实验室
    
    private bool _OverCoat = false;
    public bool OverCoat
    {
        get { return _OverCoat; }
        set
        {
            _OverCoat = value;
            SendDate("_OverCoat");
        }
    }
    
    private bool _GeRuiRoom = false;
    public bool GeRuiRoom
    {
        get { return _GeRuiRoom; }
        set
        {
            _GeRuiRoom = value;
            SendDate("_GeRuiRoom");
        }
    }

    #endregion

    #region 格瑞房间

    private bool _Lock = false;
    public bool Lock
    {
        get { return _Lock; }
        set
        {
            _Lock = value;
            SendDate("_Lock");
        }
    }


    private bool _Paperball = false;
    public bool Paperball
    {
        get { return _Paperball; }
        set
        {
            _Paperball = value;
            SendDate("_Paperball");
        }
    }

    #endregion



    private BigBao bigBao;
    public struct BigBao
    {
        public bool[] BoPian;
        public bool RightDoor;
        public bool BedroomDoor;
        public bool Picture;
        public bool FrontDoor;
        public bool Painting;
        public bool CatAppear;
        public bool Diary;
        public bool OverCoat;
        public bool GeRuiRoom;
        public bool Lock;
    }


    public void SendDate(string s)
    {
        PlayerManager.instance.GetComponent<PhotonView>().RPC("UpdateDate", RpcTarget.Others,s);
    }

    public void ReciveDate(string s)
    {
        FieldInfo fieldInfo = this.GetType().GetField(s,BindingFlags.NonPublic | BindingFlags.Instance);
        fieldInfo.SetValue(this, true);

        //PropertyInfo propertyInfo = this.GetType().GetProperty(s);
        //propertyInfo.SetValue(this, true);
    }

}
