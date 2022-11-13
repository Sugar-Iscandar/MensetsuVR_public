using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TestChangeScene : MonoBehaviour
{
    public void ChangeScene(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        SceneManager.LoadScene("MensetsuScene");
    }
}
