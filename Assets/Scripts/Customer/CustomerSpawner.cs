using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    public int maxCustomersOnScreen;
    public int currentCustomersOnScreen;
    [SerializeField]
    private GameObject[] customers;
    public int firstSortingOrder = 1;

    [SerializeField]
    private float realodTime;
    private bool isReloading;
    public bool cafeClosed;

    [SerializeField]
    private IceCream[] iceCreams;

    [SerializeField]
    private GameObject[] iceCreamBoxes;

    private void Start()
    {
        if (iceCreams.Length != iceCreamBoxes.Length)
        {
            Debug.LogError("Размеры массивов мороженых и автоматов не совпадают!");
        }
    }

    void FixedUpdate()
    {
        if (!cafeClosed)
        {
            if (!isReloading)
            {
                if (currentCustomersOnScreen < maxCustomersOnScreen)
                {
                    currentCustomersOnScreen++;
                    GameObject c = Instantiate(customers[Random.RandomRange(0, customers.Length)], spawnPoint.position, Quaternion.identity) as GameObject;
                    c.GetComponent<SpriteRenderer>().sortingOrder = firstSortingOrder++;
                    IceCream iceCream = ChooseIceCream();
                    c.GetComponentInChildren<Customer>().order.iceCream = iceCream;
                    c.GetComponentInChildren<Customer>().order.flavorSprite.sprite = iceCream.sprite;
                    StartCoroutine(Reload(realodTime));
                }
            }
        }
    }

    IEnumerator Reload(float reloadTime)
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }

    IceCream ChooseIceCream()
    {
        int i = 0;
        do
        {
            i = Random.RandomRange(0, iceCreams.Length);
        }
        while (!iceCreamBoxes[i].GetComponent<IceCreamBox>().unlocked);
        IceCream iceCream = iceCreams[i];
        return iceCream;
    }
}
