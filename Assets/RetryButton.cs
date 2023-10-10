using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    [SerializeField, Header("�N�����ɑI����Ԃɂ��邩")] bool enableSelected;

    Button _button;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();

        if (enableSelected)
            _button.Select();
            
    }


    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameScene");
    }

}
