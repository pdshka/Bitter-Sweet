using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Выбор куба на WASD персонажем и его поворот на стрелочки, логика.

public class BigPipe2 : MonoBehaviour
{                                                 // Константы 
    private int k0, k1, k2, k3, k4, k5, k6, k7, k8, k9, k10, k11, k12, k13, k14, k15 = 0;
    private int Chain = 0;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public int k = 15;                             // Количество "труб" +1   для массива
    public GameObject[] obj = new GameObject[16];
    public GameObject finish;


    private Animator anim;

    private void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public enum States
    {
        True,
        False
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void OnTriggerEnter2D(Collider2D collision)     // Проверка срабатывания тригера для выбора трубы 
    {
        if (collision.gameObject.name.Equals("Square15"))    // Труба 15
        {
            k = 15;
        }


        if (collision.gameObject.name.Equals("Square14"))    // Труба 14
        {
            k = 14;
        }


        if (collision.gameObject.name.Equals("Square13"))    // Труба 13
        {
            k = 13;
        }


        if (collision.gameObject.name.Equals("Square12"))    // Труба 12
        {
            k = 12;
        }


        if (collision.gameObject.name.Equals("Square11"))    // Труба 11
        {
            k = 11;
        }


        if (collision.gameObject.name.Equals("Square10"))    // Труба 10
        {
            k = 10;
        }


        if (collision.gameObject.name.Equals("Square9"))    // Труба 9
        {
            k = 9;
        }

        
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
        if (collision.gameObject.name.Equals("Square15"))    // Труба 15
        {
            Chain = 1;
        }


        if (collision.gameObject.name.Equals("Square14"))    // Труба 14
        {
            Chain = 1;
        }


        if (collision.gameObject.name.Equals("Square13"))    // Труба 13
        {
            Chain = 1;
        }


        if (collision.gameObject.name.Equals("Square12"))    // Труба 12
        {
            Chain = 1;
        }


        if (collision.gameObject.name.Equals("Square11"))    // Труба 11
        {
            Chain = 1;
        }


        if (collision.gameObject.name.Equals("Square10"))    // Труба 10
        {
            Chain = 1;
        }


        if (collision.gameObject.name.Equals("Square9"))    // Труба 9
        {
            Chain = 1;
        } 


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
        if (collision.gameObject.name.Equals("Square15"))    // Труба 15
        {
            Chain = 0;
        }


        if (collision.gameObject.name.Equals("Square14"))    // Труба 14
        {
            Chain = 0;
        }


        if (collision.gameObject.name.Equals("Square13"))    // Труба 13
        {
            Chain = 0;
        }


        if (collision.gameObject.name.Equals("Square12"))    // Труба 12
        {
            Chain = 0;
        }


        if (collision.gameObject.name.Equals("Square11"))    // Труба 11
        {
            Chain = 0;
        }


        if (collision.gameObject.name.Equals("Square10"))    // Труба 10
        {
            Chain = 0;
        }


        if (collision.gameObject.name.Equals("Square9"))    // Труба 9
        {
            Chain = 0;
        }


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

        if (k0 == 0 && k15 == 1 && k13 == 3 && k9 == 3 && k8 == 1 && k14 == 1 && k4 == 1)  // Проверка правильного положения труб для прохождения уровня
        {
            obj[0].GetComponent<Animator>().SetBool("water", true);
            obj[15].GetComponent<Animator>().SetBool("water", true);
            obj[13].GetComponent<Animator>().SetBool("water", true);
            obj[9].GetComponent<Animator>().SetBool("water", true);
            obj[8].GetComponent<Animator>().SetBool("water", true);
            obj[14].GetComponent<Animator>().SetBool("water", true);
            obj[4].GetComponent<Animator>().SetBool("water", true);
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


        /// Положение для угловых труб
        
        if (k == 13 && Chain == 1)                                                  // Проверка правильного положения трубы 13 | 3 - True
        {
            if (k13 != 0 && Input.GetKeyDown(KeyCode.LeftArrow))
            {
                k13--;
            }
            else
            {
                if (k13 == 0 && Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    k13 = 3;
                }
            }

            if (k == 13 && k13 != 3 && Input.GetKeyDown(KeyCode.RightArrow))
            {
                k13++;
            }
            else
            {
                if (k == 13 && k13 == 3 && Input.GetKeyDown(KeyCode.RightArrow))
                {
                    k13 = 0;
                }
            }
        }

        if (k == 9 && Chain == 1)                                                  // Проверка правильного положения трубы 9 | 3 - True
        {
            if (k9 != 0 && Input.GetKeyDown(KeyCode.LeftArrow))
            {
                k9--;
            }
            else
            {
                if (k9 == 0 && Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    k9 = 3;
                }
            }

            if (k == 9 && k9 != 3 && Input.GetKeyDown(KeyCode.RightArrow))
            {
                k9++;
            }
            else
            {
                if (k == 9 && k9 == 3 && Input.GetKeyDown(KeyCode.RightArrow))
                {
                    k9 = 0;
                }
            }
        }

        if (k == 8 && Chain == 1)                                                  // Проверка правильного положения трубы 8 | 1 - True
        {
            if (k8 != 0 && Input.GetKeyDown(KeyCode.LeftArrow))
            {
                k8--;
            }
            else
            {
                if (k8 == 0 && Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    k8 = 3;
                }
            }

            if (k == 8 && k8 != 3 && Input.GetKeyDown(KeyCode.RightArrow))
            {
                k8++;
            }
            else
            {
                if (k == 8 && k8 == 3 && Input.GetKeyDown(KeyCode.RightArrow))
                {
                    k8 = 0;
                }
            }
        }

        if (k == 0 && Chain == 1)                                                  // Проверка правильного положения трубы 0 | 0 - True
        {
            if (k0 != 0 && Input.GetKeyDown(KeyCode.LeftArrow))
            {
                k0--;
            }
            else
            {
                if (k0 == 0 && Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    k0 = 3;
                }
            }

            if (k == 0 && k0 != 3 && Input.GetKeyDown(KeyCode.RightArrow))
            { 
                k0++;
            }
            else
            {
                if (k == 0 && k0 == 3 && Input.GetKeyDown(KeyCode.RightArrow))
                {
                    k0 = 0; 
                }
            }
        }

       


        /// Положение для прямых труб

        if (k == 15 && Chain == 1)                                                                          // Проверка правильного положения трубы 15 | 1 - True
        {
            if (k15 == 1 && Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.LeftArrow))
            {
                k15 = 0;
            }
            else
            {
                if (k15 == 0 && Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    k15 = 1;
                }
            }
        }

        if (k == 14 && Chain == 1)                                                                          // Проверка правильного положения трубы 14 | 1 - True
        {
            if (k14 == 1 && Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.LeftArrow))
            {
                k14 = 0;
            }
            else
            {
                if (k14 == 0 && Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    k14 = 1;
                }
            }
        }

        if (k == 4 && Chain == 1)                                                                          // Проверка правильного положения трубы 4 | 1 - True
        {
            if (k4 == 1 && Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.LeftArrow))
            {
                k4 = 0;
            }
            else
            {
                if (k4 == 0 && Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    k4 = 1;
                }
            }
        }
    }

    public void LoadData(GameData gameData)
    {
        if (gameData.pipesCompleted.ContainsKey("BigPipes2") && gameData.pipesCompleted["BigPipes2"])
        {
            this.enabled = false;
        }
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.pipesCompleted["BigPipes2"] = this.enabled;
    }
}

