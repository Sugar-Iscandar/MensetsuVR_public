using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TitleView : MonoBehaviour
{
    [SerializeField] GameObject canvasTitle;
    [SerializeField] VrButton vrButtonEnter;
    [SerializeField] VrButton vrButtonQuit;
    [SerializeField] VrButton vrButtonSetting;

    public event UnityAction OnEnterButtonClicked = null;
    public event UnityAction OnQuitButtonClicked = null;
    //public event UnityAction OnSettingButtonClicked = null;

    public void Init()
    {
        vrButtonEnter.OnClick.AddListener(() => FunctionOnEnterButtonClicked());
        vrButtonQuit.OnClick.AddListener(() => OnQuitButtonClicked?.Invoke());
        //vrButtonSetting.OnClick.AddListener(() => OnSettingButtonClicked?.Invoke());

        IndicateCanvas();
    }

    public void IndicateCanvas()
    {
        canvasTitle.SetActive(true);
    }

    void FunctionOnEnterButtonClicked()
    {
        canvasTitle.SetActive(false);
        OnEnterButtonClicked?.Invoke();
    }
}
