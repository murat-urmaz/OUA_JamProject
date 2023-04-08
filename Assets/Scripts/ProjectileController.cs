using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 5f;
    public float attackRange = 10f; 
    private GameObject target;
    GameObject PlayerController;
    public bool thereIsEnemy;

    private void Start()
    {
        FindNearestEnemy(); 
    }

    private void Update()
    {
        controlEnemy();
    
    }

    private void FindNearestEnemy()
    {
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                target = enemy;
            }
        }
    }

    private void controlEnemy()
    {
        if (target != null)
        {
            
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            


        }
        else
        {
            FindNearestEnemy();
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log("heey buradayým");
        }
    }
    
}