using Com.MyCompany.MyGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackAnim : MonoBehaviour
{
    public GameObject LiAngAnim;
    public GameObject LiLiAnAnim;
    public GameObject huichen;
    public GameManager gameManager;
    public GameObject dialog;

    private PlayerManager playerManager;

    private void Start()
    {
        playerManager = PlayerManager.instance;
    }

    private void Update()
    {
        if (playerManager.PlayerScenes[0] == playerManager.PlayerScenes[1])
            this.GetComponent<Animator>().enabled = true;
    }

    public void ShowPlayer()
    {
            LiAngAnim.SetActive(true);
            LiLiAnAnim.SetActive(true);
        StartCoroutine(showHuiChen());
    }

    IEnumerator showHuiChen()
    {
        yield return new WaitForSeconds(0.6f);
        huichen.SetActive(true);
        yield return new WaitForSeconds(1f);
        dialog.SetActive(true);
        gameManager.InstanticPlayer();
        Destroy(this.transform.parent.gameObject);
    }
}
