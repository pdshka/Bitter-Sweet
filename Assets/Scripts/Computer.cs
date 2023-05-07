using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Computer : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    private CustomerSpawner customerManager;

    [Header("Buttons")]
    [SerializeField]
    private GameObject cafeManagerButton;
    [SerializeField]
    private GameObject bananaButton;
    [SerializeField]
    private GameObject blueberryButton;
    [SerializeField]
    private GameObject vanillaButton;
    [SerializeField]
    private GameObject screen;

    [Header("Machines")]
    [SerializeField]
    private GameObject bananaMachine;
    [SerializeField]
    private GameObject blueberryMachine;
    [SerializeField]
    private GameObject vanillaMachine;
    [SerializeField]
    private int machineCost = 150;

    private bool playerIsNear;
    private SerializableDictionary<string, bool> flavors;
    private GameObject[] machineButtons;
    private Stats playerStats;

    private void Start()
    {
        machineButtons = new GameObject[] { bananaButton, blueberryButton, vanillaButton };
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
    }

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

    private void FixedUpdate()
    {
        CheckButton("banana", bananaButton, bananaMachine);
        CheckButton("blueberry", blueberryButton, blueberryMachine);
        CheckButton("vanilla", vanillaButton, vanillaMachine);
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

    public void LoadData(GameData gameData)
    {
        flavors = gameData.fruitsCollected;
    }

    public void SaveData(ref GameData gameData)
    {
        
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
        cafeManagerButton.GetComponentInChildren<TMP_Text>().text = "3акрыть кафе";
        cafeManagerButton.GetComponent<Button>().onClick.RemoveAllListeners();
        cafeManagerButton.GetComponent<Button>().onClick.AddListener(CloseCafe);
    }

    public void BuyMachine(GameObject machine)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>().money -= machineCost;
        machine.SetActive(true);
        machine.GetComponent<IceCreamBox>().unlocked = true;
    }

    public void CheckButton(string flavor, GameObject button, GameObject machine)
    {
        if (flavors.ContainsKey(flavor) && flavors[flavor] &&
            playerStats.money >= machineCost &&
            !machine.activeSelf)
        {
                button.GetComponent<Button>().interactable = true;
        }
        else
        {
            button.GetComponent<Button>().interactable = false;
        }
    }
}
