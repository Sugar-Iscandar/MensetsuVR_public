using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterviewerView : MonoBehaviour
{
    [SerializeField] Slider gaugeFavorability;

    public void SetValueFavorabilityGauge(float value, float maxValue)
    {
        gaugeFavorability.value = value / maxValue;
    }
}
