using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemSwitcher : MonoBehaviour
{
    [SerializeField] GameObject itemResume;
    [SerializeField] GameObject itemPortfolio;
    [SerializeField] GameObject itemExperience;
    Item currentItem;
    bool isActived = false;
    
    public void Init()
    {
        itemResume.SetActive(false);
        itemPortfolio.SetActive(false);
        itemExperience.SetActive(false);
        currentItem = Item.Resume;
        isActived = false;
    }

    public void StartSwitcher()
    {
        itemResume.SetActive(true);
        isActived = true;
    }

    //InputSystemにより呼ばれる
    public void SwitchItem(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!isActived) return;

        switch(currentItem)
        {
            case Item.Resume:
                itemResume.SetActive(false);
                itemPortfolio.SetActive(true);
                currentItem = Item.Portfolio;
                break;
            case Item.Portfolio:
                itemPortfolio.SetActive(false);
                itemExperience.SetActive(true);
                currentItem = Item.Experience;
                break;
            case Item.Experience:
                itemExperience.SetActive(false);
                itemResume.SetActive(true);
                currentItem = Item.Resume;
                break;
        }
    }
}
