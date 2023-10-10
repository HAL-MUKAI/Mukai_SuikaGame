using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ʂ̃t���[�c���X�|�[��������X�N���v�g�ł��B
/// </summary>

public class FluitsCollisionSpawner : MonoBehaviour
{
    public static FluitsCollisionSpawner instance;


    int fluitCount; //���ꂪ�Q�ŃX�|�[��������

    [SerializeField, Header("�X�|�[������AddForce")] Vector2 spawnAddForcePower;
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
    /// �Q�ǌĂԂƂP��̃t���[�c�����ہ[�񂳂��܂�
    /// </summary>
    /// <param name="pos">���g�̏ꏊ����������</param>
    /// <param name="myFluit">���g�̃t���[�c�����������A��������̂͂P��̂ӂ�[�ɂȂ�܂��B</param>
    public void FluitSpawn(Vector2 pos, FluitCont.Fluit myFluit)
    {
        fluitCount++;
        if(fluitCount == 2) 
        {
            fluitCount = 0;

            GameObject newObj = null ;

            switch (myFluit)
            {
                case FluitCont.Fluit.��������:
                    newObj = Instantiate(fluitsGameObject.strawberry, pos, transform.rotation) as GameObject;
                    break;
                case FluitCont.Fluit.������:
                    newObj = Instantiate(fluitsGameObject.budou, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.�Ԃǂ�:
                    newObj = Instantiate(fluitsGameObject.dekopon, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.�f�R�|��:
                    newObj = Instantiate(fluitsGameObject.orange, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.�I�����W:
                    newObj = Instantiate(fluitsGameObject.apple, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.���:
                    newObj = Instantiate(fluitsGameObject.nashi, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.��:
                    newObj = Instantiate(fluitsGameObject.peach, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.��:
                    newObj = Instantiate(fluitsGameObject.pine, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.�p�C�i�b�v��:
                    newObj = Instantiate(fluitsGameObject.melon, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.������:
                    newObj = Instantiate(fluitsGameObject.waterMelon, pos, Quaternion.identity);
                    break;
                case FluitCont.Fluit.�X�C�J:
                    Debug.Log("�X�C�J�̓f�X�g���[�C�I�I");
                    break;


            }

            Rigidbody2D r = newObj.GetComponent<Rigidbody2D>();
            r.AddForce(spawnAddForcePower);

        }

    }
}
