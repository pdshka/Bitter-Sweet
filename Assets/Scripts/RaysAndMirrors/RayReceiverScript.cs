using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayReceiverScript : MonoBehaviour
{
    public void Activate()
    {
        // something to do....
        GetComponent<SpriteRenderer>().color = Color.green;
    }
}
