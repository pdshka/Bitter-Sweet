using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayReceiverScript : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    private string id;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    [SerializeField]
    private Sprite activatedSprite;

    private bool isActivated = false;

    public void LoadData(GameData gameData)
    {
        gameData.rayRecieversActivated.TryGetValue(id, out isActivated);
        if (isActivated)
        {
            Activate();
        }
    }

    public void SaveData(ref GameData gameData)
    {
        if (gameData.rayRecieversActivated.ContainsKey(id))
        {
            gameData.rayRecieversActivated.Remove(id);
        }
        gameData.rayRecieversActivated.Add(id, isActivated);
    }

    public void Activate()
    {
        isActivated = true;
        GetComponent<SpriteRenderer>().sprite = activatedSprite;
    }
}
