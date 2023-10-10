using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInput : MonoBehaviour
{
    #region �ϐ�

    //�X�|�i�[�̈ʒu�֘A
    [SerializeField] float moveSpeed;
    [SerializeField] float moveMaxLength;
    [SerializeField] float moveMinLength;


    [SerializeField,Header("���͂̑ҋ@���ԁi�b�j")] float inputInterval;
    bool allowInput = true; //���͂̋��t���O


    SpawnPoint spawnPoint;

    #endregion

    #region �萔
    //Horizontal�̃X�y���~�X�h�~�̒萔
    const string HORI = "Horizontal";
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GetComponent<SpawnPoint>();
    }


    private void Update()
    {
        if (Time.timeScale == 0)�@//�^�C���X�P�[��0�Ń��^�[���AFixed���Ɖ��̂��X�y�[�X�̔��肪�������̂�Update����̂���ŏ��������Ă܂��B
            return;

        SpaceToSpawn(); //�X�y�[�X�ŃX�|�[������
    }

    private void FixedUpdate()
    {
        if (Time.timeScale == 0) //Fixed��TimeScale�ɉe�����󂯂�̂ő�������񂯂ǂ���
            return;

        //�r���h������x���Ȃ����̂�Fixed�ɂ���
        MoveX(); //���E�̈ړ�
    }


    /// <summary>
    /// ���E���͂�moveSpeed��Transform��X���������܂��B
    /// </summary>
    void MoveX()
    {
        if (Input.GetAxisRaw(HORI) == 0)
        {
            return;
        }
        else if (Input.GetAxisRaw(HORI) > 0)
        {
            if (transform.position.x > moveMaxLength) //�ړ�����
                return;

            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }
        else
        {
            if(transform.position.x < moveMinLength) //�ړ�����
                return;

            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }

    }

    /// <summary>
    /// �X�y�[�X�L�[�ŃX�|�[���̏����������܂��B���s�{�̂�SpawnPoint�ɂ��܂��B
    /// </summary>
    void SpaceToSpawn()
    {
        if (!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown("joystick button 0")) //���������X�y�[�X������ĂȂ���������s���Ȃ��� ���ƃQ�[���p�b�h
            return;
        if (!allowInput) //�A�ő΍�
            return; 



        allowInput = false;�@//���t���O�𗎂Ƃ�
        StartCoroutine(SpawnKeyIntervalCount());�@//���t���O��߂��R���[�`��


        //���ۂ̃X�|�[������
        spawnPoint.Spawn();
        

    }

    IEnumerator SpawnKeyIntervalCount()
    {
        yield return new WaitForSeconds(inputInterval);
        allowInput = true;
    }
}