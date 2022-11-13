using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultTallyer : MonoBehaviour
{
    int incorrectNum;
    int missNum;
    int favorabilityValue;

    public int FavorabilityValue
    {
        set => favorabilityValue = value;
    }

    public void Init()
    {
        incorrectNum = 0;
        missNum = 0;
        favorabilityValue = 0;
    }

    public void AddIncorrectNum()
    {
        incorrectNum++;
    }

    public void AddMissNum()
    {
        missNum++;
    }

    public void WriteOutGameResult()
    {
        GameResult.Instance.IncorrectNum = incorrectNum;
        GameResult.Instance.MissNUm = missNum;
        GameResult.Instance.FavorabilityValue = favorabilityValue;
    }

    public void WriteOutForceQuitResult()
    {
        GameResult.Instance.IncorrectNum = incorrectNum;
        GameResult.Instance.MissNUm = missNum;
        GameResult.Instance.FavorabilityValue = 0;
    }
}
