using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;

    // initializing default values
    public GameData()
    {
        this.playerPosition = Vector3.zero;
    }
}
