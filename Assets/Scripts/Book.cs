using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject[] letters;
    //0 - purple, 1 - green, 2 - red, 3 - blue
    [SerializeField]
    private Sprite[] LettersSprites;
    //0 - purple, 1 - green, 2 - red, 3 - blue
    [SerializeField]
    private Button[] buttons;
    //0 - purple, 1 - green, 2 - red, 3 - blue, 4 - left, 5 - right
    [SerializeField]
    private Sprite[] LeftLetters = new Sprite[5];
    [SerializeField]
    private Sprite[] RightLetters = new Sprite[5];
    private Letters color;
    private enum Letters { purple = 0, green = 1, red = 2, blue = 3 };
    private bool On = false;
    private float timeX = 0.07f;
    void Start()
    {
        color = Letters.purple;
        buttons[0].onClick.AddListener(() => ChooseLetter(Letters.purple));
        buttons[1].onClick.AddListener(() => ChooseLetter(Letters.green));
        buttons[2].onClick.AddListener(() => ChooseLetter(Letters.red));
        buttons[3].onClick.AddListener(() => ChooseLetter(Letters.blue));
        buttons[5].onClick.AddListener(() => StartCoroutine(NextPage()));
        buttons[4].onClick.AddListener(() => StartCoroutine(PreviouslyPage()));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            if (On)
            {
                panel.SetActive(false);
                On = false;
            }
            else
            {
                On = true;
                panel.SetActive(true);
                letters[0].SetActive(true);
                for (int i = 1; i < 4; i++)
                    letters[i].SetActive(false);
                panel.GetComponent<Image>().sprite = LettersSprites[0];
                color = Letters.purple;
            }
    }
    void ChooseLetter(Letters let)
    {
        letters[(int)color].SetActive(false);
        if (let != color)
        {
            if (color > let)
                StartCoroutine(Left(let));
            else StartCoroutine(Right(let));

            color = let;
        }
    }
    private IEnumerator NextPage()
    {
        if ((color == Letters.blue || color == Letters.green) && letters[(int)color].transform.GetChild(0).gameObject.activeSelf)
        {
            letters[(int)color].SetActive(false);
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(timeX);
                panel.GetComponent<Image>().sprite = LeftLetters[i];
            }
            panel.GetComponent<Image>().sprite = LettersSprites[(int)color];
            letters[(int)color].transform.GetChild(0).gameObject.SetActive(false);
            letters[(int)color].transform.GetChild(1).gameObject.SetActive(true);
            letters[(int)color].SetActive(true);
        }
    }
    private IEnumerator PreviouslyPage()
    {
        if ((color == Letters.blue || color == Letters.green) && letters[(int)color].transform.GetChild(1).gameObject.activeSelf)
        {
            letters[(int)color].SetActive(false);
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(timeX);
                panel.GetComponent<Image>().sprite = RightLetters[i];
            }
            panel.GetComponent<Image>().sprite = LettersSprites[(int)color];
            letters[(int)color].transform.GetChild(1).gameObject.SetActive(false);
            letters[(int)color].transform.GetChild(0).gameObject.SetActive(true);
            letters[(int)color].SetActive(true);
        }
    }

    private IEnumerator Left(Letters let)
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(timeX);
            panel.GetComponent<Image>().sprite = RightLetters[i];
        }
        panel.GetComponent<Image>().sprite = LettersSprites[(int)let];
        letters[(int)let].SetActive(true);

    }
    private IEnumerator Right(Letters let)
    {
        for (int i = 0; i < 5; i++)
        {
            panel.GetComponent<Image>().sprite = LeftLetters[i];
            yield return new WaitForSeconds(timeX);
        }
        panel.GetComponent<Image>().sprite = LettersSprites[(int)let];
        letters[(int)let].SetActive(true);
    }
}
