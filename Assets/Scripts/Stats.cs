using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour, IDataPersistence
{
    //public int maxHealth;
    public int health;
    public float speed;
    public int money;
    public IceCream iceCream;

    private void Start()
    {
        //health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void LoadData(GameData gameData)
    {
        health = gameData.health;
        money = gameData.money;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.health = health;
        gameData.money = money;
    }
}
