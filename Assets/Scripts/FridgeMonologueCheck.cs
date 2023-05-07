using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeMonologueCheck : MonoBehaviour
{
    [SerializeField]
    private CustomerSpawner customerManager;
    [SerializeField]
    private GameObject monologue;

    private Stats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.money >= 100 && customerManager.cafeClosed)
        {
            if (!monologue.activeSelf)
                monologue.SetActive(true);
        }
        else
        {
            monologue.SetActive(false);
        }
    }
}
