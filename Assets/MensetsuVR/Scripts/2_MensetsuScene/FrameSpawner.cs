using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabEachFrames;
    GameObject[] spawnPoints;
    string spownPointsTag = "SpawnPoint";
    float spawnInterval;
    float elapsedTime = 0f;
    bool isActived = false;

    public void Init()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag(spownPointsTag);
        isActived = false;
        elapsedTime = 0f;
    }

    //DifficultyControllerによって呼ばれる
    public void SetSpawnInterval(float newValue)
    {
        spawnInterval = newValue;
    }

    public void StartSpawn()
    {
        isActived = true;
    }

    public void StopSpawn()
    {
        isActived = false;
    }

    void Update()
    {
        if (!isActived) return;

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnInterval)
        {
            SpawnFrame();
            elapsedTime = 0f;
        }
    }

    void SpawnFrame()
    {
        int indexSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Length);
        Vector3 ofThisTimeSpawnPoint = spawnPoints[indexSpawnPoint].transform.position;

        int indexEachFrame = UnityEngine.Random.Range(0, prefabEachFrames.Length);

        Instantiate(prefabEachFrames[indexEachFrame], ofThisTimeSpawnPoint, Quaternion.identity);
    }
}
