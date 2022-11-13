using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCollisionJudgment : MonoBehaviour
{
    public event UnityAction OnCorrect = null;
    public event UnityAction OnIncorrect = null;

    [SerializeField] Item thisItemType;

    void OnTriggerEnter(Collider other) 
    {
        IFrame interfaceOfFrame = other.gameObject.GetComponent<IFrame>();

        if (interfaceOfFrame == null) return;

        if (interfaceOfFrame.FrameType == thisItemType)
        {
            OnCorrect?.Invoke();
            interfaceOfFrame.DestroyFrame();
        }
        else
        {
            OnIncorrect?.Invoke();
            interfaceOfFrame.DestroyFrame();
        }
    }
}
