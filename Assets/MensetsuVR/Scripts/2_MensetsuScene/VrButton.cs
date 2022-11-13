using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VrButton : MonoBehaviour, IClickable
{
    Image image;
    Color originalColor;
    public UnityEvent OnClick = new UnityEvent();

    void Awake()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
    }

    public void OnTouched()
    {
        image.color = Color.yellow;
    }

    public void OnReleased()
    {
        image.color = originalColor;
    }

    public void OnClicked()
    {
        OnClick?.Invoke();
    }
}
