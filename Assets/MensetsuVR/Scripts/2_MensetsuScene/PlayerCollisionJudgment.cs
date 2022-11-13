using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionJudgment : MonoBehaviour
{
    public event UnityAction OnMiss = null;
    public event UnityAction OnToleranceWallTouched = null;
    void OnTriggerEnter(Collider other) 
    {
        IFrame interfaceOfFrame = other.gameObject.GetComponent<IFrame>();

        if (interfaceOfFrame != null)
        {
            OnMiss?.Invoke();
            interfaceOfFrame.DestroyFrame();
        }
        else if (other.tag == "ToleranceWall")
        {
            OnToleranceWallTouched?.Invoke();
        }
    }
}
