using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// 基于插件的相机跟随人物绑定
/// </summary>
public class Camera_Follow : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        /*if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            this.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.FindGameObjectWithTag("Player").transform;
            Destroy(this);
        }*/

        if (PlayerManager.instance.CharacterID == 0)
        {
            this.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("LiAng(Clone)").transform;
            Destroy(this);
        }

        if (PlayerManager.instance.CharacterID == 1)
        {
            this.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("LiLiAn(Clone)").transform;
            Destroy(this);
        }
    }
}
