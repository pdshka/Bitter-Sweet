using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour, IDataPersistence
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
    [SerializeField]
    private GameObject hint;

    private void Start()
    {
        hint.SetActive(false);
        GetComponent<Animator>().SetBool("isActivated", isActivated);
    }

    private void Update()
    {
        if (playerIsNear)
        {
            if (Input.GetKeyDown(KeyCode.E) && isActivated)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().UseTeleport(toID);
                Teleport();
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
        hint.SetActive(true);
        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            if (anim.enabled)
                anim.SetBool("isActivated", true);
        }
        else
        {
            Debug.LogError("animator " + id);
        }
    }
}
