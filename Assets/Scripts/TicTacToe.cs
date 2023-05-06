using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TicTacToe : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI turnInfo;
    [SerializeField]
    private GameObject gameMenu;
    [SerializeField]
    private Button[] buttons;
    [SerializeField]
    private Sprite cross;
    [SerializeField]
    private Sprite zero;
    [SerializeField]
    private TextMeshProUGUI winnerInfo;
    [SerializeField]
    private Button retryButton;
    [SerializeField]
    private GameObject hint;
    [SerializeField]
    private MonkeyData monkey;

    private bool playerIsNear = false;
    private bool gameCompleted = false;
    private int[,] board = new int[3, 3];
    private int turn;

    private void Start()
    {
        ResetGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsNear && !gameCompleted && !gameMenu.active)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        ResetGame();
        gameMenu.SetActive(true);
    }

    private bool Winner(int[,] board, int player)
    {
        return
            (board[0, 0] == player && board[0, 1] == player && board[0, 2] == player) ||
            (board[1, 0] == player && board[1, 1] == player && board[1, 2] == player) ||
            (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player) ||
            (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player) ||
            (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player) ||
            (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player) ||
            (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
            (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player);
    }

    private void ResetGame()
    {
        StopCoroutine(MonkeyTurn());
        // reset buttons
        foreach(Button b in buttons)
        {
            b.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }
        // reset score
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = 0;
            }
        }
        
        turn = 0;
        winnerInfo.text = "";
        turnInfo.text = "Ваш ход";
        retryButton.gameObject.SetActive(false);
        EnableButtons();
    }

    public void MakeMove(int ind)
    {
        int i = ind / 3;
        int j = ind % 3;
        if (buttons[i * 3 + j].gameObject.GetComponent<Image>().color.a != 0) return;

        if (turn % 2 == 0)
        {
            buttons[i * 3 + j].gameObject.GetComponent<Image>().sprite = cross;
            board[i, j] = 1;
        }
        else
        {
            buttons[i * 3 + j].gameObject.GetComponent<Image>().sprite = zero;
            board[i, j] = -1;
        }
        buttons[i * 3 + j].gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        turn++;

        if (Winner(board, 1))
        {
            DisableButtons();
            gameCompleted = true;
            winnerInfo.text = "Вы победили!";
            turnInfo.text = "";
            StartCoroutine(CompleteMinigame());
        }
        else if (Winner(board, -1))
        {
            DisableButtons();
            winnerInfo.text = "Вы проиграли!";
            turnInfo.text = "";
            retryButton.gameObject.SetActive(true);
        }
        else if (turn == 9)
        {
            DisableButtons();
            winnerInfo.text = "Ничья!";
            turnInfo.text = "";
            retryButton.gameObject.SetActive(true);
        }
        else
        {
            if (turn % 2 != 0)
            {
                turnInfo.text = "Ход противника";
                StartCoroutine(MonkeyTurn());
            }
        }
    }

    private IEnumerator MonkeyTurn()
    {
        DisableButtons();
        yield return new WaitForSeconds(1f);

        int[] move = PC();

        MakeMove(move[0]*3 + move[1]);
        if (winnerInfo.text == "")
        {
            turnInfo.text = "Ваш ход";
            EnableButtons();
        }
    }

    private int[] PC()
    {
        List<int[]> possibleMoves = new List<int[]>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == 0)
                {
                    possibleMoves.Add(new int[2] { i, j });
                }
            }
        }

        int[] move = new int[2] { -1, -1 };

        foreach (int[] m in possibleMoves)
        {
            int[,] boardCopy = board.Clone() as int[,];
            boardCopy[m[0], m[1]] = -1;
            if (Winner(boardCopy, -1))
            {
                return m;
            }
            boardCopy[m[0], m[1]] = 1;
            if (Winner(boardCopy, 1))
            {
                move = m;
            }
        }
        if (move[1] != -1)
            return move;

        List<int[]> corners = new List<int[]>();
        foreach (int[] m in possibleMoves)
        {
            if (Enumerable.SequenceEqual(m, new int[2] { 0, 0 }) ||
                Enumerable.SequenceEqual(m, new int[2] { 0, 2 }) ||
                Enumerable.SequenceEqual(m, new int[2] { 2, 0 }) ||
                Enumerable.SequenceEqual(m, new int[2] { 2, 2 }))
            {
                corners.Add(m);
            }
        }

        if (corners.Count > 0)
        {
            return corners[Random.Range(0, corners.Count)];
        }

        List<int[]> edges = new List<int[]>();
        foreach (int[] m in possibleMoves)
        {
            if (Enumerable.SequenceEqual(m, new int[2] { 0, 1 }) ||
                Enumerable.SequenceEqual(m, new int[2] { 1, 0 }) ||
                Enumerable.SequenceEqual(m, new int[2] { 1, 2 }) ||
                Enumerable.SequenceEqual(m, new int[2] { 2, 1 }))
            {
                edges.Add(m);
            }
        }

        if (edges.Count > 0)
        {
            return edges[Random.Range(0, edges.Count)];
        }

        return possibleMoves[Random.Range(0, possibleMoves.Count)];
    }

    private void DisableButtons()
    {
        foreach (Button b in buttons)
            b.enabled = false;
    }

    private void EnableButtons()
    {
        foreach (Button b in buttons)
            b.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIsNear = true;
            if (!gameCompleted)
            {
                hint.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIsNear = false;
            hint.SetActive(false);
            gameMenu.SetActive(false);
        }
    }

    private IEnumerator CompleteMinigame()
    {
        yield return new WaitForSeconds(2f);
        monkey.CompleteMinigame();
    }
}
