using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySourceScript : MonoBehaviour
{
    public float rayDistance = 10f;
    public Transform rayPoint;
    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 10f, Color.yellow);
        RaycastHit2D hitObject = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), rayDistance);

        if (hitObject)
        {
            //    Debug.Log("hit: " + hit.collider.name);
            lineRenderer.SetPosition(0, rayPoint.position);
            lineRenderer.SetPosition(1, hitObject.point);
        }
        else
        {
            lineRenderer.SetPosition(0, rayPoint.position);
            lineRenderer.SetPosition(1, rayPoint.position + rayPoint.right * rayDistance);
        }
    }
}
