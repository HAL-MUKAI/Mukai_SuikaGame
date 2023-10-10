using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverLine : MonoBehaviour
{
    [SerializeField] GameObject gameoverCanvasPrefub;

    [SerializeField, Header("ゲームオーバー判定になっても待ってくれるフレーム数")] int gameOverWaitFlame;



    int countFlame;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Fluits")
        {
            countFlame++;
        }

        if(countFlame == gameOverWaitFlame)
        {
            StartCoroutine(GameOverColutin());
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Fluits")
        {
            countFlame = 0;
        }
    }

    IEnumerator GameOverColutin()
    {
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(1.5f);
        Instantiate(gameoverCanvasPrefub, new Vector3(0, 0, 0), Quaternion.identity);

    }
}
