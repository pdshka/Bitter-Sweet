using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeData : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    public string id;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private Quaternion r;
    public bool lvlCompleted;

    private void OnDestroy()
    {
        r = gameObject.transform.rotation;
    }

    public void LoadData(GameData gameData)
    {
        if (gameData.pipesRotations.ContainsKey(id))
        {
            gameObject.transform.rotation = gameData.pipesRotations[id];
        }
    }

    public void SaveData(ref GameData gameData)
    {
        if (lvlCompleted)
            gameData.pipesRotations[id] = r;
    }
}
