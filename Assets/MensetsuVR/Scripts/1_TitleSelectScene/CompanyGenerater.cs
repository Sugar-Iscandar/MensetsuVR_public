using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyGenerater : MonoBehaviour
{
    /* デモのためインスペクターに登録した企業を生成 */

    [SerializeField] string demoCompanyName;
    [SerializeField] Sprite demoCompanyImage;
    [SerializeField] Difficulty demoCompanyDifficulty;

    public Company[] GenerateCompany()
    {
        Company company = new Company();

        company.CompanyName = demoCompanyName;
        company.CompanyImage = demoCompanyImage;
        company.difficulty = demoCompanyDifficulty;

        Company[] companies = new Company[1];
        companies[0] = company;

        return companies;
    }
}
