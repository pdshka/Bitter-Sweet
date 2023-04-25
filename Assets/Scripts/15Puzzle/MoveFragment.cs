using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MoveFragment : MonoBehaviour
{
    private int number_chip;
    private int row_position;
    private int col_position;
    private int speed;
    private Vector3 empty_position = new Vector3(0, 0, 0);
    private bool can_move;
    public bool GameWin;
    private bool On = false;
    private Vector3 coordinate;
    void Start()
    {
        speed = 2;
        number_chip = int.Parse(gameObject.name);
        coordinate = transform.position;
    }
    void Update()
    {
        if (Global.GameOn && On && Input.GetKeyDown(KeyCode.E) && !can_move)
        {
            FindOnBoard();
            CalculateDirection();
        }
        if (can_move)
        {
            MoveChipOnBoard();
        }
    }

    void MoveChipOnBoard()
    {
        if (transform.position != empty_position)
        {
            transform.position = Vector3.MoveTowards(transform.position, empty_position, speed * Time.deltaTime);
        }
        else
        {
            can_move = false;
            CheckOnComplete();
        }
    }
    void CheckOnComplete()
    {
        int count = 1;

        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (Global.board[row, col] == Global.board2[row,col])
                {
                    Debug.Log(count);
                }
                else
                {
                    return;
                }
                count++;
                if (count == 16)
                {
                    Debug.Log("Победа");
                    Global.GameOn = false;
                }
            }
        }
    }
    void CalculateDirection()
    {
        try
        {
            if (Global.board[row_position + 1, col_position] == 0)
            {
                empty_position = new Vector3(transform.position.x + CreatePuzzle.split_x, transform.position.y, transform.position.z);
                Global.board[row_position, col_position] = 0;
                Global.board[row_position + 1, col_position] = number_chip;
                can_move = true;
            }
        }
        catch { }

        try
        {
            if (Global.board[row_position - 1, col_position] == 0)
            {
                empty_position = new Vector3(transform.position.x - CreatePuzzle.split_x, transform.position.y, transform.position.z);
                Global.board[row_position, col_position] = 0;
                Global.board[row_position - 1, col_position] = number_chip;
                can_move = true;
            }
        }
        catch { }

        try
        {
            if (Global.board[row_position, col_position + 1] == 0)
            {
                empty_position = new Vector3(transform.position.x, transform.position.y + CreatePuzzle.split_y, transform.position.z);
                Global.board[row_position, col_position] = 0;
                Global.board[row_position, col_position + 1] = number_chip;
                can_move = true;
            }
        }
        catch { }

        try
        {
            if (Global.board[row_position, col_position - 1] == 0)
            {
                empty_position = new Vector3(transform.position.x, transform.position.y - CreatePuzzle.split_y, transform.position.z);
                Global.board[row_position, col_position] = 0;
                Global.board[row_position, col_position - 1] = number_chip;
                can_move = true;
            }
        }
        catch { }
    }
    void FindOnBoard()
    {
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (Global.board[row, col] == number_chip)
                {
                    row_position = row;
                    col_position = col;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        On = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        On = false;
    }
}
