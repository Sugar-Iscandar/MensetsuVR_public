using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickable
{
    void OnTouched();
    void OnReleased();
    void OnClicked();
}
