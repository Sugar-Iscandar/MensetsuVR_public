using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePresenter : MonoBehaviour
{
    [SerializeField] TitleManager manager;
    [SerializeField] HmdView hmdView;
    [SerializeField] TitleView titleView;
    [SerializeField] SelectionView selView;

    void Awake()
    {
        manager.OnInit += () => titleView.Init();
        manager.OnInit += () => selView.Init();
        manager.OnInit += () => hmdView.Init();
        manager.OnInit += () => hmdView.FadeOutBlack();
        titleView.OnEnterButtonClicked += () => manager.ActiveCompanySelection();
        titleView.OnQuitButtonClicked += () => manager.QuitApplication();
        manager.OnCompanySelectionActived += (companies) => selView.ShowCompanyData(companies);
        selView.OnBackButtonClicked += () => titleView.IndicateCanvas();
        selView.OnYesButtonClicked += (difficulty) => manager.EntryCompany(difficulty);
        manager.OnCompanyEntered += () => hmdView.FadeInBlack();
        hmdView.OnBlackInFinished += () => SceneChanger.Instance.ChangeToMensetsuScene();
    }
}
