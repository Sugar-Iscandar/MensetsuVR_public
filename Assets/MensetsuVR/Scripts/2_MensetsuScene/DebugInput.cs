using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugInput : MonoBehaviour
{
    //デバッグ用のクラス

    [SerializeField] MensetsuManager manager;

    public void OnTypeEnter(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        manager.StartCountDown();
    }
}
