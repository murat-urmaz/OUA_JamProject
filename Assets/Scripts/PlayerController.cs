using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;
    public GameObject bullet;
    public float interval = 1f;
    private float timer = 0f;
    public int bulletDamage = 1;
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontalInput, verticalInput).normalized;
    }

    private void FixedUpdate()
    {
        characterMovement();
        timer += Time.deltaTime;
        instantiateBullet();


    }
    void characterMovement()
    {
        transform.Translate(direction * speed * Time.fixedDeltaTime);
    }
    void instantiateBullet()
    {
        if (timer >= interval)
        {
            
            Instantiate(bullet, transform.position, Quaternion.identity);
            timer = 0f; 
        }
    }
}
