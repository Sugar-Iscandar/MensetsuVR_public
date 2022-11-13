using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameStatus
{
    static FrameStatus instance = new FrameStatus();

    public static FrameStatus Instance
    {
        get => instance;
    }

    private FrameStatus() {}

    float speed;
    
    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public void ChangeSpeed(int phase)
    {
        switch(phase)
        {
            case 1:
                speed = 0.5f;
                break;
            case 2:
                speed = 0.7f;
                break;
            case 3:
                speed = 1.0f;
                break;
        }
    }
}
