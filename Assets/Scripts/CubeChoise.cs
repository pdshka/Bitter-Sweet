using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Выбор куба на WASD и его поворот на стрелочки

public class CubeChoise : MonoBehaviour
{
    private int moveSpeed = 2;
    private int k = 18;
    public GameObject[] obj = new GameObject[19];
    private void Update()
    {
        float j = 0.003f;
        if (Input.GetKeyDown(KeyCode.W))
        {
            k = k + 6;
            obj[k].transform.Translate(new Vector3(0, 6, 0) * moveSpeed * j);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            k = k + 1;
            obj[k].transform.Translate(new Vector3(0, 6, 0) * moveSpeed * j);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            k = k - 6;
            obj[k].transform.Translate(new Vector3(0, 6, 0) * moveSpeed * j);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            k = k - 1;
            obj[k].transform.Translate(new Vector3(0, 6, 0) * moveSpeed * j);
        }


        if (Input.GetKeyUp(KeyCode.W))      // Возврат
        {
            obj[k].transform.Translate(new Vector3(0, -6, 0) * moveSpeed * j);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            obj[k].transform.Translate(new Vector3(0, -6, 0) * moveSpeed * j);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            obj[k].transform.Translate(new Vector3(0, -6, 0) * moveSpeed * j);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            obj[k].transform.Translate(new Vector3(0, -6, 0) * moveSpeed * j);
        }


        if (Input.GetKey(KeyCode.RightArrow))   // Поворот
        {
            obj[k].transform.Rotate(new Vector3(0, 20, 0) * moveSpeed * j);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            obj[k].transform.Rotate(new Vector3(0, -20, 0) * moveSpeed * j);
        }
    }

}

