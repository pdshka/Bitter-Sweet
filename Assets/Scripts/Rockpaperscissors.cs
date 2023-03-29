using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rockpaperscissors : MonoBehaviour
{
    [SerializeField]
    private GameObject hint;
    [SerializeField]
    private TextMeshProUGUI TextElement;
    [SerializeField]
    private TextMeshProUGUI PScore;
    [SerializeField]
    private TextMeshProUGUI MScore;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Image MonkeyImg;
    [SerializeField]
    private Image PlayerImg;
    //[SerializeField]
    //private Animation animobject;
    //[SerializeField]
    //private AnimationClip anim;
    public Button Rock;
    public Button Scissors;
    public Button Paper;
    public Button CloseWinIfLose;
    public Button CloseWinIfWin;
    public Button RepeatGame;
    private int PlayerScore = 0;
    private int MonkeyScore = 0;
    private bool On = false;
    private bool playerIsNear = false;
    private bool win;
    public Sprite background;

    public Sprite[] playersprites;
    public Sprite[] monkeysprites;
    System.Random rnd = new System.Random();
    enum Variants
    {
        Rock,
        Scissors,
        Paper
    }
    private void Update()
    {
        if (!On && Input.GetKeyDown(KeyCode.E) && playerIsNear && !win)
        {
            hint.SetActive(false);
            panel.SetActive(true);
            On = true;
        }

    }
    void Start()
    {
        //anim.legacy = true;
        Invoke("AnimPlay", 1f);
        //TextElement.text = "Выберите ход";
        PScore.text = $"{PlayerScore}";
        MScore.text = $"{MonkeyScore}";
        Rock.onClick.AddListener(stone);
        Scissors.onClick.AddListener(scissors);
        Paper.onClick.AddListener(paper);
        CloseWinIfLose.onClick.AddListener(panelclose);
        CloseWinIfWin.onClick.AddListener(panelclose);
        RepeatGame.onClick.AddListener(repeatgame);
        panel.GetComponent<Image>().sprite = background;
        panel.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
    }
    //void AnimPlay()
    //{
    //    animobject.Play(anim.name);
    //}

    void stone()
    {
        PlayerImg.sprite = playersprites[(int)Variants.Rock];
        var v = (Variants)rnd.Next(3);
        if (v == Variants.Rock)
        {
            //TextElement.text = "Ничья";
            MonkeyImg.sprite = playersprites[(int)Variants.Rock];
        }
        else if (v == Variants.Scissors)
        {
            //TextElement.text = "Вы выиграли этот раунд";
            PlayerScore += 1;
            MonkeyImg.sprite = playersprites[(int)Variants.Scissors];
        }
        else
        {
            //TextElement.text = "Вы проиграли этот раунд";
            MonkeyScore += 1;
            MonkeyImg.sprite = playersprites[(int)Variants.Paper];
        }
        CheckWinOrLose();

    }
    void scissors()
    {
        PlayerImg.sprite = playersprites[(int)Variants.Scissors];
        var v = (Variants)rnd.Next(3);
        if (v == Variants.Scissors)
        {
            //TextElement.text = "Ничья";
            MonkeyImg.sprite = playersprites[(int)Variants.Scissors];
        }
        else if (v == Variants.Paper)
        {
            //TextElement.text = "Вы выиграли этот раунд";
            PlayerScore += 1;
            MonkeyImg.sprite = playersprites[(int)Variants.Paper];
        }
        else
        {
            //TextElement.text = "Вы проиграли этот раунд";
            MonkeyScore += 1;
            MonkeyImg.sprite = playersprites[(int)Variants.Rock];
        }
        CheckWinOrLose();
    }
    void paper()
    {
        var v = (Variants)rnd.Next(3);
        if (v == Variants.Paper)
        {
            //TextElement.text = "Ничья";
            MonkeyImg.sprite = playersprites[(int)Variants.Paper];
        }
        else if (v == Variants.Rock)
        {
            MonkeyImg.sprite = playersprites[(int)Variants.Rock];
            //TextElement.text = "Вы выиграли этот раунд";
            PlayerScore += 1;
        }
        else
        {
            MonkeyImg.sprite = playersprites[(int)Variants.Scissors];
            //TextElement.text = "Вы проиграли этот раунд";
            MonkeyScore += 1;
        }
        CheckWinOrLose();
    }
    void CheckWinOrLose()
    {
        PScore.text = $"{PlayerScore}";
        MScore.text = $"{MonkeyScore}";
        if (PlayerScore == 3)
        {
            for (int i = 0; i < 7; i++)
                panel.transform.GetChild(i).gameObject.SetActive(false);
            panel.transform.GetChild(7).gameObject.SetActive(true);
            TextElement.text = "Вы выиграли";
            panel.transform.GetChild(10).gameObject.SetActive(true);
            win = true;
        }
        else if (MonkeyScore == 3)
        {
            for (int i = 0; i < 7; i++)
                panel.transform.GetChild(i).gameObject.SetActive(false);
            panel.transform.GetChild(7).gameObject.SetActive(true);
            TextElement.text = "Вы проиграли";
            panel.transform.GetChild(9).gameObject.SetActive(true);
            panel.transform.GetChild(8).gameObject.SetActive(true);
            //panel.SetActive(false);
            //On = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsNear = true;
            if (!win)
                hint.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsNear = false;
            panel.SetActive(false);
            On = false;
            hint.SetActive(false);
        }
    }
    private void panelclose()
    {
        panel.SetActive(false);
    }
    private void repeatgame()
    {
        for (int i = 7; i <= 9; i++)
            panel.transform.GetChild(i).gameObject.SetActive(false);
        for (int i = 0; i < 7; i++)
            panel.transform.GetChild(i).gameObject.SetActive(true);
        MonkeyScore = 0;
        PlayerScore = 0;
        PScore.text = "0";
        MScore.text = "0";
    }
}
