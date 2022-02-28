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
                Destroy(Door.GetComponent<OtherView_item>());
                Door.AddComponent<Level1_LoadNext>();
            }    
        }
    }
    private void OnEnable()
    {
        isok = true;
    }
}
