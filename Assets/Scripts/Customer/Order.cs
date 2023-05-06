using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public IceCream iceCream;
    public SpriteRenderer flavorSprite;
    private bool playerIsNear = false;
    private Stats playerStats;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
    }

    private void Update()
    {
        if (playerIsNear)
        {
            if (Input.GetKeyDown(KeyCode.E) && (playerStats.iceCream != null) && (playerStats.iceCream.flavor == iceCream.flavor))
            {
                GetComponentInParent<Animator>().SetBool("Waiting", false);
                playerStats.money += iceCream.cost;
                playerStats.iceCream = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerIsNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerIsNear = false;
    }
}
