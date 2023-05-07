using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePuzzle : MonoBehaviour
{
    [SerializeField]
    private Sprite[] FragmentsSprites;
    [SerializeField]
    private Sprite BoardSprite;
    public GameObject[] chips = new GameObject[15];
    private Vector3 board_position;
    public float SizeOfBoard = 4.0f;
    public float split_x;
    public float split_y;
    public Global global;
    void Start()
    {
        board_position = transform.position;
        transform.localScale = new Vector3(SizeOfBoard, SizeOfBoard);
        split_x = SizeOfBoard / 4;
        split_y = SizeOfBoard / 4;
        GenerateBoard();
        ShowBoard();
        GetComponent<SpriteRenderer>().sprite = BoardSprite;
        for (int i = 0; i < 15; i++)
        {
            chips[i].GetComponent<SpriteRenderer>().sprite = FragmentsSprites[i];
        }
    }
    const int N = 4;
    int getInvCount(int[] arr)
    {
        int inv_count = 0;
        for (int i = 0; i < N * N - 1; i++)
        {
            for (int j = i + 1; j < N * N; j++)
            {
                if (arr[j] != 0 && arr[i] != 0
                    && arr[i] > arr[j])
                    inv_count++;
            }
        }
        return inv_count;
    }
    int findXPosition(int[,] puzzle)
    {
        for (int i = N - 1; i >= 0; i--)
        {
            for (int j = N - 1; j >= 0; j--)
            {
                if (puzzle[i, j] == 0)
                    return N - i;
            }
        }
        return -1;
    }
    bool isSolvable(int[,] puzzle)
    {
        int[] arr = new int[N * N];
        int k = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                arr[k++] = puzzle[i, j];
            }
        }

        int invCount = getInvCount(arr);
        if (N % 2 == 1)
            return invCount % 2 == 0;
        else
        {
            int pos = findXPosition(puzzle);
            if (pos % 2 == 1)
                return invCount % 2 == 0;
            else
                return invCount % 2 == 1;
        }
    }
    void GenerateBoard()
    {
        for (int i = 1; i < 16; i++)
        {
            bool cancel = false;
            do
            {
                int row = Random.Range(0, 4);
                int col = Random.Range(0, 4);
                if (global.board[row, col] == 0)
                {
                    cancel = true;
                    global.board[row, col] = i;
                }
            } while (!cancel);
        }
        CheckShuffle();
        //PrintArr();
    }
    private void CheckShuffle()
    {
        if (isSolvable(global.board))
        {
            int i14 = 0, i15 = 0, j14 = 0, j15 = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (global.board[i, j] == 14)
                        (i14, j14) = (i, j);
                    if (global.board[i, j] == 15)
                        (i15, j15) = (i, j);
                }
            (global.board[i14, j14], global.board[i15, j15]) = (global.board[i15, j15], global.board[i14, j14]);
        }

    }
    private void PrintArr()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                //Debug.Log($"{global.board[i, j]} ");
            }
        }
    }
    void ShowBoard()
    {
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (global.board[row, col] != 0)
                {
                    Vector3 coordinate = new Vector3(board_position.x + (row - 1.5f) * split_x, board_position.y + (col - 1.5f) * split_y, -0.0000001f);
                    int chip = global.board[row, col] - 1;
                    chips[chip].transform.position = coordinate;
                    chips[chip].transform.localScale = new Vector3(0.25f, 0.25f);
                }
            }
        }
    }
}
