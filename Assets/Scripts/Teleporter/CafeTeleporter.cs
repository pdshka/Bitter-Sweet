using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class CafeTeleporter : MonoBehaviour, IDataPersistence
{
    public bool isActivated = true;

    [SerializeField]
    public string id;
    [SerializeField]
    private string toID;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private bool playerIsNear = false;
    public string sceneName;
    private GameObject player;

    [SerializeField]
    private CustomerSpawner customerManager;
    public int cost;

    private bool cutsceneStarted = false;
    [SerializeField]
    private GameObject cutscene;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (playerIsNear && !cutsceneStarted)
        {
            if (Input.GetKeyDown(KeyCode.E) && isActivated && customerManager.cafeClosed && player.GetComponent<Stats>().money >= cost)
            {
                player.GetComponent<PlayerController>().UseTeleport(toID);
                player.GetComponent<Stats>().money -= cost;
                StartCoroutine(PlayCutscene());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerIsNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerIsNear = false;
    }

    private void Teleport()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadData(GameData gameData)
    {
        if (gameData.teleportersActivated.ContainsKey(id))
        {
            isActivated = gameData.teleportersActivated[id];
        }

        if (isActivated)
        {
            Activate();
        }
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.teleportersActivated[id] = isActivated;
    }

    public void Activate()
    {
        isActivated = true;
    }

    IEnumerator PlayCutscene()
    {
        cutsceneStarted = true;
        cutscene.GetComponent<PlayableDirector>().Play();
        yield return new WaitForSeconds((float)cutscene.GetComponent<PlayableDirector>().playableAsset.duration);
        Teleport();
    }
}
