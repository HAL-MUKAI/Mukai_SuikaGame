using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FluitCont : MonoBehaviour
{
    public enum Fluit
    {
        さくらんぼ,
        いちご,
        ぶどう,
        デコポン,
        オレンジ,
        りんご,
        梨,
        桃,
        パイナップル,
        メロン,
        スイカ
    }

    public Fluit myFluit;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Fluits") //フルーツでなければ無効
            return;

        if(collision.gameObject.GetComponent<FluitCont>().myFluit == myFluit)
        {
            Destroy(gameObject);
            FluitsCollisionSpawner.instance.FluitSpawn(transform.position, myFluit);
        }
    }
}
