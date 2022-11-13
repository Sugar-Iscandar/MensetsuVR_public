using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour
{
    public enum WallType
    {
        LeftWall,
        RightWall,
        BackWall,
        Ceiling
    }

    [SerializeField] WallType wallType;

    float distanceToMoveLimit;
    float moveDistance;
    float moveSpeed = 0.01f;
    float moveInterval = 0.02f;
    Vector3 originalPosition;

    public void Init(float limit)
    {
        moveDistance = 0;
        if (wallType == WallType.Ceiling)
        {
            distanceToMoveLimit = limit * 0.8f;
            moveSpeed = 0.01f * 0.8f;
        }
        else
        {
            distanceToMoveLimit = limit;
        }
    }

    public void MoveForward()
    {
        originalPosition = transform.position;
        StartCoroutine(Move());
    }

    public void MoveBack()
    {
        StartCoroutine(BackMove());
    }

    IEnumerator Move()
    {
        while (moveDistance < distanceToMoveLimit)
        {
            Vector3 move = transform.forward * moveSpeed;
            transform.position += move;
            if (wallType == WallType.LeftWall)
            {
                moveDistance += move.x;
            }
            else if (wallType == WallType.RightWall)
            {
                moveDistance += -move.x;
            }
            else if (wallType == WallType.BackWall)
            {
                moveDistance += -move.z;
            }
            else if (wallType == WallType.Ceiling)
            {
                moveDistance += -move.y;
            }
            yield return new WaitForSeconds(moveInterval);
        }
    }

    IEnumerator BackMove()
    {
        while (moveDistance > 0)
        {
            Vector3 move = -transform.forward * moveSpeed;
            transform.position += move;
            if (wallType == WallType.LeftWall)
            {
                moveDistance += move.x;
            }
            else if (wallType == WallType.RightWall)
            {
                moveDistance += -move.x;
            }
            else if (wallType == WallType.BackWall)
            {
                moveDistance += -move.z;
            }
            else if (wallType == WallType.Ceiling)
            {
                moveDistance += -move.y;
            }
            yield return new WaitForSeconds(moveInterval);
        }

        moveDistance = 0;
        transform.position = originalPosition;
    }



}
