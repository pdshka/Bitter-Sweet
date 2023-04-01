using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string scene;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> rayRecieversActivated;
    public SerializableDictionary<string, Vector3> teleporters;

    // initializing default values
    public GameData()
    {
        scene = "MainScene";
        this.playerPosition = Vector3.zero;
        this.rayRecieversActivated = new SerializableDictionary<string, bool>();
        SetTeleporters();
    }

    private void SetTeleporters()
    {
        teleporters = new SerializableDictionary<string, Vector3>();
        teleporters.Add("97b5e0da-34b0-4bcf-b775-db3aab49e260", new Vector3(0f, 2.5f, 0f)); // Cafe-Jungle
        teleporters.Add("00656c61-486a-4899-872b-03a5524b67c0", new Vector3(-6.5f, 5.5f, 0f)); // Jungle-Cafe
        teleporters.Add("08635aab-e008-46ef-8f9c-8762ee8030dd", new Vector3(1.5f, -6.5f, 0f)); // Jungle-Maze
        teleporters.Add("2ecc4656-b196-420e-87ce-910543c7cafc", new Vector3(0.5f, 9f, 0f)); // Jungle-WaterTemple
        teleporters.Add("5da5dfb1-abb4-45e6-9b73-7035e50bc49d", new Vector3(-0.5f, -8.5f, 0f)); // WaterTemple-Jungle
        teleporters.Add("ea251a03-822a-4c40-92dd-3cea989fe827", new Vector3(-0.5f, 7.5f, 0f)); // WaterTemple-Pipes
        teleporters.Add("edcf78b8-8005-4c43-bb60-5a78cc5fe010", new Vector3(-11.5f, 4.5f, 0f)); // Pipes-WaterTemple
        teleporters.Add("cb4f543d-a40e-4983-be7f-96acb46e4b6d", new Vector3(-0.5f, 2.5f, 0f)); // Maze-Jungle
        teleporters.Add("a48c36e9-f8c3-4ae7-a3c8-c465333108f2", new Vector3(-20.5f, -38f, 0f)); // Maze-Rays6
        teleporters.Add("3e8c9c2a-5992-43e2-8387-5a4b0fcb0eac", new Vector3(-6f, 5f, 0f)); // Rays6-Maze
        teleporters.Add("f09ae665-2eb4-4f21-b049-1ddc8c1899e0", new Vector3(-40.5f, -71f, 0f)); // Maze-Rays5
        teleporters.Add("a4233bb0-1e66-4651-8b5e-2ae736c97430", new Vector3(22.5f, -62f, 0f)); // Maze-Rays1
        teleporters.Add("0bed9dd9-710c-44a2-9986-aca3f3f3553e", new Vector3(38.5f, -58f, 0f)); // Maze-Rays3
        teleporters.Add("dbe6febb-d880-46ad-bc71-ef8850e85888", new Vector3(74.5f, -39f, 0f)); // Maze-Rays2 
        teleporters.Add("ea2078ae-d964-4e26-acf3-f47bc2dcf586", new Vector3(93.5f, -93f, 0)); // Maze-Rays4
        teleporters.Add("5c5b20d2-08dd-4df6-90db-7fa80be91853", new Vector3(-0.5f, 0.5f, 0)); // Rays1-Maze
        teleporters.Add("ae458fe0-7686-49db-a634-4debf9b4dd8a", new Vector3(-8.5f, 2.5f, 0)); // Rays2-Maze
        teleporters.Add("99c91028-5890-4612-98cb-b323b3f673ed", new Vector3(0.5f, 2.5f, 0)); // Rays3-Maze
        teleporters.Add("15068248-d126-4cb2-be68-d2c3a6fc60f2", new Vector3(-2.5f, 3.5f, 0)); // Rays4-Maze
        teleporters.Add("28692330-cade-41a3-9adf-b6e41a047331", new Vector3(-3, 6, 0)); // Rays5-Maze
        teleporters.Add("75970152-940d-461e-bc97-9d0d115ce9b1", new Vector3(-10.5f, 0.5f, 0)); // Jungle-MonkeyCoconuts
        teleporters.Add("d0ffc720-58c3-4db8-9594-646087819af9", new Vector3(-0.5f, 0.5f, 0)); // MonkeyCoconuts-Jungle 
        teleporters.Add("a63fe7d3-c232-45a1-affb-20dbaf88b7a9", new Vector3(6.5f, 0.5f, 0)); //MonkeyCoconuts-MonkeyTicTacToe
        teleporters.Add("0521ed4b-6d76-47ac-9f8b-c63e1fcd5837", new Vector3(-0.5f, 0.5f, 0)); // MonkeyTicTacToe-MonkeyCoconuts
        teleporters.Add("a321e93f-df27-484c-b48b-7444d66dc86d", new Vector3(6.5f, 0.5f, 0)); // MonkeyTicTacToe-MonkeyRockPaperScissors
        teleporters.Add("4fe64a98-af2a-4c44-8573-32a45c3522b8", new Vector3(-0.5f, 0.5f, 0)); // MonkeyRockPaperScissors-MonkeyTicTacToe
        teleporters.Add("ae4e55a3-f012-47cc-a2a4-a917a34d8678", new Vector3(6.5f, 0.5f, 0)); // MonkeyRockPaperScissors-MonkeyDialogue
        teleporters.Add("92d05804-1ed5-4a2b-a635-1f83c8eeecbd", new Vector3(-0.5f, 0.5f, 0)); // MonkeyDialogue-MonkeyRockPaperScissors
    }
}