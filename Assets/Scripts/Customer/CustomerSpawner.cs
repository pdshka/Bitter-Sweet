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
}
