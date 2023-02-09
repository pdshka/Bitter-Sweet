using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string scene;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> rayRecieversActivated;

    // initializing default values
    public GameData()
    {
        scene = "MainScene";
        this.playerPosition = Vector3.zero;
        this.rayRecieversActivated = new SerializableDictionary<string, bool>();
    }
}
