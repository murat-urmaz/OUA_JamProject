using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy Type", menuName = "Enemy Type")]
public class EnemyType : ScriptableObject
{
    public Color enemyColor = Color.white;
    public float enemySpeed = 5;
    public Vector3 enemyScale = Vector2.one;
    
}

