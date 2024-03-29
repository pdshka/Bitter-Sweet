using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes : MonoBehaviour
{
    [SerializeField] private Button continueGameButton;

    // Start is called before the first frame update
    void Start()
    {
        if (!DataPersistenceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Exit()
    {
       Application.Quit();
    }
    public void MainScene()
    {
        SceneManager.LoadScene("CafeHints");
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadScene("Menu");
    }

    public void OnNewGameClicked()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync(DataPersistenceManager.instance.GetSceneName());
    }

    public void OnContinueGameClicked()
    {
        SceneManager.LoadSceneAsync(DataPersistenceManager.instance.GetSceneName());
    }
}
