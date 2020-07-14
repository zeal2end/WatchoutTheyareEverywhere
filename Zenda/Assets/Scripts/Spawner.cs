using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fallingBlockPrefabs;
    public Vector2 secondsBetweenSpawnMinMax;
    float nextSpawnTime;

    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;

    Vector2 screenHalfSizeWorldUnits;
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnMinMax.y, secondsBetweenSpawnMinMax.x, Difficulty.GetDifficultyPercent());

            nextSpawnTime = Time.time + secondsBetweenSpawns;
            
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y );

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax); 

            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize );
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefabs, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            

            newBlock.transform.localScale = Vector2.one * spawnSize;

        }
    }
}
