using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    [SerializeField] Text textIncorrectNum;
    [SerializeField] Text textMissNum;
    [SerializeField] Text textResult;
    [SerializeField] VrButton vrButtonRetry;
    [SerializeField] VrButton vrButtonJoiningCompany;
    [SerializeField] VrButton vrButtonBackSelectScene;

    FinalResult finalResult;

    public event UnityAction OnRetryButtonClicked = null;
    public event UnityAction OnJoiningCompanyButtonClicked = null;
    public event UnityAction OnBackSelectSceneButtonClicked = null;

    public void Init()
    {
        vrButtonRetry.OnClick.AddListener(() => OnRetryButtonClicked?.Invoke());
        vrButtonJoiningCompany.OnClick.AddListener(() => OnJoiningCompanyButtonClicked?.Invoke());
        vrButtonBackSelectScene.OnClick.AddListener(() => OnBackSelectSceneButtonClicked?.Invoke());
        textIncorrectNum.enabled = false;
        textMissNum.enabled = false;
        textResult.enabled = false;
        vrButtonRetry.gameObject.SetActive(false);
        vrButtonJoiningCompany.gameObject.SetActive(false);
        vrButtonBackSelectScene.gameObject.SetActive(false);
    }

    public void SetContentsEachText(FinalResult result)
    {
        finalResult = result;

        textIncorrectNum.text = result.IncorrectNum.ToString() + " 回";
        textMissNum.text = result.MissNum.ToString() + " 回";

        if (result.IsPass)
        {
            textResult.text = "採用内定";
        }
        else
        {
            textResult.text = "不採用";
        }
    }

    public void ShowEachResultText()
    {
        StartCoroutine(ShowTexts());
    }

    IEnumerator ShowTexts()
    {
        yield return new WaitForSeconds(0.7f);

        textIncorrectNum.enabled = true;

        yield return new WaitForSeconds(0.7f);

        textMissNum.enabled = true;

        yield return new WaitForSeconds(0.7f);

        textResult.enabled = true;

        yield return new WaitForSeconds(0.7f);

        ShowVrButton();
    }

    void ShowVrButton()
    {
        vrButtonRetry.gameObject.SetActive(true);

        if (finalResult.IsPass)
        {
            vrButtonJoiningCompany.gameObject.SetActive(true);
        }
        else
        {
            vrButtonBackSelectScene.gameObject.SetActive(true);
        }
    }
}
