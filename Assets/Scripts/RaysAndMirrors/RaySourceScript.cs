using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySourceScript : MonoBehaviour
{
    public Material material;
    public float beamWidth;
    public Color beamColor;
    LaserBeam beam;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    void Update()
    {
        Destroy(GameObject.Find("Laser Beam"));
        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material, beamWidth, beamColor);
    }
}
