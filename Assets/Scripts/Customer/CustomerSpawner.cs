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
    private GameObject customer;

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
                    GameObject c = Instantiate(customer, spawnPoint.position, Quaternion.identity) as GameObject;
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
