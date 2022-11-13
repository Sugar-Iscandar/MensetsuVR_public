using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public event UnityAction OnInit = null;
    public event UnityAction OnStarted = null;
    
    void Start()
    {
        OnInit?.Invoke();
        OnStarted?.Invoke();
    }

    public void LoadToTitleScene()
    {
        SceneManager.LoadScene("TitleSelectScene");
    }
}
