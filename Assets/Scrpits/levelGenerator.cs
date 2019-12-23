using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    [Header("Transforms")]
    public Transform player;

    [Header("Gameobjects")]
    public GameObject platformPrefab;

    [Header("Variables")]
    public int numberOfPlatforms;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    public float offset = 1f;


    Vector3 spawnPosition;

    private void Start()
    {
        spawnPosition = new Vector3(0f, -4.03f + 0.2f, 0f);

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void Update()
    {
        Debug.Log("Spawn position: "+spawnPosition.y+" Player position:"+player.position.y);

        if (player.position.y + offset >= spawnPosition.y)
        {
            for (int i = 0; i < numberOfPlatforms; i++)
            {
                spawnPosition.y += Random.Range(minY, maxY);
                spawnPosition.x = Random.Range(-levelWidth, levelWidth);
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }


}
