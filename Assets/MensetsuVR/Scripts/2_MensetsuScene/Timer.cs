using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] float easyTimeLimit;
    [SerializeField] float nomalTimeLimit;
    [SerializeField] float hardTimeLimit;
    float currentTimeLimit;
    float remainingSeconds;
    float previousRemainingSeconds;
    bool isActived;
    public event UnityAction<float, int> OnRemainingSecondsChanged = null;
    public event UnityAction OnTimeIsUp = null;

    public void Init(Difficulty dif)
    {
        isActived = false;
        if (dif == Difficulty.Easy)
        {
            currentTimeLimit = easyTimeLimit;
            
        }
        else if (dif == Difficulty.Nomal)
        {
            currentTimeLimit = nomalTimeLimit;
        }
        else
        {
            currentTimeLimit = hardTimeLimit;
        }
        remainingSeconds = currentTimeLimit;
        previousRemainingSeconds = currentTimeLimit;
    }

    public void StartCalculate()
    {
        isActived = true;
    }

    void Update()
    {
        if (!isActived) return;
        CalculateRemainingTime();
    }

    void CalculateRemainingTime()
    {
        remainingSeconds -= Time.deltaTime;

        if ((int)remainingSeconds != (int)previousRemainingSeconds)
        {
            OnRemainingSecondsChanged?.Invoke(currentTimeLimit, (int)remainingSeconds);

            if ((int)remainingSeconds == 0)
            {
                OnTimeIsUp?.Invoke();
                isActived = false;
            }
        }

        previousRemainingSeconds = remainingSeconds;
    }
}
