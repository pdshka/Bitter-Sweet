using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowIceCream : MonoBehaviour
{
    [SerializeField]
    private Image iceCreamImage;
    [SerializeField]
    private Image pawImage; 

    private Stats player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
    }

    private void FixedUpdate()
    {
        if (player.iceCream == null)
        {
            iceCreamImage.enabled = false;
            pawImage.color = new Color(1, 1, 1);
        }
        else
        {
            iceCreamImage.enabled = true;
            iceCreamImage.sprite = player.iceCream.sprite;
            pawImage.color = new Color(0.7f, 0.7f, 0.7f);
        }
    }
}
