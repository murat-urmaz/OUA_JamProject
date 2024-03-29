using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 5f;
    public float attackRange = 10f; 
    private GameObject target;
    public float distance;
    
    

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

        Vector3 direction = target.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.right);
        Debug.Log(angle);
        transform.Rotate(new Vector3 (0,0, angle+85));

    }

    private void controlEnemy()
    {
        if (target != null)
        {
            
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            if (Vector2.Distance(transform.position,target.transform.position)<distance)
            {
                gameObject.SetActive(false);
            }

           

        }
        else
        {

            gameObject.SetActive(false);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    
    
    
}