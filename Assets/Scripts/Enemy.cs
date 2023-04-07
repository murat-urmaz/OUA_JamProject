using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    [SerializeField] private EnemyType enemyType = null;
    public Transform target;
    void Start()
    {
        startQualifications();
    }

    // Update is called once per frame
    void Update()
    {
        findPlayer();
        moveToPlayer();
    }
    void startQualifications()
    {
        GetComponent<Renderer>().material.color = enemyType.enemyColor;
        transform.localScale = enemyType.enemyScale;
        speed = enemyType.enemySpeed;
        
    }
    void findPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Playerr").transform;
    }
    void moveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
