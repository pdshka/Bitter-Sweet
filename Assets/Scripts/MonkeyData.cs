using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyData : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    private string id;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public bool minigameCompleted;
    [SerializeField]
    private GameObject teleport;
    [SerializeField]
    private GameObject minigame;


    public void LoadData(GameData gameData)
    {
        gameData.monkeysPassed.TryGetValue(id, out minigameCompleted);
        if (minigameCompleted)
        {
            minigame.SetActive(false);
        }
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.monkeysPassed[id] = minigameCompleted;
    }

    public void CompleteMinigame()
    {
        minigameCompleted = true;
        minigame.SetActive(false);
        teleport.GetComponentInChildren<SceneTeleporter>().Activate();
    }
}
