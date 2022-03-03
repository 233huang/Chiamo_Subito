using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera_Follow : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            this.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.FindGameObjectWithTag("Player").transform;
            Destroy(this);
        }
        else
        {
            Debug.Log("??");
        }
    }
}
