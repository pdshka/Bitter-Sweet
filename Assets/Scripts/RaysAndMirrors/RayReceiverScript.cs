using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayReceiverScript : MonoBehaviour
{
    public void Activate()
    {
        // TODO: logic when receiver activates
        GetComponent<SpriteRenderer>().color = Color.green;
    }
}
