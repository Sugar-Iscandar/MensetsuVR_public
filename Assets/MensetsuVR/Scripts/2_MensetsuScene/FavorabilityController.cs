using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FavorabilityController : MonoBehaviour
{
    [SerializeField] float easyMaxFavorabilityValue;
    [SerializeField] float nomalMaxFavorabilityValue;
    [SerializeField] float hardMaxFavorabilityValue;
    [SerializeField] float damageValueWhenIncorrect;
    [SerializeField] float damageValueWhenMiss;
    [SerializeField] float increaseValue;
    float currentFavorability;
    float currentMaxFavorability;
    bool isActived;
    public event UnityAction<float,float> OnFavorabilityValueChanged = null;

    public void Init(Difficulty dif)
    {
        Debug.Log("好感度コントローラー：初期化");
        if (dif == Difficulty.Easy)
        {
            currentMaxFavorability = easyMaxFavorabilityValue;
        }
        else if (dif == Difficulty.Nomal)
        {
            currentMaxFavorability = nomalMaxFavorabilityValue;
        }
        else
        {
            currentMaxFavorability = hardMaxFavorabilityValue;
        }
        currentFavorability = 0f;
        OnFavorabilityValueChanged?.Invoke(currentFavorability, currentMaxFavorability);
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

        currentFavorability -= damageValueWhenIncorrect;

        if (currentFavorability < 0)
        {
            currentFavorability = 0;
        }

        OnFavorabilityValueChanged?.Invoke(currentFavorability, currentMaxFavorability);
    }

    public void ReceiveMissDamage()
    {
        if (!isActived) return;

        currentFavorability -= damageValueWhenMiss;

        if (currentFavorability < 0)
        {
            currentFavorability = 0;
        }

        OnFavorabilityValueChanged?.Invoke(currentFavorability, currentMaxFavorability);
    }

    public void IncreaseFavorability()
    {
        if (!isActived) return;

        currentFavorability += increaseValue;

        if (currentFavorability > currentMaxFavorability)
        {
            currentFavorability = currentMaxFavorability;
        }

        OnFavorabilityValueChanged?.Invoke(currentFavorability, currentMaxFavorability);
    }
}
