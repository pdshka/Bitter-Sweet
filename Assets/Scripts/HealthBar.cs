using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Stats stats;
    [SerializeField]
    private Sprite[] sprites = new Sprite[0];

    private void Start()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<Stats>();
    }

    private void Update()
    {
        GetComponent<Image>().sprite = sprites[stats.health];
    }
}