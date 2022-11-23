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
        manager.OnInit += (dif) => 
        {
            frontView.Init();
            hmdView.Init();
            hmdView.InitMensetsuView();
            itemSwitcher.Init();
            frameSpawner.Init();
            timer.Init(dif);
            difController.Init(dif);
            rightHand.Init();
            favoController.Init(dif);
            gameResultTallyer.Init();
            hmdView.FadeOutBlack();
        };

        frontView.OnReadyButtonClicked += () => manager.StartCountDown();
        manager.OnCountdownProgressed += (text) => frontView.SetContentMainText(text);

        manager.OnGameStarted += () => 
        {
            frontView.HideCanvas();
            rightHand.HideHandObject(Hand.LeftRight.Right);
            itemSwitcher.StartSwitcher();
            favoController.StartFavorabilitySystem();
            frameSpawner.StartSpawn();
            timer.StartCalculate();
        };

        timer.OnRemainingSecondsChanged += (limit,seconds) => 
        {
            backView.SetContentRemainingTimeText(seconds);
            difController.FunctionOnRemainingSecondChanged(limit,seconds);
        };

        difController.OnFrameSpeedChanged += (speed) => FrameStatus.Instance.Speed = speed;
        difController.OnFrameSpawnIntervalChanged += (interval) => frameSpawner.SetSpawnInterval(interval);

        foreach (ItemCollisionJudgment item in itemCollisionJudgments)
        {
            item.OnCorrect += () => favoController.IncreaseFavorability();
            item.OnIncorrect += () => 
            {
                favoController.ReceiveIncorrectDamage();
                gameResultTallyer.AddIncorrectNum();
            };
        }
        playerCollisionJudgment.OnMiss += () =>
        {
            favoController.ReceiveMissDamage();
            gameResultTallyer.AddMissNum();
        };
        playerCollisionJudgment.OnToleranceWallTouched += () => manager.ForceQuitMensetsu();

        manager.OnGameForceQuited += () =>
        {
            favoController.StopFavorabilitySystem();
            frameSpawner.StopSpawn();
            gameResultTallyer.WriteOutForceQuitResult();
        };

        favoController.OnFavorabilityValueChanged += (value,maxValue) =>
        {
            interviewerView.SetValueFavorabilityGauge(value, maxValue);
            gameResultTallyer.FavorabilityValue = (int)value;
        };

        timer.OnTimeIsUp += () => manager.FinishGame();

        manager.OnGameFinished += () => 
        {
            frontView.SetFinishMessage();
            favoController.StopFavorabilitySystem();
            frameSpawner.StopSpawn();
            gameResultTallyer.WriteOutGameResult();
        };
        
        manager.OnWaitTimeFinished += () => hmdView.FadeInBlack();
        hmdView.OnBlackInFinished += () => SceneChanger.Instance.ChangeToResultScene();
    }
}
