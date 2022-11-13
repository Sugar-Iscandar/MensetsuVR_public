using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultJudge
{
    float favorabilityPassLine = 70.0f;

    public FinalResult JudgeResult(GameResult result)
    {
        FinalResult finalResult = new FinalResult();

        finalResult.IncorrectNum = result.IncorrectNum;
        finalResult.MissNum = result.MissNUm;

        if (result.FavorabilityValue >= favorabilityPassLine)
        {
            finalResult.IsPass = true;
        }
        else
        {
            finalResult.IsPass = false;
        }

        return finalResult;
    }
}
