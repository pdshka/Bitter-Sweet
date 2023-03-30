using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrossZero : MonoBehaviour
{

    public Text info; // показ следующего хода "О" или "Х"
    public Text winText; // вывод сообщения в случаи победы
    public Button newGame; // кнопка начала новой игры
    public Button button; // шаблон клетки
    public float offset; // расстояние между клетками
    public RectTransform panel; // пустой RectTransform, относительно которого будет сборка

    private Button[] myButtons;
    private int index;
    private int[,] grid;
    private int hor, ver;
    private int horLast, verLast;

    void Start()
    {
        newGame.onClick.AddListener(() => { GetNew(); });
        BuildGrid();
        GetNew();
    }

    void GetNew()
    {
        newGame.interactable = false;
        ver = 0;
        hor = 0;
        horLast = 100;
        verLast = 100;
        winText.text = string.Empty;
        index = Random.Range(0, 2);
        SetInfo(index);
        foreach (Button b in myButtons)
        {
            b.GetComponentInChildren<Text>().text = string.Empty;
            b.interactable = true;
        }
        ResetButton();
    }

    void ResetButton()
    {
        int i = 0;
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                myButtons[i].onClick.RemoveAllListeners();
                Button b_tmp = myButtons[i];
                int i_tmp = -(i + 1);
                myButtons[i].onClick.AddListener(() => { SetGrid(i_tmp); SetButton(b_tmp); });
                grid[y, x] = i_tmp;
                i++;
            }
        }
    }

    void BuildGrid() // создание сетки на основе шаблонов
    {
        float sizeX = button.GetComponent<RectTransform>().sizeDelta.x + offset;
        float sizeY = button.GetComponent<RectTransform>().sizeDelta.y + offset;
        float posX = -sizeX * 3 / 2 - sizeX / 2;
        float posY = Mathf.Abs(posX);
        float Xreset = posX;
        int i = 0;
        grid = new int[3, 3];
        myButtons = new Button[3 * 3];
        for (int y = 0; y < 3; y++)
        {
            posY -= sizeY;
            for (int x = 0; x < 3; x++)
            {
                posX += sizeX;
                myButtons[i] = Instantiate(button) as Button;
                RectTransform b = myButtons[i].GetComponent<RectTransform>();
                b.SetParent(panel);
                b.localScale = Vector3.one;
                b.anchoredPosition = new Vector2(posX, posY);
                b.gameObject.name = "Button_ID_" + i;
                i++;
            }
            posX = Xreset;
        }
        button.gameObject.SetActive(false);
    }

    void SetInfo(int id)
    {
        if (id == 1) info.text = "X"; else info.text = "O";
    }

    void Horizontal(int id)
    {
        if (id == 0 && horLast == 100 || id == 1 && horLast == 100)
        {
            horLast = id;
            hor++;
        }
        else if (id == horLast)
        {
            hor++;
        }
        else
        {
            hor = 0;
        }

        if (hor == 3)
        {
            Winner();
        }
    }

    void Vertical(int id)
    {
        if (id == 0 && verLast == 100 || id == 1 && verLast == 100)
        {
            verLast = id;
            ver++;
        }
        else if (verLast == id)
        {
            ver++;
        }
        else
        {
            ver = 0;
        }

        if (ver == 3)
        {
            Winner();
        }
    }

    void Winner()
    {
        newGame.interactable = true;
        winText.text = "! You Win !";
        foreach (Button b in myButtons)
        {
            b.interactable = false;
        }
    }

    void CheckResult()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                // проверка по горизонтали и вертикали, наличия трех "0" или "1"
                Horizontal(grid[y, x]);
                Vertical(grid[x, y]);
            }
            horLast = 100;
            verLast = 100;
            ver = 0;
            hor = 0;
        }

        // проверка по диагонали, наличия трех "0" или "1"
        if (grid[0, 0] == 0 && grid[1, 1] == 0 && grid[2, 2] == 0 || grid[0, 0] == 1 && grid[1, 1] == 1 && grid[2, 2] == 1
           || grid[2, 0] == 0 && grid[1, 1] == 0 && grid[0, 2] == 0 || grid[2, 0] == 1 && grid[1, 1] == 1 && grid[0, 2] == 1)
        {
            Winner();
        }
    }

    void SetGrid(int j)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (grid[y, x] == j)
                {
                    grid[y, x] = index;
                }
            }
        }

        CheckResult();
    }

    void SetButton(Button button)
    {
        button.GetComponentInChildren<Text>().text = info.text;
        if (index == 1) index = 0; else index = 1;
        SetInfo(index);
        button.interactable = false;
    }
}