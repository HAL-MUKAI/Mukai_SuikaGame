using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FluitCont : MonoBehaviour
{
    public enum Fluit
    {
        ��������,
        ������,
        �Ԃǂ�,
        �f�R�|��,
        �I�����W,
        ���,
        ��,
        ��,
        �p�C�i�b�v��,
        ������,
        �X�C�J
    }

    public Fluit myFluit;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Fluits") //�t���[�c�łȂ���Ζ���
            return;

        if(collision.gameObject.GetComponent<FluitCont>().myFluit == myFluit)
        {
            Destroy(gameObject);
            FluitsCollisionSpawner.instance.FluitSpawn(transform.position, myFluit);
        }
    }
}
