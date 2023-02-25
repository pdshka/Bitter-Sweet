using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RiverObstacleGeneration : MonoBehaviour
{
    [SerializeField]
    private int obstaclesToFinish = 10;
    private int currentObstaclesCount = 0;
    [SerializeField]
    private int maxObstaclesOnScreen = 2;
    public int currentObstaclesOnScreen = 0;

    [SerializeField]
    private Transform[] spawnPositions;
    [SerializeField]
    private GameObject[] obstacles;

    private float reloadTime = 1f;
    private bool isReloading = false;

    private System.Random random;
    private bool finished = false;

    public GameObject win;

    private void Start()
    {
        random = new System.Random();
    }

    private void FixedUpdate()
    {
        if (!finished)
        {
            if (currentObstaclesCount == obstaclesToFinish)
            {
                if (currentObstaclesOnScreen == 0)
                {
                    StartCoroutine(PlayCutscene());
                }
            }
        }

        if (!isReloading)
        {
            if ((currentObstaclesOnScreen < maxObstaclesOnScreen) && (currentObstaclesCount < obstaclesToFinish))
            {
                CreateObstacle();
                StartCoroutine(Reload());
            }
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }

    private void CreateObstacle()
    {
        currentObstaclesCount++;
        currentObstaclesOnScreen++;
        //Vector3 pos = spawnPositions[random.Next(0, spawnPositions.Length)].position;
        float x = Random.Range(spawnPositions[0].position.x, spawnPositions[2].position.x);
        Vector3 pos = new Vector3(x, spawnPositions[0].position.y, 0);
        Instantiate(obstacles[random.Next(0, obstacles.Length)], pos, Quaternion.identity);

    }

    private IEnumerator PlayCutscene()
    {
        finished = true;
        win.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
