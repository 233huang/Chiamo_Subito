using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelf_item : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine("delete");
    }

    IEnumerator delete()
    {
        yield return new WaitForSeconds(6f);
        this.gameObject.SetActive(false);
    }
}
