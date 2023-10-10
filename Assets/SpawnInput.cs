using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInput : MonoBehaviour
{
    #region 変数

    //スポナーの位置関連
    [SerializeField] float moveSpeed;
    [SerializeField] float moveMaxLength;
    [SerializeField] float moveMinLength;


    [SerializeField,Header("入力の待機時間（秒）")] float inputInterval;
    bool allowInput = true; //入力の許可フラグ


    SpawnPoint spawnPoint;

    #endregion

    #region 定数
    //Horizontalのスペルミス防止の定数
    const string HORI = "Horizontal";
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GetComponent<SpawnPoint>();
    }


    private void Update()
    {
        if (Time.timeScale == 0)　//タイムスケール0でリターン、Fixedだと何故かスペースの判定が怪しいのでUpdateからのこれで処理させてます。
            return;

        SpaceToSpawn(); //スペースでスポーン処理
    }

    private void FixedUpdate()
    {
        if (Time.timeScale == 0) //FixedはTimeScaleに影響を受けるので多分いらんけどつける
            return;

        //ビルドしたら遅くなったのでFixedにした
        MoveX(); //左右の移動
    }


    /// <summary>
    /// 左右入力でmoveSpeed文TransformのXを加減します。
    /// </summary>
    void MoveX()
    {
        if (Input.GetAxisRaw(HORI) == 0)
        {
            return;
        }
        else if (Input.GetAxisRaw(HORI) > 0)
        {
            if (transform.position.x > moveMaxLength) //移動制限
                return;

            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }
        else
        {
            if(transform.position.x < moveMinLength) //移動制限
                return;

            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }

    }

    /// <summary>
    /// スペースキーでスポーンの処理をさせます。実行本体はSpawnPointにいます。
    /// </summary>
    void SpaceToSpawn()
    {
        if (!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown("joystick button 0")) //そもそもスペース押されてなかったら実行しないぜ あとゲームパッド
            return;
        if (!allowInput) //連打対策
            return; 



        allowInput = false;　//許可フラグを落とす
        StartCoroutine(SpawnKeyIntervalCount());　//許可フラグを戻すコルーチン


        //実際のスポーン処理
        spawnPoint.Spawn();
        

    }

    IEnumerator SpawnKeyIntervalCount()
    {
        yield return new WaitForSeconds(inputInterval);
        allowInput = true;
    }
}