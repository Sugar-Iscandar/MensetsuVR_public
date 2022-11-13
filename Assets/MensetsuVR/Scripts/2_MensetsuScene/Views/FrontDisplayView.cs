using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FrontDisplayView : MonoBehaviour
{
    [SerializeField] GameObject canvasFrontDialog;
    [SerializeField] Text textMain;
    [SerializeField] Text textExplanationTitle;
    [SerializeField] Text textExplanation;
    [SerializeField] Text textObjectEx;
    [SerializeField] GameObject resumeEx;
    [SerializeField] GameObject portfolioEx;
    [SerializeField] GameObject experienceEx;
    [SerializeField] VrButton vrButtonReady;
    public event UnityAction OnReadyButtonClicked = null;

    public void Init()
    {
        vrButtonReady.OnClick.AddListener(() => FunctionOnReadyButtonClicked());
        textMain.enabled = false;
        textExplanationTitle.enabled = true;
        textExplanation.enabled = true;
        textObjectEx.enabled = true;
        resumeEx.SetActive(true);
        portfolioEx.SetActive(true);
        experienceEx.SetActive(true);
        canvasFrontDialog.SetActive(true);
    }

    void FunctionOnReadyButtonClicked()
    {
        vrButtonReady.gameObject.SetActive(false);
        textMain.enabled = true;
        textExplanationTitle.enabled = false;
        textExplanation.enabled = false;
        textObjectEx.enabled = false;
        resumeEx.SetActive(false);
        portfolioEx.SetActive(false);
        experienceEx.SetActive(false);

        OnReadyButtonClicked?.Invoke();
    }

    public void SetContentMainText(string newContent)
    {
        textMain.text = newContent;
    }

    public void HideCanvas()
    {
        canvasFrontDialog.SetActive(false);
    }

    public void SetFinishMessage()
    {
        SetContentMainText("FINISH");
        canvasFrontDialog.SetActive(true);
    }
}
