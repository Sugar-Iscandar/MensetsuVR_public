using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    FinalResult finalResult;
    ResultJudge resultJudge = new ResultJudge();
    int sceneNum;
    public event UnityAction OnInit = null;
    public event UnityAction<FinalResult> OnResultJudgFinished = null;
    public event UnityAction OnNextSceneDecided = null;

    void Start()
    {
        OnInit?.Invoke();
        //ゲーム判定結果を格納
        finalResult = resultJudge.JudgeResult(GameResult.Instance);
        OnResultJudgFinished?.Invoke(finalResult);
    }

    public void FunctionOnButtonClicked(int scene)
    {
        sceneNum = scene;
        OnNextSceneDecided?.Invoke();
    }

    public void ChangeScene()
    {
        switch (sceneNum)
        {
            case 1:
                SceneChanger.Instance.ChangeToTitleSelectScene();
                break;
            case 2:
                SceneChanger.Instance.ChangeToMensetsuScene();
                break;
            case 4:
                SceneChanger.Instance.ChangeToEndingScene();
                break;
        }
    }
    
}
