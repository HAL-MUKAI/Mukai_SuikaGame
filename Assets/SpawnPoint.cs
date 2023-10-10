using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    //�X�|�i�[���甭��������t���[�c
    [SerializeField] public GameObject[] fluitGameObjs;
    //�����_�����l�@0�`�t���[�c�z��
    [SerializeField] public int rondomNum;

    [SerializeField] Vector2 spawnPosShift;


    private void Start()
    {
        //�����_�����l�̏�����
        rondomNum = Random.Range(0, fluitGameObjs.Length);
    }


    public void Spawn()
    {
        //�t���[�c�z�񂩂烉���_�������o��
        Instantiate(fluitGameObjs[rondomNum], (Vector2)transform.position + spawnPosShift, Quaternion.identity);
        //�����_�����l�̍X�V
        rondomNum = Random.Range(0, fluitGameObjs.Length);
    }
}
