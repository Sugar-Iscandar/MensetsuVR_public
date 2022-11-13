using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MensetsuHmdView : HmdView
{
    [SerializeField] Text textMessage;

    public void InitMensetsuView()
    {
        textMessage.color = Color.clear;
    }

    public void IndicateMessage()
    {
        textMessage.color = Color.red;
    }
}
