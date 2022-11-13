using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DifficultyControler : MonoBehaviour
{
    float frameSpawnInterval;
    float frameSpeed;

    Difficulty currentDifficulty;

    WallMoveController wallMoveController;

    public event UnityAction<float> OnFrameSpawnIntervalChanged = null;
    public event UnityAction<float> OnFrameSpeedChanged = null;

    public void Init(Difficulty dif)
    {
        //マネージャーから渡される
        currentDifficulty = dif;

        wallMoveController = GetComponent<WallMoveController>();
        wallMoveController.Init();

        //各種数値初期値に
        frameSpeed = 1.0f;
        OnFrameSpeedChanged?.Invoke(frameSpeed);
        if (currentDifficulty == Difficulty.Hard)
        {
            frameSpawnInterval = 2.0f;
            OnFrameSpawnIntervalChanged?.Invoke(frameSpawnInterval);
        }
        else
        {
            frameSpawnInterval = 3.0f;
            OnFrameSpawnIntervalChanged?.Invoke(frameSpawnInterval);
        }
    }

    public void FunctionOnRemainingSecondChanged(float timeLimit, int seconds)
    {
        if (currentDifficulty == Difficulty.Easy)
        {
            EasyDifficultyControl(timeLimit, seconds);
        }
        else if (currentDifficulty == Difficulty.Nomal)
        {
            NomalDifficultyCotrol(timeLimit, seconds);
        }
        else
        {
            HardDifficultyControl(timeLimit, seconds);
        }
    }

    void EasyDifficultyControl(float limit, int seconds)
    {
        switch(((int)limit - seconds))
        {
            case 20:
                frameSpeed = 0.7f;
                frameSpawnInterval = 4.5f;
                OnFrameSpeedChanged?.Invoke(frameSpeed);
                OnFrameSpawnIntervalChanged?.Invoke(frameSpawnInterval);
                break;
            case 40:
                frameSpeed = 0.9f;
                OnFrameSpeedChanged?.Invoke(frameSpeed);
                break;
        }
    }

    void NomalDifficultyCotrol(float limit, int seconds)
    {
        switch(((int)limit - seconds))
        {
            case 20:
                frameSpeed = 1.3f;
                frameSpawnInterval = 2.5f;
                OnFrameSpeedChanged?.Invoke(frameSpeed);
                OnFrameSpawnIntervalChanged?.Invoke(frameSpawnInterval);
                break;
            case 40:
                frameSpeed = 1.5f;
                frameSpawnInterval = 1.5f;
                OnFrameSpeedChanged?.Invoke(frameSpeed);
                OnFrameSpawnIntervalChanged?.Invoke(frameSpawnInterval);
                break;
            case 60:
                //圧迫開始処理
                wallMoveController.PutPressure();
                frameSpeed = 1.3f;
                frameSpawnInterval = 1.0f;
                OnFrameSpeedChanged?.Invoke(frameSpeed);
                OnFrameSpawnIntervalChanged?.Invoke(frameSpawnInterval);
                break;
            case 90:
                //圧迫解除処理
                wallMoveController.releasePressure();
                frameSpeed = 1.0f;
                frameSpawnInterval = 2.0f;
                OnFrameSpeedChanged?.Invoke(frameSpeed);
                OnFrameSpawnIntervalChanged?.Invoke(frameSpawnInterval);
                break;
        }
    }

    void HardDifficultyControl(float limit, int seconds)
    {
        switch(((int)limit - seconds))
        {
            case 20:
                frameSpeed = 0.7f;
                frameSpawnInterval = 4.5f;
                OnFrameSpeedChanged?.Invoke(frameSpeed);
                OnFrameSpawnIntervalChanged?.Invoke(frameSpawnInterval);
                break;
            case 40:
                frameSpawnInterval = 4.0f;
                OnFrameSpawnIntervalChanged?.Invoke(frameSpawnInterval);
                break;
            case 60:
                //圧迫開始処理
                wallMoveController.PutPressure();
                frameSpeed = 0.9f;
                OnFrameSpeedChanged?.Invoke(frameSpeed);
                break;
            case 90:
                //圧迫解除処理
                wallMoveController.releasePressure();
                frameSpeed = 0.8f;
                frameSpawnInterval = 5.0f;
                OnFrameSpeedChanged?.Invoke(frameSpeed);
                OnFrameSpawnIntervalChanged?.Invoke(frameSpawnInterval);
                break;
            case 100:
                //圧迫開始処理
                wallMoveController.PutPressure();
                frameSpeed = 1.0f;
                frameSpawnInterval = 6.0f;
                OnFrameSpeedChanged?.Invoke(frameSpeed);
                OnFrameSpawnIntervalChanged?.Invoke(frameSpawnInterval);
                break;
            case 120:
                //圧迫解除処理
                wallMoveController.releasePressure();
                frameSpeed = 1.5f;
                OnFrameSpeedChanged?.Invoke(frameSpeed);
                break;
            case 140:
                frameSpeed = 1.0f;
                frameSpawnInterval = 5.0f;
                OnFrameSpeedChanged?.Invoke(frameSpeed);
                OnFrameSpawnIntervalChanged?.Invoke(frameSpawnInterval);
                break;
        }
    }
}
