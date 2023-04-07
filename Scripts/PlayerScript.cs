using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    public GameObject playerPosition;
    public GameObject planet;
    public GameObject PlayerParts;
    public float playerSpeed = 10f;
    private float speedPower = 10f;
    
    public int direction = 1;
    public bool onPlanet=false;

    private Animator anim;

    public float PlayerHealth = 100f;
    public GameObject Canvas;
    private GameObject canvasClone;
    private HealthBarScript healthBarScript;

    public GameObject Rasengan;
    private GameObject rasengan;

    public Rigidbody2D playerPartsRigidbody;
    public Rigidbody2D playerRigidbody;

    public bool movePlanet;
    public bool fromPlanet;

    private bool aclock = false;
    private bool clock = false;
    private bool rasenganbool = false;
    private bool swordsbool = false;

    public float rasenganCoolDownTime = 0.15f;
    private float rasenganCoolDownTimer = 0f;

    public int monstersKilled = 0;
    public int planetScore = -1;

    //public  Text monsterScoreText;
    //public Text planetScoreText;

    public TextMeshProUGUI monsterScoreText;
    public TextMeshProUGUI planetScoreText;

    public bool dead=false;

    void Start()
    {
        transform.position = playerPosition.transform.position;

        anim= GetComponent<Animator>();

        canvasClone = Instantiate(Canvas);
        
        canvasClone.transform.position = transform.position + new Vector3(0f,1f,0f);
        canvasClone.transform.rotation = transform.rotation;
        canvasClone.transform.localScale=new Vector3(0.25f, 0.25f, 1f);
        //canvasClone.transform.parent = transform;
        canvasClone.transform.SetParent(transform, false);
        healthBarScript = canvasClone.GetComponentInChildren<HealthBarScript>();

        playerPartsRigidbody = PlayerParts.GetComponent<Rigidbody2D>();
        playerRigidbody = transform.GetComponent<Rigidbody2D>();

        movePlanet= false;
        fromPlanet= false;

        PlayerHealth = 100f;

    }

    void Update()
    {
        //Time.timeScale = 1f;
        //Input.GetKey(KeyCode.Q),Input.GetKey(KeyCode.W)
        if (aclock || clock || Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isRunning", true);
            if (swordsbool || Input.GetKey(KeyCode.S))
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isAttacking", true);
            }
            else
            {
                anim.SetBool("isAttacking", false);
            }
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (swordsbool || Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }

        rasenganCoolDownTimer -= Time.deltaTime;


        if ((rasenganbool || Input.GetKeyDown(KeyCode.D)) && onPlanet)
        {
            //rasenganCoolDownTimer -= Time.deltaTime;
            if(rasenganCoolDownTimer <= 0f)
            {
                rasengan = Instantiate(Rasengan);
                rasengan.transform.position = transform.position;
                rasengan.transform.parent = transform.parent;
                rasenganCoolDownTimer = rasenganCoolDownTime;
            }
            
        }


       if (movePlanet == false && !fromPlanet)
        {
            playerPartsRigidbody.bodyType = RigidbodyType2D.Dynamic;
            playerRigidbody.bodyType = RigidbodyType2D.Dynamic;
            playerPartsRigidbody.velocity = new Vector2(0f, 0f);
            playerPartsRigidbody.gravityScale = 9f;
            playerRigidbody.velocity = new Vector2(0f, 0f);
            playerRigidbody.gravityScale = 9f;
        }

        //Debug.Log("MovePlanet is: " + movePlanet);
        swordsbool = false;

        monsterScoreText.text= monstersKilled.ToString();

        if (PlayerHealth <= 0)
        {
            dead = true;
        }
        else
        {
            dead = false;
        }
    }


    public void isAntiClockm()
    {
        aclock=true;
    }

    public void isAntiClockn()
    {
        aclock = false;
    }

    public void isClockm()
    {
        clock = true;
    }
    public void isClockn()
    {
        clock = false;
    }
    public void isRasenganm()
    {
        rasenganbool = true;
    }

    public void isRasengann()
    {
        rasenganbool = false;
    }


    public void isSword()
    {
        swordsbool = true;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Planet")
        {
            onPlanet = true;
            fromPlanet = true;
            transform.parent = planet.transform;
            //Rigidbody2D playerPartsRigidbody = PlayerParts.GetComponent<Rigidbody2D>();
            playerPartsRigidbody.velocity = Vector2.zero;
            playerPartsRigidbody.gravityScale = 0;

            //Rigidbody2D playerRigidbody = transform.GetComponent<Rigidbody2D>();
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.gravityScale = 0;
            if (aclock || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f,0f,1f), angle: playerSpeed * speedPower*Time.deltaTime);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                direction = 1;
                //aclock = false;
                
            }

            if (clock || Input.GetKey(KeyCode.RightArrow))
            {
                
                transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, -1f), angle: playerSpeed * speedPower * Time.deltaTime);
                transform.localScale = new Vector3(-1*Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                direction = -1;
                //clock = false;
            }

         

        }

        if (collision.tag == "Teleporter")
        {
            onPlanet = false;
            transform.SetParent(null, true);
            Rigidbody2D playerPartsRigidbody = PlayerParts.GetComponent<Rigidbody2D>();
            //playerPartsRigidbody.velocity = Vector2.zero;
           // playerPartsRigidbody.velocity = new Vector2(0f, 1f);
            playerPartsRigidbody.gravityScale = -0.5f;

            Rigidbody2D playerRigidbody = transform.GetComponent<Rigidbody2D>();
            //playerRigidbody.velocity = new Vector2(0f, 1f);
            playerRigidbody.gravityScale = -0.5f;

            //PlayerHealth += 49f;
        }

        if (collision.tag == "Monster")
        {
            PlayerHealth -= 0.07f;
            healthBarScript.SetHealth(PlayerHealth);
            
            
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        

        

        if (collision.CompareTag("SpaceShip") && fromPlanet)
        {
            /*playerPartsRigidbody.velocity = Vector2.zero;
            playerPartsRigidbody.gravityScale = 0;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.gravityScale = 0;*/
            //Debug.Log("OnSpaceShippppppppppp");
            playerPartsRigidbody.bodyType = RigidbodyType2D.Static;
            playerRigidbody.bodyType = RigidbodyType2D.Static;
            movePlanet = true;
            fromPlanet= false;
            PlayerHealth += 49f;
        }
    }

}


