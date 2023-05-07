using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Unity.VisualScripting;
//using UnityEditor.UI;

public class ShowMessageBox : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TextElement;
    [SerializeField]
    private GameObject MessageBox;
    [SerializeField]
    private GameObject hint;
    //[SerializeField]
    //private ImageEditor imageobj;
    public string[] HintText = { "test1", "test2", "test3", "test4" };
    private bool FirstAid = true;
    private bool playerIsNear = false;
    private bool On = false;
    private bool Flag;
    private int i = 0;


    void Update()
    {
        Flag = true;
        if (On && Input.GetKeyDown(KeyCode.E))
        {
            if (i == HintText.Length - 1)
            {
                MessageBox.SetActive(false);
                (i, On, Flag) = (0, false, false);
            }
            else
            TextElement.text = HintText[++i];
        }

        if (On && Input.GetKeyDown(KeyCode.Q) && i - 1 >= 0)
            TextElement.text = HintText[--i];
        if (playerIsNear && FirstAid)
        {
            ShowHint();
            FirstAid = false;
        }
        else if (playerIsNear && Input.GetKeyDown(KeyCode.E) && On == false && Flag)
        {
            ShowHint();
            hint.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsNear = true;
            if (FirstAid == false)
                hint.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsNear = false;
            if (FirstAid == false)
                hint.SetActive(false);
        }
        MessageBox.SetActive(false);
        (i, On) = (0, false);
    }
    private void ShowHint()
    {
        TextElement.text = HintText[0];
        MessageBox.SetActive(true);
        On = true;
    }
}
