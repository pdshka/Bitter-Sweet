using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamBox : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    public string id;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
    public bool unlocked;

    public IceCream iceCream;

    private bool playerIsNear;
    private Stats playerStats;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
    }

    private void Update()
    {
        if (playerIsNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerStats.iceCream = iceCream;
            }
        }
    }

    public void LoadData(GameData gameData)
    {
        if (gameData.iceCreamBoxes.ContainsKey(id) && gameData.iceCreamBoxes[id])
        {
            unlocked = gameData.iceCreamBoxes[id];
        }
        gameObject.SetActive(unlocked);
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.iceCreamBoxes[id] = unlocked;
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
