using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hand : MonoBehaviour
{
    public enum LeftRight
    {
        Left,
        Right
    }
    [SerializeField] LeftRight leftOrRight;
    IClickable interfaceOfVrButton = null;

    public void Init()
    {
        //左右の手を表示
        IndicateHandObject(LeftRight.Left);
        IndicateHandObject(LeftRight.Right);
    }

    //PlayerInputにより呼ばれる
    public void OnTriggerButtonPressed(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Debug.Log("トリガー");
        
        if (interfaceOfVrButton != null)
        {
            interfaceOfVrButton.OnClicked();
            interfaceOfVrButton.OnReleased();
            interfaceOfVrButton = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        interfaceOfVrButton = other.gameObject.GetComponent<IClickable>();

        if (interfaceOfVrButton != null)
        {
            interfaceOfVrButton.OnTouched();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (interfaceOfVrButton != null)
        {
            interfaceOfVrButton.OnReleased();
            interfaceOfVrButton = null;
        }
    }

    public void IndicateHandObject(LeftRight leftRight)
    {
        if (leftRight == LeftRight.Left)
        {
            if (this.leftOrRight == LeftRight.Left)
            this.gameObject.SetActive(true);
        }
        else
        {
            if (this.leftOrRight == LeftRight.Right)
            this.gameObject.SetActive(true);
        }
    }

    public void HideHandObject(LeftRight leftRight)
    {
        if (leftRight == LeftRight.Left)
        {
            if (this.leftOrRight == LeftRight.Left)
            this.gameObject.SetActive(false);
        }
        else
        {
            if (this.leftOrRight == LeftRight.Right)
            this.gameObject.SetActive(false);
        }
    }
}
