using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanBathRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SenceDataControl.instance.BathroomDoor = true;
    }
}
