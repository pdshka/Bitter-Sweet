using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> rayRecieversActivated;

    // initializing default values
    public GameData()
    {
        this.playerPosition = Vector3.zero;
        this.rayRecieversActivated = new SerializableDictionary<string, bool>();
    }
}
