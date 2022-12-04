using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Выбор куба на WASD и его поворот на стрелочки, логика.

public class PlatformChoise : MonoBehaviour
{                                                  // Константы 
    private int k0, k1, k3, k4, k6, k7, k8 = 0;
    private int Chain = 0;

    public int k = 8;                             // Количество "труб" -1   для массива
    public GameObject[] obj = new GameObject[9];
    public GameObject finish;



    private void OnTriggerEnter2D(Collider2D collision)     // Проверка срабатывания тригера для выбора трубы 
    {
        if (collision.gameObject.name.Equals("Square8"))    // Труба 8
        {
            k = 8;
        }


        if (collision.gameObject.name.Equals("Square7"))    // Труба 7
        {
            k = 7;
        }


        if (collision.gameObject.name.Equals("Square6"))    // Труба 6
        {
            k = 6;
        }


        if (collision.gameObject.name.Equals("Square5"))    // Труба 5
        {
            k = 5;
        }


        if (collision.gameObject.name.Equals("Square4"))    // Труба 4
        {
            k = 4;
        }


        if (collision.gameObject.name.Equals("Square3"))    // Труба 3
        {
            k = 3;
        }


        if (collision.gameObject.name.Equals("Square2"))    // Труба 2
        {
            k = 2;
        }


        if (collision.gameObject.name.Equals("Square1"))    // Труба 1
        {
            k = 1;
        }


        if (collision.gameObject.name.Equals("Square0"))    // Труба 0
        {
            k = 0;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)     // Проверка нахождения в тригере для выбора трубы 
    {
        if (collision.gameObject.name.Equals("Square8"))    // Труба 8
        {
            Chain = 1;
        }


        if (collision.gameObject.name.Equals("Square7"))    // Труба 7
        {
            Chain = 1;
        }


        if (collision.gameObject.name.Equals("Square6"))    // Труба 6
        {
            Chain = 1;
        }


        if (collision.gameObject.name.Equals("Square5"))    // Труба 5
        {
            Chain = 1;
        }


        if (collision.gameObject.name.Equals("Square4"))    // Труба 4
        {
            Chain = 1;
        }


        if (collision.gameObject.name.Equals("Square3"))    // Труба 3
        {
            Chain = 1;
        }


        if (collision.gameObject.name.Equals("Square2"))    // Труба 2
        {
            Chain = 1;
        }


        if (collision.gameObject.name.Equals("Square1"))    // Труба 1
        {
            Chain = 1;
        }


        if (collision.gameObject.name.Equals("Square0"))    // Труба 0
        {
            Chain = 1;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)     // Проверка выхода из тригера для выбора трубы 
    {
        if (collision.gameObject.name.Equals("Square8"))    // Труба 8
        {
            Chain = 0;
        }


        if (collision.gameObject.name.Equals("Square7"))    // Труба 7
        {
            Chain = 0;
        }


        if (collision.gameObject.name.Equals("Square6"))    // Труба 6
        {
            Chain = 0;
        }


        if (collision.gameObject.name.Equals("Square5"))    // Труба 5
        {
            Chain = 0;
        }


        if (collision.gameObject.name.Equals("Square4"))    // Труба 4
        {
            Chain = 0;
        }


        if (collision.gameObject.name.Equals("Square3"))    // Труба 3
        {
            Chain = 0;
        }


        if (collision.gameObject.name.Equals("Square2"))    // Труба 2
        {
            Chain = 0;
        }


        if (collision.gameObject.name.Equals("Square1"))    // Труба 1
        {
            Chain = 0;
        }


        if (collision.gameObject.name.Equals("Square0"))    // Труба 0
        {
            Chain = 0;
        }
    }




    private void Update()
    {
       
        if (k0 == 1 && k1 == 3 && k3 == 1 && k4 == 2 && k6 == 2 && k7 == 1 && k8 == 1)  // Проверка правильного положения труб для прохождения уровня
        {
            obj[0].GetComponentInChildren<Animator>().SetBool("water", true);
            obj[1].GetComponentInChildren<Animator>().SetBool("water", true);
            obj[3].GetComponentInChildren<Animator>().SetBool("water", true);
            obj[4].GetComponentInChildren<Animator>().SetBool("water", true);
            obj[6].GetComponentInChildren<Animator>().SetBool("water", true);
            obj[7].GetComponentInChildren<Animator>().SetBool("water", true);
            obj[8].GetComponentInChildren<Animator>().SetBool("water", true);
            finish.GetComponent<Animator>().SetBool("water", true);
            this.enabled = false;

            Debug.Log("Уровень пройден");
        }



        if (Chain == 1 && Input.GetKeyDown(KeyCode.RightArrow))   // Поворот от нажатия стрелочек
        {
            obj[k].transform.Rotate(new Vector3(0, 0, -90));
        }

        if (Chain == 1 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            obj[k].transform.Rotate(new Vector3(0, 0, 90));
        }



        if (k == 8 && k8 == 0 && Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.LeftArrow)  && Chain == 1)        // Проверка правильного положения трубы 8 | 1 - True
        {
            k8 = 1;
        }
        else
        {
            if (k == 8 && Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.LeftArrow) && Chain == 1)
            {
                k8 = 0;
            }
        }




        if (k == 7 && k7 == 0 && Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.LeftArrow) && Chain == 1)        // Проверка правильного положения трубы 7 | 1 - True
        {
            k7 = 1;
        }
        else
        {
            if (k == 7 && Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.LeftArrow) && Chain == 1)
            {
                k7 = 0;
            }
        }




        if (k == 0 && k0 == 0 && Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.LeftArrow) && Chain == 1)        // Проверка правильного положения трубы 0 | 1 - True
        {
            k0 = 1;
        }
        else
        {
            if (k == 0 && Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.LeftArrow) && Chain == 1)
            {
                k0 = 0;
            }
        }




        if (k == 6 && k6 != 3 && Input.GetKeyDown(KeyCode.RightArrow) && Chain == 1)              // Проверка правильного положения трубы 6 | 3 - True
        {
            k6 = k6 + 1;
        }
        else
        {
            if (k == 6 && k6 == 3 && Input.GetKeyDown(KeyCode.RightArrow) && Chain == 1)
            {
                k6 = 0;
            }
        }
        if (k == 6 && k6 != 0 && Input.GetKeyDown(KeyCode.LeftArrow) && Chain == 1)             
        {
            k6 = k6 - 1;
        }
        else
        {
            if (k == 6 && k6 == 0 && Input.GetKeyDown(KeyCode.LeftArrow) && Chain == 1)
            {
                k6 = 3;
            }
        }




        if (k == 3 && k3 != 3 && Input.GetKeyDown(KeyCode.RightArrow) && Chain == 1)              // Проверка правильного положения трубы 3 | 1 - True
        {
            k3 = k3 + 1;
        }
        else
        {
            if (k == 3 && k3 == 3 && Input.GetKeyDown(KeyCode.RightArrow) && Chain == 1)
            {
                k3 = 0;
            }
        }
        if (k == 3 && k3 != 0 && Input.GetKeyDown(KeyCode.LeftArrow) && Chain == 1)
        {
            k3 = k3 - 1;
        }
        else
        {
            if (k == 3 && k3 == 0 && Input.GetKeyDown(KeyCode.LeftArrow) && Chain == 1)
            {
                k3 = 3;
            }
        }





        if (k == 4 && k4 != 3 && Input.GetKeyDown(KeyCode.RightArrow) && Chain == 1)              // Проверка правильного положения трубы 4 | 2 - True
        {
            k4 = k4 + 1;
        }
        else
        {
            if (k == 4 && k4 == 3 && Input.GetKeyDown(KeyCode.RightArrow) && Chain == 1)
            {
                k4 = 0;
            }
        }
        if (k == 4 && k4 != 0 && Input.GetKeyDown(KeyCode.LeftArrow) && Chain == 1)
        {
            k4 = k4 - 1;
        }
        else
        {
            if (k == 4 && k4 == 0 && Input.GetKeyDown(KeyCode.LeftArrow) && Chain == 1)
            {
                k4 = 3;
            }
        }





        if (k == 1 && k1 != 3 && Input.GetKeyDown(KeyCode.RightArrow) && Chain == 1)              // Проверка правильного положения трубы 1 | 3 - True
        {
            k1 = k1 + 1;
        }
        else
        {
            if (k == 1 && k1 == 3 && Input.GetKeyDown(KeyCode.RightArrow) && Chain == 1)
            {
                k1 = 0;
            }
        }
        if (k == 1 && k1 != 0 && Input.GetKeyDown(KeyCode.LeftArrow) && Chain == 1)
        {
            k1 = k1 - 1;
        }
        else
        {
            if (k == 1 && k1 == 0 && Input.GetKeyDown(KeyCode.LeftArrow) && Chain == 1)
            {
                k1 = 3;
            }
        }
    }
}