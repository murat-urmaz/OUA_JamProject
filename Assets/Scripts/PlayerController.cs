using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;
    public GameObject bullet;
    public float interval = 1f;
    private float timer = 0f;
    public int bulletDamage = 1;
    public int playerScore = 0;
    public int playerLevel = 0;
    public ProjectileController ProjectileController;
    public bool isPlayerLevelUp = false;

    private Rigidbody2D CharRB;
    
    private void Start() {
        CharRB = GetComponent<Rigidbody2D>();
    }
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
        //transform.Translate(direction * speed * Time.fixedDeltaTime); // Not work for collisions
        CharRB.MovePosition(CharRB.position + direction * speed * Time.deltaTime);
    }
    void instantiateBullet()
    {
        if (timer >= interval)
        {
            
            Instantiate(bullet, transform.position, Quaternion.identity);
            timer = 0f; 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Experience"))
        {
            Destroy(collision);
            playerScore += 1;
            Debug.Log("mmmh deneyim");
        }
    }
    void levelCheck()
    {
        if(playerScore > 9)
        {
            playerLevel += 1;
            isPlayerLevelUp = true;
            //level atlama animasyonu ve skill secme ekrani secmek adina bir ekranin cikmasi
        }

    }
}
