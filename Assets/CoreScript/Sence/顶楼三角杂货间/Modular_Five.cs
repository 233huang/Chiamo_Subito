using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modular_Five : MonoBehaviour
{
    private Vector3 start;
    public GameObject target;
    public float speed;
    private bool Down = false;
    private bool Up = false;

    private void Start()
    {
        start = this.transform.position;
        //target = new Vector3(this.transform.position.x, this.transform.position.y - 50, this.transform.position.z);
    }
    public void PullDown()
    {
        if (!Electric_boxManager.instance.Work)
        {
            Electric_boxManager.instance.Work = true;
            Up = false;
            Down = true;
        }
        else
        {
            if(Electric_boxManager.instance.ModularFour)
            {
                PlayerManager.instance.GetComponent<PhotonView>().RPC("SetLight", RpcTarget.All, "level1", 1f);
                PlayerManager.instance.GetComponent<PhotonView>().RPC("SetLight", RpcTarget.All, "杂货间", 1f);
            }
            else
            {
                Electric_boxManager.instance.Work = false;
            }
            Up = true;
            Down = true;
        }
    }

    private void Update()
    {
        if (Down)
        {
            if(!Up)
                this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, speed * Time.deltaTime);
            else
                this.transform.position = Vector3.Lerp(this.transform.position, start, speed * Time.deltaTime);
            if (this.transform.position == target.transform.position)
                Down = false;
        }
    }
}
