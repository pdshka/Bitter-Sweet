using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowMoney : MonoBehaviour
{
    [SerializeField]
    public TMP_Text textbox;

    private Stats player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
    }

    private void FixedUpdate()
    {
        textbox.text = player.money.ToString();
    }
}
