using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Stats stats;
    private PlayerController playerController;

    void Start()
    {
        stats = GetComponent<Stats>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (stats.health <= 0)
            Die();

        // test function for taking damage
        if (Input.GetKeyDown(KeyCode.T))
        {
            stats.TakeDamage(1);
        }
    }

    public void Die()
    {
        playerController.UseTeleport("97b5e0da-34b0-4bcf-b775-db3aab49e260");
        stats.health = 3;
        SceneManager.LoadScene("MainScene");
    }
}
