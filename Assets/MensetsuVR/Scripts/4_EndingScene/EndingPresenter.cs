using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPresenter : MonoBehaviour
{
    [SerializeField] EndingManager manager;
    [SerializeField] EndingView view;

    void Awake()
    {
        manager.OnInit += () => view.Init();
        manager.OnStarted += () => view.FadeInThankyou();
        view.OnThankyouShowFinished += () => manager.LoadToTitleScene();
    }
}
