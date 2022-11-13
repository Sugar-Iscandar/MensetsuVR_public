using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFrame
{
    public Item FrameType {get;}

    public void DestroyFrame();
}
