using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour
{
    [SerializeField]
    private string id;
    [SerializeField]
    private string toID;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private bool playerIsNear = false;
    public string sceneName;

    private void Update()
    {
        if (playerIsNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
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
}
