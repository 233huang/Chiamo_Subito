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
            Debug.Log("x");
            Electric_boxManager.instance.Work = false;
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
