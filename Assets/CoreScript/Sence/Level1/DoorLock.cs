using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public RectTransform[] gameObjects = new RectTransform[3];
    private bool isok =false;
    private bool yes = true;

    public GameObject Door;

    private void Update()
    {
        if (isok)
        {
            yes = true;
            for (int i = 0; i < 3; i++)
            {
                if (gameObjects[i].eulerAngles.z%360 < -4 || gameObjects[i].eulerAngles.z%360 > 4)
                {
                    if(gameObjects[i].eulerAngles.z % 360 < 356)
                        yes = false;
                }
            }
            if (yes)
            {
                isok = false;
                SenceDataControl.instance.RightDoor = true;
                Destroy(Door.GetComponent<OtherView_item>());
                Door.AddComponent<Level1_LoadNext>();
            }    
        }
    }
    private void OnEnable()
    {
        isok = true;
        if (SenceDataControl.instance.RightDoor)
        {
            SenceLoadManager.instance.LoadSence("二楼阳台", PlayerManager.instance.PlayerCreatVector["二楼阳台"][0]);
        }
    }

    public void DestoryThis()
    {
        if (SenceDataControl.instance.RightDoor)
            Destroy(this.gameObject);
    }
}
