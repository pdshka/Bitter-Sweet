using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Computer : MonoBehaviour
{
    [SerializeField]
    private CustomerSpawner customerManager;
    [SerializeField]
    private GameObject cafeManagerButton;
    [SerializeField]
    private GameObject screen;

    private bool playerIsNear;

    private void Update()
    {
        if (playerIsNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                screen.SetActive(!screen.activeSelf);
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
        {
            playerIsNear = false;
            screen.SetActive(false);
        }
    }

    public void CloseCafe()
    {
        customerManager.cafeClosed = true;
        foreach (var c in GameObject.FindGameObjectsWithTag("Customer"))
        {
            c.GetComponent<Animator>().SetBool("CafeClosed", true);
        }
        cafeManagerButton.GetComponentInChildren<TMP_Text>().text = "Открыть кафе";
        cafeManagerButton.GetComponent<Button>().onClick.RemoveAllListeners();
        cafeManagerButton.GetComponent<Button>().onClick.AddListener(OpenCafe);
    }

    public void OpenCafe()
    {
        customerManager.cafeClosed = false;
        cafeManagerButton.GetComponentInChildren<TMP_Text>().text = "Закрыть кафе";
        cafeManagerButton.GetComponent<Button>().onClick.RemoveAllListeners();
        cafeManagerButton.GetComponent<Button>().onClick.AddListener(CloseCafe);
    }
}
