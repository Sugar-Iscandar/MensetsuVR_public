using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult
{
    static GameResult instance = new GameResult();

    public static GameResult Instance
    {
        get => instance;
    }

    private GameResult() {}

    /* ゲームの結果が保存される */
    public int IncorrectNum { get; set; }
    public int MissNUm { get; set; }
    public int FavorabilityValue { get; set; }
}
