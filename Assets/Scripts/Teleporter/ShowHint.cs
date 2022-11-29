using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHint : MonoBehaviour
{
    [SerializeField]
    private GameObject hint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            hint.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            hint.SetActive(false);
    }
}