using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanillaChecker : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    private GameObject vanilla;
    [SerializeField]
    private string[] requiredLvls;

    public void LoadData(GameData gameData)
    {
        bool blocked = false;
        foreach (string lvl in requiredLvls)
        {
            if (!gameData.rayRecieversActivated.ContainsKey(lvl) || !gameData.rayRecieversActivated[lvl])
            {
                blocked = true;
                break;
            }
        }
        if (!blocked)
        {
            vanilla.SetActive(true);
        }
    }

    public void SaveData(ref GameData gameData)
    {

    }
}
