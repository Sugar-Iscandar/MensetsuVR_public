using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interviewer : MonoBehaviour
{
    /*
    float favorability = 100;
    float maxFavorability;
    float damageValueWhenIncorrect = 10;
    float damageValueWhenMiss = 5;
    float increaseValue = 5;

    bool isActived;

    public event UnityAction<float, float> OnFavorabilityValueChanged = null;

    public void Init()
    {
        maxFavorability = favorability;
        OnFavorabilityValueChanged?.Invoke(favorability, maxFavorability);
        isActived = false;
    }

    public void StartFavorabilitySystem()
    {
        isActived = true;
    }

    public void StopFavorabilitySystem()
    {
        isActived = false;
    }

    public void ReceiveIncorrectDamage()
    {
        if (!isActived) return;

        favorability -= damageValueWhenIncorrect;

        if (favorability < 0)
        {
            favorability = 0;
        }

        OnFavorabilityValueChanged?.Invoke(favorability, maxFavorability);
    }

    public void ReceiveMissDamage()
    {
        if (!isActived) return;

        favorability -= damageValueWhenMiss;

        if (favorability < 0)
        {
            favorability = 0;
        }

        OnFavorabilityValueChanged?.Invoke(favorability, maxFavorability);
    }

    public void IncreaseFavorability()
    {
        if (!isActived) return;

        favorability += increaseValue;

        if (favorability > maxFavorability)
        {
            favorability = maxFavorability;
        }

        OnFavorabilityValueChanged?.Invoke(favorability, maxFavorability);
    }
    */
}
