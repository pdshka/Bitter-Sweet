using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static bool GameOn = true;
    public static int[,] board = new int[4, 4];
    public static int[,] board2 = { { 13, 9, 5, 1 }, { 14, 10, 6, 2 }, { 15, 11, 7, 3 }, { 0, 12, 8, 4 } };
}
