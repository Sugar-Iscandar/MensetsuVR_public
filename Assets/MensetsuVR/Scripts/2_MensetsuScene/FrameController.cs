using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameController : MonoBehaviour, IFrame
{
    [SerializeField] Item frameType;
    Vector3 playerPosition = new Vector3(0, 1.2f, 0);
    float speed;
    public Item FrameType
    {
        get => frameType;
    }

    void Start()
    {
        //生成直後、プレイヤーの方角にZ軸を向ける
        Vector3 directionToFace = (playerPosition - transform.position).normalized;
        transform.forward = directionToFace;
        speed = FrameStatus.Instance.Speed;
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    public void DestroyFrame()
    {
        Destroy(this.gameObject);
    }
}
