using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackDisplayView : MonoBehaviour
{
    [SerializeField] Text textRemainingTime;

    public void SetContentRemainingTimeText(int remainingSeconds)
    {
        System.TimeSpan timeSpan = new System.TimeSpan(0, 0, remainingSeconds);
        textRemainingTime.text = timeSpan.ToString(@"mm\:ss");
    }
}
