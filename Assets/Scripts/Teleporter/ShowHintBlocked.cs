using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHintBlocked : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    private GameObject hint;
    [SerializeField]
    private GameObject teleporter;
    [SerializeField]
    private string[] requiredLvls;

    private bool blocked = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && blocked)
        {
            hint.SetActive(true);
        }
        if (!blocked && !teleporter.GetComponent<SceneTeleporter>().isActivated)
        {
            teleporter.GetComponent<SceneTeleporter>().Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            hint.SetActive(false);
    }

    public void LoadData(GameData gameData)
    {
        blocked = false;
        foreach (string lvl in requiredLvls)
        {
            if (!gameData.pipesCompleted.ContainsKey(lvl) || !gameData.pipesCompleted[lvl])
            {
                blocked = true;
            }
        }
        if (!blocked)
        {
            teleporter.GetComponent<SceneTeleporter>().Activate();
        }
    }

    public void SaveData(ref GameData gameData)
    {
        
    }
}