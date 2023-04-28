using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    private int ActivePallet = 0;
    private int StayIn = 0;
    public static int PlayerChoise = 100;

    [SerializeField] private SpriteRenderer SpriteObj1;
    [SerializeField] private SpriteRenderer SpriteObj2;
    [SerializeField] private SpriteRenderer SpriteObj3;
    [SerializeField] private SpriteRenderer SpriteObj4;
    [SerializeField] private SpriteRenderer SpriteObj5;
    [SerializeField] private SpriteRenderer SpriteObj6;
    [SerializeField] private SpriteRenderer SpriteObj7;
    [SerializeField] private SpriteRenderer SpriteObj8;
    [SerializeField] private SpriteRenderer SpriteObj9;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("One"))    // 1
        {
            ActivePallet = 1;
            StayIn = 1;
        }
        if (collision.gameObject.name.Equals("Two"))    // 2
        {
            ActivePallet = 2;
            StayIn = 1;
        }
        if (collision.gameObject.name.Equals("Three"))    // 3
        {
            ActivePallet = 3;
            StayIn = 1;
        }
        if (collision.gameObject.name.Equals("Four"))    // 4
        {
            ActivePallet = 4;
            StayIn = 1;
        }
        if (collision.gameObject.name.Equals("Five"))    // 5
        {
            ActivePallet = 5;
            StayIn = 1;
        }
        if (collision.gameObject.name.Equals("Six"))    // 6
        {
            ActivePallet = 6;
            StayIn = 1;
        }
        if (collision.gameObject.name.Equals("Seven"))    // 7
        {
            ActivePallet = 7;
            StayIn = 1;
        }
        if (collision.gameObject.name.Equals("Eigth"))    // 8
        {
            ActivePallet = 8;
            StayIn = 1;
        }
        if (collision.gameObject.name.Equals("Nine"))    // 9
        {
            ActivePallet = 9;
            StayIn = 1;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("One"))    // 1
        {
            ActivePallet = 1;
            StayIn = 0;
        }
        if (collision.gameObject.name.Equals("Two"))    // 2
        {
            ActivePallet = 2;
            StayIn = 0;
        }
        if (collision.gameObject.name.Equals("Three"))    // 3
        {
            ActivePallet = 3;
            StayIn = 0;
        }
        if (collision.gameObject.name.Equals("Four"))    // 4
        {
            ActivePallet = 4;
            StayIn = 0;
        }
        if (collision.gameObject.name.Equals("Five"))    // 5
        {
            ActivePallet = 5;
            StayIn = 0;
        }
        if (collision.gameObject.name.Equals("Six"))    // 6
        {
            ActivePallet = 6;
            StayIn = 0;
        }
        if (collision.gameObject.name.Equals("Seven"))    // 7
        {
            ActivePallet = 7;
            StayIn = 0;
        }
        if (collision.gameObject.name.Equals("Eigth"))    // 8
        {
            ActivePallet = 8;
            StayIn = 0;
        }
        if (collision.gameObject.name.Equals("Nine"))    // 9
        {
            ActivePallet = 9;
            StayIn = 0;
        }
    }

    private void ChangeColorBack1()
    {
        SpriteObj1.material.color = Color.white;
    }

    private void ChangeColorBack2()
    {
        SpriteObj2.material.color = Color.white;
    }

    private void ChangeColorBack3()
    {
        SpriteObj3.material.color = Color.white;
    }

    private void ChangeColorBack4()
    {
        SpriteObj4.material.color = Color.white;
    }

    private void ChangeColorBack5()
    {
        SpriteObj5.material.color = Color.white;
    }

    private void ChangeColorBack6()
    {
        SpriteObj6.material.color = Color.white;
    }

    private void ChangeColorBack7()
    {
        SpriteObj7.material.color = Color.white;
    }

    private void ChangeColorBack8()
    {
        SpriteObj8.material.color = Color.white;
    }

    private void ChangeColorBack9()
    {
        SpriteObj9.material.color = Color.white;
    }

    private void ChangeColorActive(SpriteRenderer SpriteObj)
    {
        SpriteObj.material.color = Color.green;
    }

    private IEnumerator Wait()
    {
        if (ActivePallet == 1) { ChangeColorActive(SpriteObj1); Invoke("ChangeColorBack1", 0.5f); }
        if (ActivePallet == 2) { ChangeColorActive(SpriteObj2); Invoke("ChangeColorBack2", 0.5f); }
        if (ActivePallet == 3) { ChangeColorActive(SpriteObj3); Invoke("ChangeColorBack3", 0.5f); }
        if (ActivePallet == 4) { ChangeColorActive(SpriteObj4); Invoke("ChangeColorBack4", 0.5f); }
        if (ActivePallet == 5) { ChangeColorActive(SpriteObj5); Invoke("ChangeColorBack5", 0.5f); }
        if (ActivePallet == 6) { ChangeColorActive(SpriteObj6); Invoke("ChangeColorBack6", 0.5f); }
        if (ActivePallet == 7) { ChangeColorActive(SpriteObj7); Invoke("ChangeColorBack7", 0.5f); }
        if (ActivePallet == 8) { ChangeColorActive(SpriteObj8); Invoke("ChangeColorBack8", 0.5f); }
        if (ActivePallet == 9) { ChangeColorActive(SpriteObj9); Invoke("ChangeColorBack9", 0.5f); }
        yield return new WaitForSeconds(1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && StayIn == 1 && ActivePallet == 1)
        {
            StartCoroutine(Wait());
            PlayerChoise = 1;
        }

        if (Input.GetKeyDown(KeyCode.F) && StayIn == 1 && ActivePallet == 2)
        {
            StartCoroutine(Wait());
            PlayerChoise = 2;
        }

        if (Input.GetKeyDown(KeyCode.F) && StayIn == 1 && ActivePallet == 3)
        {
            StartCoroutine(Wait());
            PlayerChoise = 3;
        }

        if (Input.GetKeyDown(KeyCode.F) && StayIn == 1 && ActivePallet == 4)
        {
            StartCoroutine(Wait());
            PlayerChoise = 4;
        }

        if (Input.GetKeyDown(KeyCode.F) && StayIn == 1 && ActivePallet == 5)
        {
            StartCoroutine(Wait());
            PlayerChoise = 5;
        }

        if (Input.GetKeyDown(KeyCode.F) && StayIn == 1 && ActivePallet == 6)
        {
            StartCoroutine(Wait());
            PlayerChoise = 6;
        }

        if (Input.GetKeyDown(KeyCode.F) && StayIn == 1 && ActivePallet == 7)
        {
            StartCoroutine(Wait());
            PlayerChoise = 7;
        }

        if (Input.GetKeyDown(KeyCode.F) && StayIn == 1 && ActivePallet == 8)
        {
            StartCoroutine(Wait());
            PlayerChoise = 8;
        }

        if (Input.GetKeyDown(KeyCode.F) && StayIn == 1 && ActivePallet == 9)
        {
            StartCoroutine(Wait());
            PlayerChoise = 9;
        }
    }
}
