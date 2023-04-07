using System.Collections;
using TMPro;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform targetTransform;

    public float speed = 5f;
    public float smoothness = 0.5f;
    public float range;
    private Vector2 targetPosition;

    public float fireRate = 0.5f;
    private float nextFireTime = 0.0f;
    [SerializeField] Rigidbody2D rigidbody2D;
   

    private void Update()
    {
        if (targetTransform)
        {

            targetPosition = Vector3.Lerp(targetPosition, targetTransform.position, smoothness);
            targetPosition.y = transform.position.y;
            if (Vector2.Distance(targetTransform.position, transform.position) >= range)
            {
                
                Vector3 direction = targetTransform.position - transform.position;
                direction.Normalize();
                rigidbody2D.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

            }
            else
            {
                Attack();
            }



            targetPosition = Vector2.Lerp(targetPosition, targetTransform.position, smoothness);
           

           
            Vector2 targetDirection = targetPosition - (Vector2)transform.position;
            targetDirection.Normalize();

            
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

    }
    private void Attack()
    {


        if (Time.time >= nextFireTime)
        {

         
            StartCoroutine(HitDelay());
            nextFireTime = Time.time + fireRate;

        }

    }
    IEnumerator HitDelay()
    {
        yield return new WaitForSeconds(.2f);
        print("hit");
    }
}
