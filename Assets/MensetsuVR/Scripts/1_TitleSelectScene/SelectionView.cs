using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SelectionView : MonoBehaviour
{
    [SerializeField] GameObject canvasSelection;
    [SerializeField] Text textTitle;
    [SerializeField] Text textCompanyName;
    [SerializeField] Image imageCompany;
    [SerializeField] VrButton vrButtonEntry;
    [SerializeField] VrButton vrButtonLeft;
    [SerializeField] VrButton vrButtonRight;
    [SerializeField] VrButton vrButtonBack;
    [SerializeField] VrButton vrButtonYes;
    [SerializeField] VrButton vrButtonNo;

    Company[] companies;
    Difficulty selectedDifficulty;

    int currentCompaniesIndex;

    public event UnityAction OnBackButtonClicked = null;
    public event UnityAction<Difficulty> OnYesButtonClicked = null;

    public void Init()
    {
        vrButtonEntry.OnClick.AddListener(() => FunctionOnEntryButtonClicked());
        vrButtonLeft.OnClick.AddListener(() => FunctionOnLeftButtonClicked());
        vrButtonRight.OnClick.AddListener(() => FunctionOnRightButtonClicked());
        vrButtonBack.OnClick.AddListener(() => FunctionOnBackButtonClicked());
        vrButtonYes.OnClick.AddListener(() => FunctionOnYesButtonClicked());
        vrButtonNo.OnClick.AddListener(() => FunctionOnNoButtonClicked());

        canvasSelection.SetActive(false);
        vrButtonYes.gameObject.SetActive(false);
        vrButtonNo.gameObject.SetActive(false);
        textTitle.text = "企業を選択";
        currentCompaniesIndex = 0;
    }

    public void ShowCompanyData(Company[] companies)
    {
        this.companies = companies;

        //先頭の企業情報をセットする
        textCompanyName.text = companies[currentCompaniesIndex].CompanyName;
        imageCompany.sprite = companies[currentCompaniesIndex].CompanyImage;
        imageCompany.SetNativeSize();

        canvasSelection.SetActive(true);
    }

    void FunctionOnEntryButtonClicked()
    {
        textTitle.text = "この企業にエントリーしますか？";
        vrButtonEntry.gameObject.SetActive(false);
        vrButtonLeft.gameObject.SetActive(false);
        vrButtonRight.gameObject.SetActive(false);
        vrButtonBack.gameObject.SetActive(false);

        vrButtonYes.gameObject.SetActive(true);
        vrButtonNo.gameObject.SetActive(true);
    }

    void FunctionOnLeftButtonClicked()
    {
        if (currentCompaniesIndex == 0) return;

        currentCompaniesIndex--;

        textCompanyName.text = companies[currentCompaniesIndex].CompanyName;
        imageCompany.sprite = companies[currentCompaniesIndex].CompanyImage;
        imageCompany.SetNativeSize();
    }

    void FunctionOnRightButtonClicked()
    {
        if (currentCompaniesIndex >= companies.Length - 1) return;

        currentCompaniesIndex++;

        textCompanyName.text = companies[currentCompaniesIndex].CompanyName;
        imageCompany.sprite = companies[currentCompaniesIndex].CompanyImage;
        imageCompany.SetNativeSize();
    }

    void FunctionOnBackButtonClicked()
    {
        canvasSelection.SetActive(false);
        OnBackButtonClicked?.Invoke();
    }

    void FunctionOnYesButtonClicked()
    {
        selectedDifficulty = companies[currentCompaniesIndex].difficulty;
        Debug.Log("難易度設定："+ selectedDifficulty);
        OnYesButtonClicked?.Invoke(selectedDifficulty);
    }

    void FunctionOnNoButtonClicked()
    {
        vrButtonYes.gameObject.SetActive(false);
        vrButtonNo.gameObject.SetActive(false);
        
        vrButtonEntry.gameObject.SetActive(true);
        vrButtonLeft.gameObject.SetActive(true);
        vrButtonRight.gameObject.SetActive(true);
        vrButtonBack.gameObject.SetActive(true);
        textTitle.text = "企業を選択";
    }
}
