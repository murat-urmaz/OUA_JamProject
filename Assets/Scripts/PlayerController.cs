using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public event Action OnLevelUp;
    public float speed = 5f;
    private Vector2 direction;
    public GameObject bullet;
    public float interval = 1f;
    private float timer = 0f;
    public int bulletDamage = 1;
    public int playerScore = 0;
    public int playerLevel = 0;
    public bool isPlayerLevelUp = false;
    private Rigidbody2D CharRB;
    [SerializeField] Text score;

   
    private void Start() {
        CharRB = GetComponent<Rigidbody2D>();
        //score.text = "Skor: " + playerScore.ToString();

    }
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontalInput, verticalInput).normalized;
        levelCheck();
       // scoreText();
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
            
            Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<ProjectileController>();
           
            timer = 0f; 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Experience"))
        {
            Destroy(collision.gameObject);
            playerScore += 1;
            Debug.Log("mmmh deneyim");
        }
    }
    void levelCheck()
    {
       
        if(playerScore > 9 || Input.GetKeyDown(KeyCode.Escape))
        {
            playerLevel += 1;
            OnLevelUp?.Invoke();
            Debug.Log("Level atladimmm!!!");
            //level atlama animasyonu ve skill secme ekrani secmek adina bir ekranin cikmasi
        }

    }
    public void fasterCharacter()
    {
        speed += 1f;
    }
    public void maxHealth()
    {

    }
   public void scoreText()
    {
        score.text = "Skor: " + playerScore.ToString();
    }
}
