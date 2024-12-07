using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;



public class PlayerController : MonoBehaviour
{
    

    [SerializeField]
    float speed = 0.03f;

   
    bool isdamaging = false;
    Joystick joystick;
    
    Renderer rend;
    Color c;
    [Header("Unity Setup")]
    public ParticleSystem deathParticles;
    [Header("Unity Setup")]
    public ParticleSystem itemParticles;


     public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public Animator animator;
    

    //[SerializeField]
    //float speed = 0.03f;

    [SerializeField]
    float jump = 10f;
     
    public static int MaxHealth = 5;
    

    public int score;
    public Transform holder;
    TextMeshProUGUI healthtext;
    TextMeshProUGUI scoretext;
    [SerializeField]
    Transform collectedSound;
    [SerializeField]
    Transform ItemSound;
    [SerializeField]
    Transform EnemySound;
    [SerializeField]
    Transform DeathSound;


    [SerializeField] bool isFly = false;

    
    bool isShield;
    Transform myTransform;
    SpriteRenderer mySprite;
    Rigidbody2D rb;
    Animator anim;

     public int PlayerHealth = 3;

    bool isJump;
    internal bool isOver;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;
        //healthtext.text = "d7moomy777";
        isJump = false;
       
        PlayerHealth = MaxHealth;
        score = 0;
        myTransform = GetComponent<Transform>();
        mySprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //mySprite.color = Color.blue;
        //transform.gameObject.SetActive(false);

        healthtext = holder.Find("TextHealth").GetComponent<TextMeshProUGUI>();
        scoretext = holder.Find("TextScore").GetComponent<TextMeshProUGUI>();

        scoretext.text = "Score:0"+ score;
        healthtext.text = PlayerHealth + "/" + MaxHealth ;


    }

    // Update is called once per frame
    void Update()
    {
        float movX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(movX * speed, rb.velocity.y);

        if (PlayerHealth <= 0)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
        // if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //   {
        //        transform.Translate(new Vector3(-1 * speed, 0, 0));  //new Vector3(-0.03f, 0, 0));(-0.03f,0,0)
        // mySprite.flipX = true;
        //   }
        //else if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        //{
        //        transform.Translate(new Vector3(speed, 0, 0));
        //mySprite.flipX = false;
        if  (Input.GetAxis("Horizontal") > 0)
            mySprite.flipX = false;
        else if (Input.GetAxis("Horizontal") < 0)
            mySprite.flipX = true;





        if (Input.GetButtonDown("Jump") && isJump == false)


        {
            rb.velocity = new Vector2(0, jump);
            isJump = true;
            
        }
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
            isJump = false;
        //rb.velocity = new Vector2(speed* Input.GetAxis("Horizontal")* Time.deltaTime ,rb.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    public void Jump()
    {

        if (isFly==false && isJump==false)
        {
            rb.velocity = new Vector2(0, jump);
            isJump = true;isFly = true;
        }
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
            isJump = false; isFly = false;



    }
    

    private void FixedUpdate()
    {

        //rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
        //Debug.Log(Time.deltaTime);

      

        healthtext.text = PlayerHealth + "/" + MaxHealth;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("1") && isdamaging == false)
        {
            
            animator.SetTrigger("takedmg");
          //  PlayerHealth -= 1;
        StartCoroutine("TakeDamage");
        }
        if (collision.CompareTag("Enemy") && isdamaging == false)

        {
           // StartCoroutine("TakeDamage");
            if (isJump && rb.velocity.y < 0)
            {
                score += 50;
                scoretext.text = "score: " + score;
                Destroy(collision.gameObject);
                SoundOn2(collision.transform.position);
                Instantiate(deathParticles, transform.position, Quaternion.identity);
                rb.velocity = new Vector2(0, 13);
                isJump = true;
 
            }
            else
                StartCoroutine("TakeDamage");





            //Debug.Log("You Are Died");

        }
        //مجسم
        // انشئ الامر
        else if (collision.CompareTag("Gem"))
        {
            score += 500;
            scoretext.text = "score: " + score;
            SoundOn1(collision.transform.position);
            Destroy(collision.gameObject);
            Instantiate(itemParticles, transform.position, Quaternion.identity);
        }
        else if (collision.CompareTag("Cherry"))
        {
            score += 200;
            scoretext.text = "score: " + score;
            SoundOn1(collision.transform.position);
            Destroy(collision.gameObject);
            Instantiate(itemParticles, transform.position, Quaternion.identity);


        }
        else if (collision.CompareTag("Apple"))
        {
            score += 100;
            scoretext.text = "score: " + score;
            SoundOn1(collision.transform.position);
            Destroy(collision.gameObject);
            Instantiate(itemParticles, transform.position, Quaternion.identity);


        }
        else if (collision.CompareTag("Heart"))

        {
            if (PlayerHealth < MaxHealth)
                PlayerHealth++;
            
            //Debug.Log("Current Health:"+PlayerHealth + "/" + MaxHealth);
            healthtext.text = PlayerHealth + "/" + MaxHealth;
            SoundOn(collision.transform.position);
            Instantiate(itemParticles, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);

            
        }

    }

    void SoundOn(Vector3 itemPos)
    {
        Transform obj = Instantiate(collectedSound, itemPos, new Quaternion());
        obj.gameObject.SetActive(true);
        Destroy(obj.gameObject,obj.GetComponent<AudioSource>().clip.length);
        
        
    }
    void SoundOn1(Vector3 itemPos)
    {
        Transform obj = Instantiate(ItemSound , itemPos, new Quaternion());
        obj.gameObject.SetActive(true);
        Destroy(obj.gameObject, obj.GetComponent<AudioSource>().clip.length);


    }
    void SoundOn2(Vector3 itemPos)
    {
        Transform obj = Instantiate(EnemySound, itemPos, new Quaternion());
        obj.gameObject.SetActive(true);
        Destroy(obj.gameObject, obj.GetComponent<AudioSource>().clip.length);


    }
    void SoundOn3(Vector3 itemPos)
    {
        Transform obj = Instantiate(DeathSound, itemPos, new Quaternion());
        obj.gameObject.SetActive(true);
        Destroy(obj.gameObject, obj.GetComponent<AudioSource>().clip.length);


    }

    private void OnCollisionEnter2D(Collision2D collision)


{
        if (collision.gameObject.CompareTag("Cube"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);


        if (collision.gameObject.CompareTag("Cube1"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


        //        {
        //            if (isJump && rb.velocity.y < 0)
        //            {

        //                Destroy(collision.gameObject);
        //                SoundOn2(collision.transform.position);
        //                Instantiate(deathParticles, transform.position, Quaternion.identity);
        //                rb.velocity = new Vector2(0, 13);
        //                isJump = true;

        //            }
        //            else animator.SetTrigger("takedmg");
        //            PlayerHealth = PlayerHealth - 1;


        //            healthtext.text = PlayerHealth + "/" + MaxHealth;







        //            Debug.Log("You Are Died!");



    }



        //    }
        IEnumerator TakeDamage()
        {
         anim.SetTrigger("takedmg");
         PlayerHealth -= 1;
          SoundOn3(transform.position);
          isdamaging = true;
         c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(2f);
        isdamaging = false;
        c.a = 1f;
        rend.material.color = c;







        }

}





