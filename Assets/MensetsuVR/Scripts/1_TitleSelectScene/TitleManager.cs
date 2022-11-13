using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    CompanyGenerater companyGenerater;
    Company[] currentCompanies;

    public event UnityAction OnInit = null;
    public event UnityAction<Company[]> OnCompanySelectionActived = null;
    public event UnityAction OnCompanyEntered = null;

    void Start()
    {
        companyGenerater = GetComponent<CompanyGenerater>();
        currentCompanies = companyGenerater.GenerateCompany();
        OnInit?.Invoke();
    }

    public void ActiveCompanySelection()
    {
        OnCompanySelectionActived?.Invoke(currentCompanies);
    }

    public void EntryCompany(Difficulty difficultyOfTheCompany)
    {
        CurrentDifficulty.Instance.difficulty = difficultyOfTheCompany;
        OnCompanyEntered?.Invoke();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
