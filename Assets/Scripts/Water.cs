using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;
    private int damage = 1;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player.transform.parent == null)
            {
                if (player.GetComponent<Stats>().health - damage > 0)
                    Teleport();
                player.GetComponent<Stats>().TakeDamage(damage);
            }
        }
    }

    private void Teleport()
    {
        player.transform.position = respawnPoint.position;
    }
}
