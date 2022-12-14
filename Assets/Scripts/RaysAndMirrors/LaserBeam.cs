using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam
{
    public float maxDistance = 15f;
    Vector2 pos, dir;

    GameObject laserObj;
    LineRenderer laser;
    List<Vector3> laserIndices = new List<Vector3>();

    public LaserBeam(Vector2 pos, Vector2 dir, Material material, float width, Color color)
    {
        this.laser = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = "Laser Beam";
        this.pos = pos;
        this.dir = dir;

        this.laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.laser.startWidth = width;
        this.laser.endWidth = width;
        this.laser.material = material;
        this.laser.startColor = color;
        this.laser.endColor = color;

        this.laser.sortingOrder = 1;

        CastRay(pos, dir, laser);
    }

    void CastRay(Vector2 pos, Vector2 dir, LineRenderer laser)
    {
        laserIndices.Add(pos);

        Ray2D ray = new Ray2D(pos, dir);
        RaycastHit2D hitInfo = Physics2D.Raycast(pos, dir, maxDistance, 1);

        if(hitInfo.collider != null)
        {
            CheckHit(hitInfo, dir, laser);
        }
        else
        {
            laserIndices.Add(ray.GetPoint(maxDistance));
            UpdateLaser();
        }
    }

    void UpdateLaser()
    {
        int count = 0;
        laser.positionCount = laserIndices.Count;

        foreach (Vector2 idx in laserIndices)
        {
            laser.SetPosition(count, idx);
            count++;
        }
    }

    void CheckHit(RaycastHit2D hitInfo, Vector2 direction, LineRenderer laser)
    {
        if(hitInfo.collider.gameObject.tag == "Mirror")
        {
            Vector2 pos = hitInfo.point;
            Vector2 dir = Vector2.Reflect(direction, hitInfo.normal);

            CastRay(pos, dir, laser);
        }
        else
        {
            if (hitInfo.collider.gameObject.tag == "RayReceiver")
            {
                hitInfo.collider.GetComponent<RayReceiverScript>().Activate();
            }
            laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }
    }
}
