using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class RiverObstacleGeneration : MonoBehaviour
{
    [SerializeField]
    private int obstaclesToFinish = 10;
    private int currentObstaclesCount = 0;
    [SerializeField]
    private int maxObstaclesOnScreen = 2;
    public int currentObstaclesOnScreen = 0;

    [SerializeField]
    private Transform leftBorder;
    [SerializeField]
    private Transform rightBorder;
    [SerializeField]
    private GameObject[] obstacles;

    private float reloadTime = 1f;
    private bool isReloading = false;

    private System.Random random;
    private bool finished = false;

    public GameObject cutscene;
    private GameObject player;

    private void Start()
    {
        random = new System.Random();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Reload(3f));
    }

    private void FixedUpdate()
    {
        if (!finished)
        {
            if (currentObstaclesCount >= obstaclesToFinish)
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
                StartCoroutine(Reload(reloadTime));
            }
        }
    }

    private IEnumerator Reload(float reloadTime)
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
        //float x = Random.Range(leftBorder.position.x, rightBorder.position.x);
        //float x = player.transform.position.x;
        float x = Random.Range(player.transform.position.x - 1, player.transform.position.x + 1);
        if (x < leftBorder.position.x)
            x = leftBorder.position.x;
        else if (x > rightBorder.position.x)
            x = rightBorder.position.x;
        Vector3 pos = new Vector3(x, leftBorder.position.y, 0);
        int spawned_obstacle_num = random.Next(0, obstacles.Length);
        Instantiate(obstacles[spawned_obstacle_num], pos, Quaternion.identity);

        int gen_second = random.Next(3);
        if (gen_second > 0)
        {
            currentObstaclesCount++;
            currentObstaclesOnScreen++;
            x = Random.Range(leftBorder.position.x, rightBorder.position.x);
            pos = new Vector3(x, leftBorder.position.y, 0);
            int new_obstacle_num = spawned_obstacle_num;
            while (new_obstacle_num == spawned_obstacle_num)
                new_obstacle_num = random.Next(0, obstacles.Length);
            Instantiate(obstacles[new_obstacle_num], pos, Quaternion.identity);
        }
    }

    private IEnumerator PlayCutscene()
    {
        finished = true;
        cutscene.GetComponent<PlayableDirector>().Play();
        yield return new WaitForSeconds(3f);
        player.GetComponent<PlayerController>().UseTeleport("5da5dfb1-abb4-45e6-9b73-7035e50bc49d");
        SceneManager.LoadScene("WaterTemple");
    }
}
