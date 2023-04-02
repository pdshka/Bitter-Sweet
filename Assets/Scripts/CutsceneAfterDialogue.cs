using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class CutsceneAfterDialogue : MonoBehaviour
{
    [SerializeField]
    private DialogueManager DM;
    [SerializeField]
    private GameObject cutscene;
    private bool cutsceneStarted = false;
    [SerializeField]
    private string nextSceneName;

    private void Update()
    {
        if (!cutsceneStarted && DM.dialogueEnded)
        {
            StartCoroutine(PlayCutscene());
        }
    }

    IEnumerator PlayCutscene()
    {
        cutsceneStarted = true;
        cutscene.GetComponent<PlayableDirector>().Play();
        yield return new WaitForSeconds((float)cutscene.GetComponent<PlayableDirector>().playableAsset.duration);
        SceneManager.LoadScene(nextSceneName);
    }
}
