using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsLogistic : MonoBehaviour
{
    // Константы
    int lock1 = 0;
    int lock2,lock3,lock4,lock5 = 1;
    int falselock1,falselock2,falselock3,falselock4,falselock5 = 0;
    int false1,false2,false3,false4,false5 = 0;
    int roundpased = 0;
    private int roundnumber = 1;
    float delay = 0.5f;
    public Triggers triggers;

    [SerializeField] private SpriteRenderer SpriteObj1;
    [SerializeField] private SpriteRenderer SpriteObj2;
    [SerializeField] private SpriteRenderer SpriteObj3;
    [SerializeField] private SpriteRenderer SpriteObj4;
    [SerializeField] private SpriteRenderer SpriteObj5;
    [SerializeField] private SpriteRenderer SpriteObj6;
    [SerializeField] private SpriteRenderer SpriteObj7;
    [SerializeField] private SpriteRenderer SpriteObj8;
    [SerializeField] private SpriteRenderer SpriteObj9;

    int[] RightElements = new int[6];

    // Функции

    public int randomnumber()
    {
        int randomNumber = Random.Range(1, 10);
        return randomNumber;
    }
    

    private void ChangeColorForAllGreen()
    {
        SpriteObj1.material.color = Color.green;
        SpriteObj2.material.color = Color.green;
        SpriteObj3.material.color = Color.green;
        SpriteObj4.material.color = Color.green;
        SpriteObj5.material.color = Color.green;
        SpriteObj6.material.color = Color.green;
        SpriteObj7.material.color = Color.green;
        SpriteObj8.material.color = Color.green;
        SpriteObj9.material.color = Color.green;
    }

    private void ChangeColorForAllRed()
    {
        SpriteObj1.material.color = Color.red;
        SpriteObj2.material.color = Color.red;
        SpriteObj3.material.color = Color.red;
        SpriteObj4.material.color = Color.red;
        SpriteObj5.material.color = Color.red;
        SpriteObj6.material.color = Color.red;
        SpriteObj7.material.color = Color.red;
        SpriteObj8.material.color = Color.red;
        SpriteObj9.material.color = Color.red;
    }

    private void ChangeColorForAllWhite()
    {
        SpriteObj1.material.color = Color.white;
        SpriteObj2.material.color = Color.white;
        SpriteObj3.material.color = Color.white;
        SpriteObj4.material.color = Color.white;
        SpriteObj5.material.color = Color.white;
        SpriteObj6.material.color = Color.white;
        SpriteObj7.material.color = Color.white;
        SpriteObj8.material.color = Color.white;
        SpriteObj9.material.color = Color.white;
    }


    private void ChangeColorBackDelay1()
    {
        SpriteObj1.material.color = Color.white;
    }

    private void ChangeColorBackDelay2()
    {
        SpriteObj2.material.color = Color.white;
    }

    private void ChangeColorBackDelay3()
    {
        SpriteObj3.material.color = Color.white;
    }

    private void ChangeColorBackDelay4()
    {
        SpriteObj4.material.color = Color.white;
    }

    private void ChangeColorBackDelay5()
    {
        SpriteObj5.material.color = Color.white;
    }

    private void ChangeColorBackDelay6()
    {
        SpriteObj6.material.color = Color.white;
    }

    private void ChangeColorBackDelay7()
    {
        SpriteObj7.material.color = Color.white;
    }

    private void ChangeColorBackDelay8()
    {
        SpriteObj8.material.color = Color.white;
    }

    private void ChangeColorBackDelay9()
    {
        SpriteObj9.material.color = Color.white;
    }

    public int[] RemoveZeros(int[] arr)
    {
        List<int> nonZeroElements = new List<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0)
            {
                nonZeroElements.Add(arr[i]);
            }
        }
        return nonZeroElements.ToArray();
    }


    private void Rounds(int roundnumber, out int[] ActiveElements)
    {
        int Countofelements = 1;
        ActiveElements = new int[6];
        if (roundnumber == 1)
        {
            Countofelements = 2;
        }
        if (roundnumber == 2)
        {
            Countofelements = 3;
        }
        if (roundnumber == 3)
        {
            Countofelements = 4;
        }
        if (roundnumber == 4)
        {
            Countofelements = 5;
        }


        if (roundnumber == 1)
        {
            for (int i = 0; i < Countofelements; i++)
            {
                ActiveElements[i] = randomnumber();
            }
        }

        if (roundnumber == 2)
        {
            for (int i = 0; i < Countofelements; i++)
            {
                ActiveElements[i] = randomnumber();
            }
        }

        if (roundnumber == 3)
        {
            for (int i = 0; i < Countofelements; i++)
            {
                ActiveElements[i] = randomnumber();
            }
        }

        if (roundnumber == 4)
        {
            for (int i = 0; i < Countofelements; i++)
            {
                ActiveElements[i] = randomnumber();
            }
        }
    }

    private void ConstUpdater(ref int lock1,ref int lock2,ref int lock3,ref int lock4,ref int lock5,ref int falselock1,ref int falselock2,
        ref int falselock3,ref int falselock4,ref int falselock5,ref int false1,ref int false2,ref int false3,ref int false4,ref int false5)
    {
        lock1 = 0;
        lock2 = 1;
        lock3 = 1;
        lock4 = 1;
        lock5 = 1;
        falselock1 = 0;
        falselock2 = 0;
        falselock3 = 0;
        falselock4 = 0;
        falselock5 = 0;
        false1 = 0;
        false2 = 0;
        false3 = 0;
        false4 = 0;
        false5 = 0;
    }


    private void Round1(ref int PlayerChoise, int[] RightElements, ref int roundnumber, ref int lock1, ref int lock2, ref int falselock1, ref int falselock2, ref int false1,ref int false2, ref int roundpased)
    {
        if (roundnumber == 1)
        {
            if (PlayerChoise == RightElements[0] && lock1 != 1)
            {
                lock1 = 1;
                lock2 = 0;
                falselock1 = 1;
                PlayerChoise = 100;
            }
            if (PlayerChoise != RightElements[0] && lock1 != 1 && PlayerChoise != 100 && falselock1 == 0)
            {
                lock1 = 1;
                false1 = 1;
                StartCoroutine(Wait());
            }
            ///
            if (PlayerChoise == RightElements[1] && lock2 != 1)
            {
                PlayerChoise = 100;
                falselock2 = 1;

                roundnumber = 2;
                StartCoroutine(Wait());
                ConstUpdater(ref lock1, ref lock2, ref lock3, ref lock4, ref lock5, ref falselock1, ref falselock2, ref falselock3, ref falselock4, ref falselock5, ref false1, ref false2, ref false3, ref false4, ref false5);
                roundpased = 1;
            }
            if (PlayerChoise != RightElements[1] && lock2 != 1 && PlayerChoise != 100 && falselock2 == 0)
            {
                lock2 = 1;
                false2 = 1;
                StartCoroutine(Wait());
            }
        }
    }



    private void Round2(ref int PlayerChoise, int[] RightElements, ref int roundnumber, ref int lock1, ref int lock2, 
        ref int lock3, ref int falselock1, ref int falselock2, ref int falselock3,ref int false1,ref int false2,ref int false3, ref int roundpased)                                                                
    {
        if (roundnumber == 2)
        {
            if (PlayerChoise == RightElements[0] && lock1 != 1)
            {
                lock1 = 1;
                lock2 = 0;
                falselock1 = 1;
                PlayerChoise = 100;
            }
            if (PlayerChoise != RightElements[0] && lock1 != 1 && PlayerChoise != 100 && falselock1 == 0)
            {
                lock1 = 1;
                false1 = 1;
                StartCoroutine(Wait());
            }
            ///
            if (PlayerChoise == RightElements[1] && lock2 != 1)
            {
                PlayerChoise = 100;
                falselock2 = 1;
                lock2 = 1;
                lock3 = 0;
            }
            if (PlayerChoise != RightElements[1] && lock2 != 1 && PlayerChoise != 100 && falselock2 == 0)
            {
                lock2 = 1;
                false2 = 1;
                StartCoroutine(Wait());
            }
            ///
            if (PlayerChoise == RightElements[2] && lock3 != 1)
            {
                PlayerChoise = 100;
                falselock3 = 1;
                lock3 = 1;

                roundnumber = 3;
                StartCoroutine(Wait());
                ConstUpdater(ref lock1, ref lock2,ref lock3,ref lock4,ref lock5,ref falselock1,ref falselock2,ref falselock3,ref falselock4,ref falselock5,ref false1,ref false2,ref false3,ref false4,ref false5);
                roundpased = 2;
            }

            if (PlayerChoise != RightElements[2] && lock3 != 1 && PlayerChoise != 100 && falselock3 == 0)
            {
                lock3 = 1;
                false3 = 1;
                StartCoroutine(Wait());
            }
        }
    }


    private void Round3(ref int PlayerChoise, int[] RightElements, ref int roundnumber, ref int lock1, ref int lock2,
        ref int lock3, ref int lock4, ref int falselock1, ref int falselock2, ref int falselock3, ref int falselock4, ref int false1, ref int false2, ref int false3, ref int false4, ref int roundpased)
    {
        if (roundnumber == 3)
        {
            if (PlayerChoise == RightElements[0] && lock1 != 1)
            {
                lock1 = 1;
                lock2 = 0;
                falselock1 = 1;
                PlayerChoise = 100;
            }
            if (PlayerChoise != RightElements[0] && lock1 != 1 && PlayerChoise != 100 && falselock1 == 0)
            {
                lock1 = 1;
                false1 = 1;
                StartCoroutine(Wait());
            }
            ///
            if (PlayerChoise == RightElements[1] && lock2 != 1)
            {
                PlayerChoise = 100;
                falselock2 = 1;
                lock2 = 1;
                lock3 = 0;
            }
            if (PlayerChoise != RightElements[1] && lock2 != 1 && PlayerChoise != 100 && falselock2 == 0)
            {
                lock2 = 1;
                false2 = 1;
                StartCoroutine(Wait());
            }
            ///
            if (PlayerChoise == RightElements[2] && lock3 != 1)
            {
                PlayerChoise = 100;
                falselock3 = 1;
                lock3 = 1;
                lock4 = 0;
            }
            if (PlayerChoise != RightElements[2] && lock3 != 1 && PlayerChoise != 100 && falselock3 == 0)
            {
                lock3 = 1;
                false3 = 1;
                StartCoroutine(Wait());
            }
            ///
            if (PlayerChoise == RightElements[3] && lock4 != 1)
            {
                PlayerChoise = 100;
                falselock4 = 1;
                lock4 = 1;

                roundnumber = 4;
                StartCoroutine(Wait());
                ConstUpdater(ref lock1, ref lock2, ref lock3, ref lock4, ref lock5, ref falselock1, ref falselock2, ref falselock3, ref falselock4, ref falselock5, ref false1, ref false2, ref false3, ref false4, ref false5);
                roundpased = 3;
            }
            if (PlayerChoise != RightElements[3] && lock4 != 1 && PlayerChoise != 100 && falselock4 == 0)
            {
                lock4 = 1;
                false4 = 1;
                StartCoroutine(Wait());
            }
        }
    }

    private void Round4(ref int PlayerChoise, int[] RightElements, ref int roundnumber, ref int lock1, ref int lock2,
       ref int lock3, ref int lock4, ref int lock5, ref int falselock1, ref int falselock2, ref int falselock3, ref int falselock4, ref int falselock5, ref int false1, ref int false2, ref int false3, ref int false4,ref int false5,
       ref int roundpased)
    {
        if (roundnumber == 4)
        {
            if (PlayerChoise == RightElements[0] && lock1 != 1)
            {
                lock1 = 1;
                lock2 = 0;
                falselock1 = 1;
                PlayerChoise = 100;
            }
            if (PlayerChoise != RightElements[0] && lock1 != 1 && PlayerChoise != 100 && falselock1 == 0)
            {
                lock1 = 1;
                false1 = 1;
                StartCoroutine(Wait());
            }
            ///
            if (PlayerChoise == RightElements[1] && lock2 != 1)
            {
                PlayerChoise = 100;
                falselock2 = 1;
                lock2 = 1;
                lock3 = 0;
            }
            if (PlayerChoise != RightElements[1] && lock2 != 1 && PlayerChoise != 100 && falselock2 == 0)
            {
                lock2 = 1;
                false2 = 1;
                StartCoroutine(Wait());
            }
            ///
            if (PlayerChoise == RightElements[2] && lock3 != 1)
            {
                PlayerChoise = 100;
                falselock3 = 1;
                lock3 = 1;
                lock4 = 0;
            }
            if (PlayerChoise != RightElements[2] && lock3 != 1 && PlayerChoise != 100 && falselock3 == 0)
            {
                lock3 = 1;
                false3 = 1;
                StartCoroutine(Wait());
            }
            ///
            if (PlayerChoise == RightElements[3] && lock4 != 1)
            {
                PlayerChoise = 100;
                falselock4 = 1;
                lock4 = 1;
                lock5 = 0;
            }
            if (PlayerChoise != RightElements[3] && lock4 != 1 && PlayerChoise != 100 && falselock4 == 0)
            {
                lock4 = 1;
                false4 = 1;
                StartCoroutine(Wait());
            }
            ///
            if (PlayerChoise == RightElements[4] && lock5 != 1)
            {
                PlayerChoise = 100;
                falselock5 = 1;
                lock5 = 1;
                roundpased = 4;
            }
            if (PlayerChoise != RightElements[4] && lock5 != 1 && PlayerChoise != 100 && falselock5 == 0)
            {
                lock4 = 1;
                false4 = 1;
                StartCoroutine(Wait());
            }

        }
    }


    private void Start()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        Rounds(roundnumber, out int[] ActiveElements);
        RightElements = RemoveZeros(ActiveElements);
        yield return new WaitForSeconds(1f);
        foreach (int element in RightElements)
        {
            if (element == 1)
            {
                SpriteObj1.material.color = new Color(1f, 0f, 0f);
                Invoke("ChangeColorBackDelay1", delay);
            }
            if (element == 2)
            {
                SpriteObj2.material.color = new Color(0f, 1f, 0f);
                Invoke("ChangeColorBackDelay2", delay);
            }
            if (element == 3)
            {
                SpriteObj3.material.color = new Color(0f, 0f, 1f);
                Invoke("ChangeColorBackDelay3", delay);
            }
            if (element == 4)
            {
                SpriteObj4.material.color = new Color(1f, 1f, 0f);
                Invoke("ChangeColorBackDelay4", delay);
            }
            if (element == 5)
            {
                SpriteObj5.material.color = new Color(1f, 0.92f, 0.016f);
                Invoke("ChangeColorBackDelay5", delay);
            }
            if (element == 6)
            {
                SpriteObj6.material.color = new Color(1f, 0.41f, 0.71f);
                Invoke("ChangeColorBackDelay6", delay);
            }
            if (element == 7)
            {
                SpriteObj7.material.color = new Color(0f, 1f, 1f);
                Invoke("ChangeColorBackDelay7", delay);
            }
            if (element == 8)
            {
                SpriteObj8.material.color = new Color(0.5f, 0f, 0.5f);
                Invoke("ChangeColorBackDelay8", delay);
            }
            if (element == 9)
            {
                SpriteObj9.material.color = new Color(1f, 0.55f, 0f);
                Invoke("ChangeColorBackDelay9", delay);
            }
            yield return new WaitForSeconds(1.5f);
        }
        Invoke("ChangeColorForAllGreen", 0.2f);
        Invoke("ChangeColorForAllWhite", 0.5f);
    }


    private IEnumerator Round1()
    {
        Round1(ref triggers.PlayerChoise, RightElements, ref roundnumber, ref lock1, ref lock2, ref falselock1, ref falselock2, ref false1, ref false2, ref roundpased);
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator Round1false()
    {
        if (false1 == 1 || false2 == 1)
        {
            Invoke("ChangeColorForAllRed", 0.2f);
            Invoke("ChangeColorForAllWhite", 0.5f);
            yield return new WaitForSeconds(0.5f);

            ConstUpdater(ref lock1, ref lock2, ref lock3, ref lock4, ref lock5, ref falselock1, ref falselock2, ref falselock3, ref falselock4, ref falselock5, ref false1, ref false2, ref false3, ref false4, ref false5);
            triggers.PlayerChoise = 100;

            Round1(ref triggers.PlayerChoise, RightElements, ref roundnumber, ref lock1, ref lock2, ref falselock1, ref falselock2, ref false1, ref false2, ref roundpased);
        }
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator Round2()
    {
        Round2(ref triggers.PlayerChoise, RightElements, ref roundnumber, ref lock1, ref lock2, ref lock3, ref falselock1, ref falselock2, ref falselock3, ref false1, ref false2, ref false3, ref roundpased);
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator Round2false()
    {
        if (false1 == 1 || false2 == 1 || false3 == 1)
        {
            Invoke("ChangeColorForAllRed", 0.2f);
            Invoke("ChangeColorForAllWhite", 0.5f);
            yield return new WaitForSeconds(0.5f);

            ConstUpdater(ref lock1, ref lock2, ref lock3, ref lock4, ref lock5, ref falselock1, ref falselock2, ref falselock3, ref falselock4, ref falselock5, ref false1, ref false2, ref false3, ref false4, ref false5);
            triggers.PlayerChoise = 100;

            Round2(ref triggers.PlayerChoise, RightElements, ref roundnumber, ref lock1, ref lock2, ref lock3, ref falselock1, ref falselock2, ref falselock3, ref false1, ref false2, ref false3, ref roundpased);
        }
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator Round3()
    {
        Round3(ref triggers.PlayerChoise, RightElements, ref roundnumber, ref lock1, ref lock2,
        ref lock3, ref lock4, ref falselock1, ref falselock2, ref falselock3, ref falselock4, ref false1, ref false2, ref false3, ref false4, ref roundpased);
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator Round3false()
    {
        if (false1 == 1 || false2 == 1 || false3 == 1 || false4 == 1)
        {
            Invoke("ChangeColorForAllRed", 0.2f);
            Invoke("ChangeColorForAllWhite", 0.5f);
            yield return new WaitForSeconds(0.5f);

            ConstUpdater(ref lock1, ref lock2, ref lock3, ref lock4, ref lock5, ref falselock1, ref falselock2, ref falselock3, ref falselock4, ref falselock5, ref false1, ref false2, ref false3, ref false4, ref false5);
            triggers.PlayerChoise = 100;

            Round3(ref triggers.PlayerChoise, RightElements, ref roundnumber, ref lock1, ref lock2,
            ref lock3, ref lock4, ref falselock1, ref falselock2, ref falselock3, ref falselock4, ref false1, ref false2, ref false3, ref false4, ref roundpased);
        }
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator Round4()
    {
        Round4(ref triggers.PlayerChoise, RightElements, ref roundnumber, ref lock1, ref lock2,
        ref lock3, ref lock4, ref lock5, ref falselock1, ref falselock2, ref falselock3, ref falselock4, ref falselock5, ref false1, ref false2, ref false3, ref false4, ref false5, ref roundpased);
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator Round4false()
    {
        if (false1 == 1 || false2 == 1 || false3 == 1 || false4 == 1 || false5 == 1)
        {
            Invoke("ChangeColorForAllRed", 0.2f);
            Invoke("ChangeColorForAllWhite", 0.5f);
            yield return new WaitForSeconds(0.5f);

            ConstUpdater(ref lock1, ref lock2, ref lock3, ref lock4, ref lock5, ref falselock1, ref falselock2, ref falselock3, ref falselock4, ref falselock5, ref false1, ref false2, ref false3, ref false4, ref false5);
            triggers.PlayerChoise = 100;

            Round4(ref triggers.PlayerChoise, RightElements, ref roundnumber, ref lock1, ref lock2,
            ref lock3, ref lock4, ref lock5, ref falselock1, ref falselock2, ref falselock3, ref falselock4, ref falselock5, ref false1, ref false2, ref false3, ref false4, ref false5, ref roundpased);
        }
        yield return new WaitForSeconds(1f);
    }


    private void Update()
    {
        if (roundpased == 0)
        {
            StartCoroutine(Round1());
        }
        if (roundpased == 1)
        {
            StartCoroutine(Round2());
        }
        if (roundpased == 2)
        {
            StartCoroutine(Round3());
        }
        if (roundpased == 3)
        {
            StartCoroutine(Round4());
        }

        if (false1 == 1 || false2 == 1 && roundpased == 0)
        {
            StartCoroutine(Round1false());
        }
        if (false1 == 1 || false2 == 1 || false3 == 1 && roundpased == 1)
        {
            StartCoroutine(Round2false());
        }
        if (false1 == 1 || false2 == 1 || false3 == 1 || false4 == 1 && roundpased == 2)
        {
            StartCoroutine(Round3false());
        }
        if (false1 == 1 || false2 == 1 || false3 == 1 || false4 == 1 || false5 == 1 && roundpased == 3)
        {
            StartCoroutine(Round4false());
        }

        if (roundpased == 4)
        {
            Debug.Log("Игра пройдена!");
            roundpased = 5;
        }
    }
}
