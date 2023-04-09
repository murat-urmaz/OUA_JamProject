using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI healthScore;
    int bulletspeed = 5;
    public int forLevelScore = 0;
    public int health = 100;
    private Animator anim;
    public float verticalInput;
    public float horizontalInput;
    private SpriteRenderer spriteRenderer;


    private void Start() {
        CharRB = GetComponent<Rigidbody2D>();
        score.text = "Skor: " + playerScore.ToString();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthScore.text = "Can: " + health.ToString(); //sadece görünmesi için eklendi

    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontalInput, verticalInput).normalized;
        levelCheck();
        scoreText();
        animControl();
        faceCheck();
        healthScore.text = "Health: " + health.ToString(); //sadece þimdilik görünmesi için eklendi
        //Debug.Log(health);

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

        if (timer >= interval && enemyControl())
        {

            GameObject Newbullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Newbullet.GetComponent<ProjectileController>().speed=bulletspeed;

            timer = 0f; 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Experience"))
        {
            Destroy(collision.gameObject);
            playerScore += 1;
            forLevelScore += 1;
            Debug.Log("mmmh deneyim");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10; 
        }
    }
    void levelCheck()
    {
       
        if(forLevelScore > 9 || Input.GetKeyDown(KeyCode.Escape))
        {
            playerLevel += 1;
            forLevelScore = 0;
            
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

    public void incSpeed()
    {
        bulletspeed += 3;

    }
    public bool enemyControl()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length !=0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void animControl()
    {
        if(horizontalInput == 0 && verticalInput == 0)
        {
            anim.SetBool("movingBool", false);
        }
        else
        {
            anim.SetBool("movingBool", true);
        }
    }
    void faceCheck()
    {
        if (horizontalInput > 0) 
        {
            spriteRenderer.flipX = false; 
        }
        else if (horizontalInput < 0) 
        {
            spriteRenderer.flipX = true; 
        }
    }
}
