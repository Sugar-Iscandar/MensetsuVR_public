using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    static SceneChanger instance;

    public static SceneChanger Instance
    {
        get => instance;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ChangeToTitleSelectScene()
    {
        SceneManager.LoadScene("TitleSelectScene");
    }

    public void ChangeToMensetsuScene()
    {
        SceneManager.LoadScene("MensetsuScene");
    }

    public void ChangeToResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }

    public void ChangeToEndingScene()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
