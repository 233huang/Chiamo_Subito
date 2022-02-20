using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modular_One : MonoBehaviour
{
    [SerializeField]
    private Toggle[] toggles = new Toggle[4];
    [SerializeField]
    private GameObject[] Pointer = new GameObject[2];

    private int voltage = 165; //电压
    public int Voltage
    {
        get { return voltage; }
        set
        {
            JudgeComplete();
            voltage = value;
        }
    }

    private int electric = 70;//电流
    public int Electric
    {
        get { return electric; }
        set
        {
            JudgeComplete();
            electric = value;
        }
    }

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            toggles[i] = this.gameObject.transform.GetChild(i).GetComponent<Toggle>();
        }
        Pointer[0] = this.transform.GetChild(4).gameObject;
        Pointer[1] = this.transform.GetChild(5).gameObject;
        ToggleInit();

        SetToggleAble(false);
        EventManger.instance.AddEventListener<bool>("Box_Work", SetToggleAble);
    }

    private void SetToggleAble(bool b)
    {
        foreach (Toggle toggle in toggles)
        {
            toggle.interactable = b;
        }
    }

    private void ToggleInit()
    {
        toggles[0].onValueChanged.AddListener((b) =>
        {
            if (b)
            {
                Pointer[0].transform.localEulerAngles = new Vector3(0.0f, 0.0f, Pointer[0].transform.localEulerAngles.z-18);
                Voltage += 55;
            }
            else
            {
                Pointer[0].transform.localEulerAngles = new Vector3(0.0f, 0.0f, Pointer[0].transform.localEulerAngles.z + 18);
                Voltage -= 55;
            }
                
        });
        toggles[1].onValueChanged.AddListener((b) =>
        {
            if (b)
            {
                Pointer[0].transform.localEulerAngles = new Vector3(0.0f, 0.0f, Pointer[0].transform.localEulerAngles.z + 16);
                Voltage -= 50;
            }
            else
            {
                Pointer[0].transform.localEulerAngles = new Vector3(0.0f, 0.0f, Pointer[0].transform.localEulerAngles.z - 16);
                Voltage += 50;
            }
        });
        toggles[2].onValueChanged.AddListener((b) =>
        {
            if (b)
            {
                Electric -= 30;
                Pointer[1].transform.localEulerAngles = new Vector3(0.0f, 0.0f, Pointer[1].transform.localEulerAngles.z + 67);
            }
            else
            {
                Electric += 30;
                Pointer[1].transform.localEulerAngles = new Vector3(0.0f, 0.0f, Pointer[1].transform.localEulerAngles.z - 67);
            }
        });
        toggles[3].onValueChanged.AddListener((b) =>
        {
            if (b)
            {
                Pointer[1].transform.localEulerAngles = new Vector3(0.0f, 0.0f, Pointer[1].transform.localEulerAngles.z + 86);
                Electric -= 40;
            }
            else
            {
                Pointer[1].transform.localEulerAngles = new Vector3(0.0f, 0.0f, Pointer[1].transform.localEulerAngles.z - 86);
                Electric += 40;
            }
        });
    }

    private void JudgeComplete()
    {
        Debug.Log("v：" + Voltage + "e:" + Electric);
        if(Voltage == 220 && Electric == 30)
        {
            Electric_boxManager.instance.ModularOne = true;
        }
        else
        {
            Electric_boxManager.instance.ModularOne = false;
        }
    }
}
