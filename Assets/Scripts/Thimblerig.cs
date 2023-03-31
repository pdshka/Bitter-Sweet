using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Thimblerig : MonoBehaviour
{
    [SerializeField]
    private Sprite[] health_sprites;
    [SerializeField]
    private Sprite CoconutBall;
    [SerializeField]
    private Sprite CoconutImage;
    [SerializeField]
    private Sprite CoconutEmpty;
    [SerializeField]
    private Sprite ImageLose;
    [SerializeField]
    private Sprite ImageWin;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject[] coconut;
    [SerializeField]
    private GameObject[] Buttons;
    [SerializeField]
    private TextMeshProUGUI Rounds;
    [SerializeField]
    private Animator[] Animations;
    [SerializeField]
    private GameObject HealthBar;
    [SerializeField]
    private GameObject ImageIfWin;
    [SerializeField]
    private GameObject ImageIfLose;
    [SerializeField]
    private GameObject hint;
    [SerializeField]
    private GameObject TextWin;
    [SerializeField]
    private Sprite Background;
    private int round = 1;
    private bool On = false;
    private int countloses = 0;
    private float timer = 0.0f;
    private System.Random rnd = new System.Random();
    private int win;
    private bool gamewin = false;
    private bool PlayerIsNear = false;

    [SerializeField]
    private MonkeyData monkey;

    private void Start()
    {


        Buttons[0].GetComponent<Button>().onClick.AddListener(StartGame);
        ImageIfWin.GetComponent<Image>().sprite = ImageWin;
        ImageIfLose.GetComponent<Image>().sprite = ImageLose;
        ImageIfWin.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        ImageIfLose.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        for (int i = 0; i < coconut.Length; i++)
        {
            coconut[i].GetComponent<Image>().sprite = CoconutImage;
            coconut[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        panel.GetComponent<Image>().sprite = Background;
        panel.GetComponent<Image>().color = new Color32(255, 255, 225, 255);

    }

    private void Update()
    {
        if (!panel.activeSelf && Input.GetKeyDown(KeyCode.E) && PlayerIsNear && !gamewin)
        {
            hint.SetActive(false);
            panel.SetActive(true);
        }
        if (On)
            timer += Time.deltaTime;
        if (On && timer >= Animations[0].GetCurrentAnimatorStateInfo(0).length)
            for (int i = 1; i < Math.Min(round + 2, 5); i++)
            {
                if (round == 3 && i == 4)
                    break;
                Buttons[i].SetActive(true);
                coconut[i - 1].transform.GetChild(0).gameObject.SetActive(true);
                Buttons[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(coconut[i - 1].GetComponent<RectTransform>().anchoredPosition.x, -173f);
            }
    }
    void ClearBall()
    {
        coconut[win - 1].GetComponent<Image>().sprite = CoconutImage;
    }
    private void GameSet(bool Pred, bool AnimStart)
    {
        if (AnimStart)
        {
            if (round == 1)
                win = rnd.Next(1, 3);
            else if (round == 2 || round == 3)
                win = rnd.Next(1, 4);
            else if (round == 4 || round == 5)
                win = rnd.Next(1, 5);
        }
        for (int i = 1; i < Math.Min(round + 2, 5); i++)
        {
            if (round == 3 && i == 4)
                break;
            coconut[i - 1].SetActive(Pred);
            Buttons[i].SetActive(false);
            if (AnimStart)
            {
                Buttons[i].GetComponent<Button>().onClick.RemoveAllListeners();
                if (i == win)
                {

                    Buttons[i].GetComponent<Button>().onClick.AddListener(Win);
                }
                else Buttons[i].GetComponent<Button>().onClick.AddListener(Lose);
                coconut[i - 1].SetActive(AnimStart);
                coconut[i - 1].transform.GetChild(0).gameObject.SetActive(!AnimStart);
                Animations[i - 1].SetInteger("Round", round);
            }
        }
        Debug.Log($"’Ó‰ {win}");
        if (AnimStart)
        {
            coconut[win - 1].GetComponent<Image>().sprite = CoconutBall;
            Invoke("ClearBall", 2.0f);
            ImageIfWin.SetActive(false);
            ImageIfLose.SetActive(false);
        }
        Buttons[0].SetActive(!Pred);
        On = Pred;
    }
    private void StartGame()
    {
        GameSet(true, true);
    }
    private void Lose()
    {
        timer = 0;
        countloses++;
        GameSet(false, false);
        ImageIfLose.SetActive(true);
        Rounds.text = $"{round}/5";
        HealthBar.GetComponent<Image>().sprite = health_sprites[countloses];
        if (countloses == 3)
        {
            round = 1;
            countloses = 0;
            ImageIfLose.SetActive(false);
            On = false;
            panel.SetActive(false);
            Rounds.text = $"{round}/5";
            HealthBar.GetComponent<Image>().sprite = health_sprites[countloses];
        }
    }
    private void Win()
    {
        if (round < 5)
        {
            timer = 0;
            round += 1;
            GameSet(false, false);
            ImageIfWin.SetActive(true);
            Rounds.text = $"{round}/5";
        }
        else
        {
            On = false;
            gamewin = true;
            panel.transform.GetChild(2).gameObject.SetActive(false);
            Buttons[5].GetComponent<Button>().onClick.AddListener(() => panel.SetActive(false));
            Buttons[5].SetActive(true);
            TextWin.SetActive(true);
            Buttons[4].SetActive(false);
            for (int i = 0; i < 4; i++)
            {
                coconut[i].SetActive(false);
                Buttons[i].SetActive(false);
            }

            StartCoroutine(CompleteMinigame());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerIsNear = true;
            if (!gamewin)
                hint.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerIsNear = false;
            panel.SetActive(false);
            On = false;
            hint.SetActive(false);
        }
    }

    private IEnumerator CompleteMinigame()
    {
        yield return new WaitForSeconds(2f);
        monkey.CompleteMinigame();
    }
}

