using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    //スポナーから発生させるフルーツ
    [SerializeField] public GameObject[] fluitGameObjs;
    //ランダム数値　0～フルーツ配列分
    [SerializeField] public int rondomNum;

    [SerializeField] Vector2 spawnPosShift;


    private void Start()
    {
        //ランダム数値の初期化
        rondomNum = Random.Range(0, fluitGameObjs.Length);
    }


    public void Spawn()
    {
        //フルーツ配列からランダムを取り出す
        Instantiate(fluitGameObjs[rondomNum], (Vector2)transform.position + spawnPosShift, Quaternion.identity);
        //ランダム数値の更新
        rondomNum = Random.Range(0, fluitGameObjs.Length);
    }
}
