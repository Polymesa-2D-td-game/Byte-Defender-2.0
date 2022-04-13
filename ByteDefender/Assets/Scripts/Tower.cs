using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("General Tower Information")]
    [SerializeField]
    private string towerName, towerDescription;
    [SerializeField]
    private int cost;
    [Header("General Tower Stats")]
    [SerializeField]
    private float range;

    // Indicates if tower is placed and active (so it can attack)
    private bool isActive = false;

    public string TowerName { get { return towerName; } set { towerName = value; } }
    public int Cost { get { return cost; } set { cost = value; } }
    public float Range { get { return range; } set { range = value; } }
}
