using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySourceScript : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public int reflections;
    public float maxRayDistance;
    public LayerMask layerDetection;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    void Update()
    {
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, maxRayDistance, layerDetection);
        // Ray
        //Ray2D ray = new Ray2D(transform.position, transform.right);

        bool isMirror = false;
        Vector2 mirrorHitPoint = Vector2.zero;
        Vector2 mirrorHitNormal = Vector2.zero;

        for (int i = 0; i < reflections; i++)
        {
            lineRenderer.positionCount += 1;

            if (hitInfo.collider != null)
            {
                //lineRenderer.SetPosition(lineRenderer.positionCount - 1, hitInfo.point - ray.direction * -0.1f);
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hitInfo.point);

                isMirror = false;
                if (hitInfo.collider.CompareTag("Mirror"))
                {
                    mirrorHitPoint = (Vector2)hitInfo.point;
                    mirrorHitNormal = (Vector2)hitInfo.normal;
                    //hitInfo = Physics2D.Raycast((Vector2)hitInfo.point - ray.direction * -0.1f, Vector2.Reflect(hitInfo.point - ray.direction * -0.1f, hitInfo.normal), maxRayDistance, layerDetection);
                    hitInfo = Physics2D.Raycast((Vector2)hitInfo.point, Vector2.Reflect(hitInfo.point, hitInfo.normal), maxRayDistance, layerDetection);
                    isMirror = true;
                }
                else
                {
                    if (hitInfo.collider.CompareTag("RayReceiver"))
                    {
                        // logic when the puzzle is solved
                        hitInfo.collider.GetComponent<RayReceiverScript>().Activate();
                        //lineRenderer.positionCount = 0;
                        //this.enabled = false;
                    }
                    else
                        break;
                }
            }
            else
            {
                if (isMirror)
                {
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, mirrorHitPoint + Vector2.Reflect(mirrorHitPoint, mirrorHitNormal) * maxRayDistance);
                    break;
                }
                else
                {
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position + transform.right * maxRayDistance);
                    break;
                }
            }
        }
    }
}
