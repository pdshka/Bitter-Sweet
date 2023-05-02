using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour, IDataPersistence
{
    private bool isCollected;

    [SerializeField]
    private string id;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private bool playerIsNear = false;

    private void Start()
    {
        if (id == "")
        {
            Debug.LogError("У фрукта отсутствует id");
        }
    }

    private void Update()
    {
        if (playerIsNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Collect();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerIsNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsNear = false;
    }

    public void LoadData(GameData gameData)
    {
        if (gameData.fruitsCollected.ContainsKey(id))
        {
            isCollected = gameData.fruitsCollected[id];
        }

        if (isCollected)
        {
            Collect();
        }
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.fruitsCollected[id] = isCollected;
    }

    public void Collect()
    {
        isCollected = true;
        gameObject.SetActive(false);
    }
}
