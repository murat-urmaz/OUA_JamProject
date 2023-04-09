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
    public float interval = 5f;
    private float timer = 0f;
    public int bulletDamage = 1;
    public int playerScore = 0;
    public int playerLevel = 0;
    public bool isPlayerLevelUp = false;
    private Rigidbody2D CharRB;
    private SpriteRenderer CharSR;
    private bool isFacingRight = true;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI healthScore;
    int bulletspeed = 15;
    public int forLevelScore = 0;
    public int health = 100;
    private Animator anim;
    public float verticalInput;
    public float horizontalInput;
    private SpriteRenderer spriteRenderer;
    [SerializeField] AudioSource audioSource;

    public GameObject GameManagerRef;
    private PauseManager pauseManager;

    public Slider Healthbar;
    public Slider ExperienceBar;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI FinalScore;

    public GameObject endGameGUI;

    private bool isGameStarted = false;

    public GameObject DamageTextPrefab;

    public void StartGame(){
        isGameStarted = true;
        pauseManager = GameManagerRef.GetComponent<PauseManager>();
    }

    private void Start() {
        CharRB = GetComponent<Rigidbody2D>();
        CharSR = GetComponent<SpriteRenderer>();
        score.text = playerScore.ToString();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthScore.text = "Can: " + health.ToString(); //sadece g�r�nmesi i�in eklendi
        Healthbar.value = health;
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
        healthScore.text = "Health: " + health.ToString(); //sadece �imdilik g�r�nmesi i�in eklendi
        Healthbar.value = health;
        ExperienceBar.value = forLevelScore;
        Level.text = playerLevel.ToString();

        //Debug.Log(health);

    }

    private void FixedUpdate()
    {
        if(isGameStarted){
        characterMovement();
        timer += Time.deltaTime;
        instantiateBullet();
        }
    }
    
    void characterMovement()
    {
        //transform.Translate(direction * speed * Time.fixedDeltaTime); // Not work for collisions
        if(horizontalInput<0 && isFacingRight){
            CharSR.flipX = true;
            isFacingRight = false;
        }
        else if(horizontalInput>0 && !isFacingRight){
            CharSR.flipX = false;
            isFacingRight = true;
        }

        CharRB.MovePosition(CharRB.position + direction * speed * Time.deltaTime);
    }
    
    void instantiateBullet()
    {

        if (timer >= interval && enemyControl())
        {

            Debug.Log("Timer:" + timer);
            Debug.Log("Interval:" + interval);
            timer = 0;
            GameObject Newbullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Newbullet.GetComponent<ProjectileController>().speed=bulletspeed;
            audioSource.Play();
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
            var text = Instantiate(DamageTextPrefab,transform.position + new Vector3(0,2f,0), Quaternion.identity, transform);
            text.GetComponent<TextMesh>().text = "10";
            text.GetComponent<TextMesh>().color = Color.red;
            DeathCheck();
        }
    }

    private void DeathCheck(){

        if(health<=0){
            endGameGUI.SetActive(true);
            pauseManager.PauseGame();
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
        score.text = playerScore.ToString();
        FinalScore.text = playerScore.ToString();;
    }

    public void incSpeed()
    {
        if(interval>0.5f){
            interval -= 0.5f;
        }
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
