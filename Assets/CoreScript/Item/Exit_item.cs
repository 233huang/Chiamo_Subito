using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit_item : MonoBehaviour
{
    private Button exit;
    private void Start()
    {
        exit = this.GetComponent<Button>();
        exit.onClick.AddListener(() =>
        {
            PlayerManager.instance.SetLight_Item(1, false);
        });
    }
}
