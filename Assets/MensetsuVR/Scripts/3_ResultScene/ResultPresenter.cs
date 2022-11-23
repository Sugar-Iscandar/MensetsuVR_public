using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPresenter : MonoBehaviour
{
    [SerializeField] ResultManager manager;
    [SerializeField] ResultView view;
    [SerializeField] HmdView hmdView;

    void Awake()
    {
        manager.OnInit += () =>
        {
            view.Init();
            hmdView.Init();
            hmdView.FadeOutBlack();
        };

        manager.OnResultJudgFinished += (result) =>
        {
            view.SetContentsEachText(result);
            view.ShowEachResultText();
        };

        view.OnRetryButtonClicked += () => manager.FunctionOnButtonClicked(2);
        view.OnJoiningCompanyButtonClicked += () => manager.FunctionOnButtonClicked(4);
        view.OnBackSelectSceneButtonClicked += () => manager.FunctionOnButtonClicked(1);
        manager.OnNextSceneDecided += () => hmdView.FadeInBlack();
        hmdView.OnBlackInFinished += () => manager.ChangeScene();
    }
}
