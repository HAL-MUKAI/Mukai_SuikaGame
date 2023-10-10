using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 上位のフルーツをスポーンさせるスクリプトです。
/// </summary>

public class FluitsCollisionSpawner : MonoBehaviour
{
    public static FluitsCollisionSpawner instance;


    int fluitCount; //これが２でスポーンさせる

    [SerializeField, Header("スポーン時のAddForce")] Vector2 spawnAddForcePower;
    [Serializable]public struct FluitsGameObject
    {
       public GameObject cherryObj, strawberry, budou, dekopon, orange, apple, nashi, peach, pine, melon, waterMelon;
    }
    
    public FluitsGameObject fluitsGameObject;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    /// <summary>
    /// ２ど呼ぶと１つ上のフルーツをすぽーんさせます
    /// </summary>
    /// <param name="pos">自身の場所をください</param>
    /// <param name="myFluit">自身のフルーツをください、生成するのは１つ上のふるーつになります。</param>
    public void FluitSpawn(Vector2 pos, FluitCont.Fluit myFluit)
    {
        fluitCount++;
        if(fluitCount == 2) 
        {
            fluitCount = 0;

            GameObject newObj = null ;

            switch (myFluit)
            {
                case FluitCont.Fluit.さくらんぼ:
                    newObj = Instantiate(fluitsGameObject.strawberry, pos, transform.rotation) as GameObject;
                    break;
                case FluitCont.Fluit.いちご:
                    newObj = Instantiate(fluitsGameObject.budou, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.ぶどう:
                    newObj = Instantiate(fluitsGameObject.dekopon, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.デコポン:
                    newObj = Instantiate(fluitsGameObject.orange, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.オレンジ:
                    newObj = Instantiate(fluitsGameObject.apple, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.りんご:
                    newObj = Instantiate(fluitsGameObject.nashi, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.梨:
                    newObj = Instantiate(fluitsGameObject.peach, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.桃:
                    newObj = Instantiate(fluitsGameObject.pine, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.パイナップル:
                    newObj = Instantiate(fluitsGameObject.melon, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.メロン:
                    newObj = Instantiate(fluitsGameObject.waterMelon, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.スイカ:
                    Debug.Log("スイカはデストローイ！！");
                    break;


            }

            Rigidbody2D r = newObj.GetComponent<Rigidbody2D>();
            r.AddForce(spawnAddForcePower);

        }

    }
}
