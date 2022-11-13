using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MensetsuManager : MonoBehaviour
{
    Difficulty currentDifficulty;
    public event UnityAction<Difficulty> OnInit = null;
    public event UnityAction<string> OnCountdownProgressed = null;
    //public event UnityAction OnCountDownFinished = null;
    public event UnityAction OnGameStarted = null;
    public event UnityAction OnGameFinished = null;
    public event UnityAction OnWaitTimeFinished = null;
    public event UnityAction OnGameForceQuited = null;
    
    void Start()
    {
        currentDifficulty = CurrentDifficulty.Instance.difficulty;
        OnInit?.Invoke(currentDifficulty);
    }

    //readyボタン押下によって呼ばれる
    public void StartCountDown()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        OnCountdownProgressed?.Invoke("3");

        yield return new WaitForSeconds(1.0f);

        OnCountdownProgressed?.Invoke("2");

        yield return new WaitForSeconds(1.0f);

        OnCountdownProgressed?.Invoke("1");

        yield return new WaitForSeconds(1.0f);

        OnCountdownProgressed?.Invoke("Start!");

        yield return new WaitForSeconds(1.0f);

        StartGame();
    }

    void StartGame()
    {
        Debug.Log("ゲームスタート");
        OnGameStarted?.Invoke();        
    }

    //制限時間が無くなると呼ばれる
    public void FinishGame()
    {
        OnGameFinished?.Invoke();
        StartCoroutine(WaitWhile());
    }

    IEnumerator WaitWhile()
    {
        yield return new WaitForSeconds(2.0f);
        OnWaitTimeFinished?.Invoke();
    }

    //移動限界ラインに触れると呼ばれる
    public void ForceQuitMensetsu()
    {
        StartCoroutine((WaitWhileForceQuit()));
    }

    IEnumerator WaitWhileForceQuit()
    {
        yield return new WaitForSeconds(5.0f);
        OnGameForceQuited?.Invoke();
    }
}
