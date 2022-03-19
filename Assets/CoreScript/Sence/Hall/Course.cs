using Com.MyCompany.MyGame;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class Course : MonoBehaviour
{
    #region Image
    public Image[] images;
    public Light2D light2D;
    #endregion

    private bool[] completes = new bool[5];
    private void Update()
    {
        if (Input.GetKey(KeyCode.A)&&!completes[0])
        {
            completes[0] = true;
            Destroy(images[0]);
        }
        if (Input.GetKey(KeyCode.D)&&!completes[1])
        {
            completes[1] = true;
            Destroy(images[1]);
        }
        if (Input.GetKey(KeyCode.E) && !completes[2])
        {
            completes[2] = true;
            Destroy(images[2]);
        }
        if (Input.GetKey(KeyCode.Y) && !completes[3])
        {
            completes[3] = true;
            Destroy(images[3]);
        }
        if (completes.All((b) => { return b == true; }))
        {
            light2D.intensity -= Time.deltaTime*0.5f;

            if(light2D.intensity <= 0)
            {
                if (PlayerManager.instance.CharacterID == 0)
                {
                    SenceLoadManager.instance.LoadSence("Level1", PlayerManager.instance.PlayerCreatVector["Level1"][0]);
                    Destroy(this);
                }
                if (PlayerManager.instance.CharacterID == 1)
                {
                    SenceLoadManager.instance.LoadSence("顶楼三角杂货间", PlayerManager.instance.PlayerCreatVector["顶楼三角杂货间"][0]);
                    Destroy(this);
                }
            }
        }

    }

    public void IsExit()
    {
        completes[4] = true;
        Destroy(images[4]);
    }
}
