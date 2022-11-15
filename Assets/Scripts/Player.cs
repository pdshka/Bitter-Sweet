using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Stats stats;

    void Start()
    {
        stats = GetComponent<Stats>();
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
        // TODO: death animation or smth
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
