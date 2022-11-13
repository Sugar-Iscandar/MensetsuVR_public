using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentDifficulty
{
    static CurrentDifficulty instance = new CurrentDifficulty();

    public static CurrentDifficulty Instance
    {
        get => instance;
    }

    private CurrentDifficulty() {}

    public Difficulty difficulty { get; set; }
}
