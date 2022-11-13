using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensetsuPresenter : MonoBehaviour
{
    [SerializeField] MensetsuManager manager;
    [SerializeField] ItemSwitcher itemSwitcher;
    [SerializeField] FrameSpawner frameSpawner;
    [SerializeField] Timer timer;
    [SerializeField] DifficultyControler difController;
    [SerializeField] Hand rightHand;
    [SerializeField] FavorabilityController favoController;
    [SerializeField] ItemCollisionJudgment[] itemCollisionJudgments;
    [SerializeField] PlayerCollisionJudgment playerCollisionJudgment;
    [SerializeField] FrontDisplayView frontView;
    [SerializeField] BackDisplayView backView;
    [SerializeField] InterviewerView interviewerView;
    [SerializeField] MensetsuHmdView hmdView;
    [SerializeField] GameResultTallyer gameResultTallyer;

    void Awake()
    {
        manager.OnInit += (ignore) => frontView.Init();
        manager.OnInit += (ignore) => hmdView.Init(); 
        manager.OnInit += (ignore) => hmdView.InitMensetsuView();
        manager.OnInit += (ignore) => itemSwitcher.Init();
        manager.OnInit += (ignore) => frameSpawner.Init();
        manager.OnInit += (dif) => timer.Init(dif);
        manager.OnInit += (dif) => difController.Init(dif);
        manager.OnInit += (ignore) => rightHand.Init();
        manager.OnInit += (dif) => favoController.Init(dif);
        manager.OnInit += (ignore) => gameResultTallyer.Init();
        manager.OnInit += (ignore) => hmdView.FadeOutBlack();
        frontView.OnReadyButtonClicked += () => manager.StartCountDown();
        manager.OnCountdownProgressed += (text) => frontView.SetContentMainText(text);
        manager.OnGameStarted += () => frontView.HideCanvas();
        manager.OnGameStarted += () => rightHand.HideHandObject(Hand.LeftRight.Right);
        manager.OnGameStarted += () => itemSwitcher.StartSwitcher();
        manager.OnGameStarted += () => favoController.StartFavorabilitySystem();
        manager.OnGameStarted += () => frameSpawner.StartSpawn();
        manager.OnGameStarted += () => timer.StartCalculate();
        timer.OnRemainingSecondsChanged += (ignore,seconds) => backView.SetContentRemainingTimeText(seconds);
        timer.OnRemainingSecondsChanged += (limit,seconds) => difController.FunctionOnRemainingSecondChanged(limit,seconds);
        difController.OnFrameSpeedChanged += (speed) => FrameStatus.Instance.Speed = speed;
        difController.OnFrameSpawnIntervalChanged += (interval) => frameSpawner.SetSpawnInterval(interval);
        foreach (ItemCollisionJudgment item in itemCollisionJudgments)
        {
            item.OnCorrect += () => favoController.IncreaseFavorability();
            item.OnIncorrect += () => favoController.ReceiveIncorrectDamage();
            item.OnIncorrect += () => gameResultTallyer.AddIncorrectNum();
        }
        playerCollisionJudgment.OnMiss += () => favoController.ReceiveMissDamage();
        playerCollisionJudgment.OnMiss += () => gameResultTallyer.AddMissNum();
        playerCollisionJudgment.OnToleranceWallTouched += () => manager.ForceQuitMensetsu();
        manager.OnGameForceQuited += () => favoController.StopFavorabilitySystem();
        manager.OnGameForceQuited += () => frameSpawner.StopSpawn();
        manager.OnGameForceQuited += () => gameResultTallyer.WriteOutForceQuitResult();
        favoController.OnFavorabilityValueChanged += (value, maxValue) => interviewerView.SetValueFavorabilityGauge(value, maxValue);
        favoController.OnFavorabilityValueChanged += (value, ignore) => gameResultTallyer.FavorabilityValue = (int)value;
        timer.OnTimeIsUp += () => manager.FinishGame();
        manager.OnGameFinished += () => frontView.SetFinishMessage();
        manager.OnGameFinished += () => favoController.StopFavorabilitySystem();
        manager.OnGameFinished += () => frameSpawner.StopSpawn();
        manager.OnGameFinished += () => gameResultTallyer.WriteOutGameResult();
        manager.OnWaitTimeFinished += () => hmdView.FadeInBlack();
        hmdView.OnBlackInFinished += () => SceneChanger.Instance.ChangeToResultScene();
    }
}
