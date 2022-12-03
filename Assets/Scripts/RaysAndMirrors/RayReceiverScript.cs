using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayReceiverScript : MonoBehaviour
{
    [SerializeField]
    private Sprite activated;

    public void Activate()
    {
        GetComponent<SpriteRenderer>().sprite = activated;
    }
}
