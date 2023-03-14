using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeClosing : MonoBehaviour
{
    private bool playerIsNear = false;

    private void Update()
    {
        if (playerIsNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("CustomerManager").GetComponent<CustomerSpawner>().cafeClosed = true;
                foreach (var c in GameObject.FindGameObjectsWithTag("Customer"))
                {
                    c.GetComponent<Animator>().SetBool("CafeClosed", true);
                }
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
