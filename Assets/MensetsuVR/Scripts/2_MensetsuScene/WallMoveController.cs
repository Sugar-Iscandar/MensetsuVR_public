using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoveController : MonoBehaviour
{
    [SerializeField] float maxMoveDistance;

    [SerializeField] WallMover wallMoverLeft;
    [SerializeField] WallMover wallMoverRight;
    [SerializeField] WallMover wallMoverBack;
    [SerializeField] WallMover wallMoveCeiling;

    public void Init()
    {
        wallMoverLeft.Init(maxMoveDistance);
        wallMoverRight.Init(maxMoveDistance);
        wallMoverBack.Init(maxMoveDistance);
        wallMoveCeiling.Init(maxMoveDistance);
    }

    public void PutPressure()
    {
        wallMoverLeft.MoveForward();
        wallMoverRight.MoveForward();
        wallMoverBack.MoveForward();
        wallMoveCeiling.MoveForward();
    }

    public void releasePressure()
    {
        wallMoverLeft.MoveBack();
        wallMoverRight.MoveBack();
        wallMoverBack.MoveBack();
        wallMoveCeiling.MoveBack();
    }
}
