using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFloating : MonoBehaviour
{
    public float speedX = 0.0f;
    public float distance_max = 0.0f;
    private int sign = 1;
    private float distance = 0.0f;
    private float sdt = 0.0f;

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    void Update()
    {
        sdt = speedX * Time.deltaTime;
        if ((distance + sdt) < distance_max)
        {
            this.transform.position += new Vector3(sign * sdt, 0.0f, 0.0f);
            distance += sdt;
        }
        else
        {
            transform.position += new Vector3(sign * (distance_max - distance), 0.0f, 0.0f);
            sign *= -1;
            distance = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.name.Equals("Player"))
        {
            sign *= -1;
            distance = distance_max - distance;
        }
}
}
