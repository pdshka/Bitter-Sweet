using System.Collections;
using System.Collections.Generic;
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

    private bool playerIsNear = false;
    private bool gameCompleted = false;
    private int[,] board = new int[3, 3];
    private int turn;

    private void Start()
    {
        ResetGame();
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
        // reset buttons
        foreach(Button b in buttons)
        {
            b.GetComponent<Image>().enabled = false;
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
    }

    private void MakeMove(ref int[,] board, int i, int j)
    {
        if (buttons[i*3 + j].GetComponent<Image>().enabled) return;

        if (turn % 2 == 0)
        {
            buttons[i * 3 + j].GetComponent<Image>().sprite = cross;
            board[i, j] = 1;
        }
        else
        {
            buttons[i * 3 + j].GetComponent<Image>().sprite = zero;
            board[i, j] = -1;
        }
        buttons[i * 3 + j].GetComponent<Image>().enabled = true;

        if (Winner(board, 1))
        {
            gameCompleted = true;
            winnerInfo.text = "Вы победили!";
            turnInfo.text = "";
        }
        else if (Winner(board, -1))
        {
            winnerInfo.text = "Вы проиграли!";
            turnInfo.text = "";
            retryButton.gameObject.SetActive(true);
        }
        else if (turn == 8)
        {
            winnerInfo.text = "Ничья!";
            turnInfo.text = "";
            retryButton.gameObject.SetActive(true);
        }

        turn++;
    }

    public void MakeMove(int i, int j)
    {
        MakeMove(ref board, i, j);
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
        }
    }
}
