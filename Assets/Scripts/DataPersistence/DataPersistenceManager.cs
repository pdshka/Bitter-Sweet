using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple Data Persistence Managers found!");
        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // TODO: Load saved data from the file

        // no data -> new game
        if (this.gameData == null)
        {
            Debug.Log("No data found. Starting a new game.");
            NewGame();
        }

        // TODO: Push loaded data to other scripts
    }

    public void SaveGame()
    {
        // TODO: pass data to other scripts to update

        // TODO: save data to a file
    }
}
