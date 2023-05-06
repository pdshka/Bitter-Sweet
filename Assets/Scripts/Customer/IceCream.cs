using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New IceCream", menuName = "IceCream", order = 52)]
public class IceCream : ScriptableObject
{
    public string flavor;
    public int cost;
    public Sprite sprite;
}
