using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverObstacleGeneration : MonoBehaviour
{
    private int obstaclesToFinish = 10;
    private int maxObstaclesOnScreen = 2;
    public int currentObstaclesOnScreen = 0;

    [SerializeField]
    private Transform[] spawnPositions;
    [SerializeField]
    private GameObject[] obstacles;

    private float reloadTime = 4f;
    private bool isReloading = false;

    private System.Random random;

    private void Start()
    {
        random = new System.Random();
    }

    private void FixedUpdate()
    {
        if (!isReloading)
        {
            if (currentObstaclesOnScreen < maxObstaclesOnScreen)
            {
                CreateObstacle();
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }

    void CreateObstacle()
    {
        currentObstaclesOnScreen++;
        Vector3 pos = spawnPositions[random.Next(0, spawnPositions.Length)].position;
        Instantiate(obstacles[random.Next(0, obstacles.Length)], pos, Quaternion.identity);

    }
}
