using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
//using UnityEditor.Animations;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public GameObject[] MonsterSprites;
    public GameObject monsterTransform;
    public int Health = 100;
    public HealthBarScript healthBarScript;
    public GameObject CanvasPrefab;
    public GameObject canvasClone;
    public PlanetScript planetScript;
    public Vector3 Centre;
   //public GameObject monsterSpawner;
  // public MonsterSpawnerScript monsterSpawnerScript;

    public float monsterSpeed;
    public float speedPower;
    public int direction;
    public bool sense=false;

    public GameObject Pointl;
    public GameObject Pointr;
    //public GameObject Point;
    public GameObject pointl;
    public GameObject pointr;
    public GameObject point;

    public Vector3 antiClockWise;

    public GameObject player;
    public float followRange = 5f;
    public float r = 6.5f;

    public Animator anim;
    //public AnimationClip animClip;
    //public AnimatorController MonsterAC;
    //private AnimatorController monsterAC;
    public GameObject monsterbody;
    public GameObject monsterBody;

    public PlayerScript playerScript;
    private int k = 1;
    public void Awake()
    {
       /* planetScript= GetComponentInParent<PlanetScript>();
        //planetScript = GameObject.FindObjectOfType<PlanetScript>();
        Centre =planetScript.GetPosition();
        monsterTransform.transform.position =Centre;*/
        canvasClone = Instantiate(CanvasPrefab);
        //canvasClone.transform.parent = monsterTransform.transform;
        canvasClone.transform.SetParent(monsterTransform.transform, false);
        healthBarScript = canvasClone.GetComponentInChildren<HealthBarScript>();

        pointl = Instantiate(Pointl);
        pointl.transform.position = monsterTransform.transform.position + new Vector3(-0.01f, 0, 0);
        pointl.transform.parent = monsterTransform.transform;

        pointr = Instantiate(Pointr);
        pointr.transform.position = monsterTransform.transform.position + new Vector3(0.01f, 0, 0);
        pointr.transform.parent = monsterTransform.transform;

        monsterBody=Instantiate(monsterbody);
        monsterBody.transform.position = monsterTransform.transform.position;
        monsterBody.transform.parent = monsterTransform.transform;

        int x = Random.Range(0, MonsterSprites.Length);
        monsterBody = Instantiate(MonsterSprites[x]);
        monsterBody.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
        monsterBody.transform.parent = monsterTransform.transform;
    }
    public void Start()
    {
        planetScript = GetComponentInParent<PlanetScript>();
        monsterSpeed = 1f;
        speedPower = 10f;
        direction = 1;
                                    
        monsterBody.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
      
        BoxCollider2D br = monsterBody.AddComponent<BoxCollider2D>();
        br.size = new Vector2(4.5f, 9f);
        br.isTrigger = true;

        
        player = GameObject.FindWithTag("Player");
        point = pointl;

        anim=monsterBody.GetComponent<Animator>();
        //monsterSpawner = GameObject.FindGameObjectWithTag("MonsterSpawner");
        //monsterSpawnerScript=monsterSpawner.GetComponent<MonsterSpawnerScript>();
        //monsterSpawnerScript = planet.GetComponentInChildren<MonsterSpawnerScript>();

        playerScript=player.GetComponent<PlayerScript>();
    }
    void Update()
    {
        Centre = planetScript.GetPosition();
        //monsterTransform.transform.position = Centre;
        float distance = Vector3.Distance(monsterTransform.transform.position, player.transform.position);
            anim.speed = 1;
            
            if (direction == 1)
            {
                
                point = pointl;
            }
            else
            {
                
                point = pointr;
            }

        
        if (distance <= followRange)
        {
            
            antiClockWise = point.transform.position - monsterTransform.transform.position;
            monsterSpeed = 2;

            Vector3 differenceVector = player.transform.position - monsterTransform.transform.position;
            float angle = Mathf.Acos((antiClockWise.y * differenceVector.y + antiClockWise.x * differenceVector.x) / Mathf.Sqrt((Mathf.Pow(antiClockWise.x, 2) + Mathf.Pow(antiClockWise.y, 2)) * (Mathf.Pow(differenceVector.x, 2) + Mathf.Pow(differenceVector.y, 2))));



            sense = true;
            //float temp = Mathf.Sqrt(1 - (Mathf.Pow(distance / 2 * r, 2)));
            //monsterTransform.transform.LookAt(differenceVector * temp);

            if (distance < 1.3f)
            {
                anim.speed = 1.3f;
                //Debug.Log("Monster is within 0.1f");
              
                monsterTransform.transform.localScale = new Vector3(direction * Mathf.Abs(monsterTransform.transform.localScale.x), monsterTransform.transform.localScale.y, monsterTransform.transform.localScale.z);
            }
            else
            {
                

                if (angle < Mathf.PI / 2)
                {
                    direction = 1;

                }
                else
                {
                    direction = -1;
                }
                monsterTransform.transform.RotateAround(Centre, new Vector3(0f, 0f, direction), angle: monsterSpeed * speedPower * Time.deltaTime);
                monsterTransform.transform.localScale = new Vector3(direction * Mathf.Abs(monsterTransform.transform.localScale.x), monsterTransform.transform.localScale.y, monsterTransform.transform.localScale.z);

            }


        }

        else
        {
            monsterSpeed = 1;
            sense= false;
            //Debug.Log("Player Not Within Range ");
            
            monsterTransform.transform.RotateAround(Centre, new Vector3(0f, 0f, direction), angle: monsterSpeed * speedPower * Time.deltaTime);
           monsterTransform.transform.localScale = new Vector3(direction * Mathf.Abs(monsterTransform.transform.localScale.x), monsterTransform.transform.localScale.y, monsterTransform.transform.localScale.z);
           
        }
        
            

     }

    public void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag == "Swords")
            {
            
                Health -= 5;
                healthBarScript.SetHealth(Health);
                
                if (Health < 0)
                {
                //monsterSpawnerScript = transform.GetComponentInParent<MonsterSpawnerScript>();
                //monsterSpawnerScript.MonsterCount();
                    if (k == 1)
                    {
                        playerScript.monstersKilled += 1;
                        k = 2;
                    }
                
                Destroy(gameObject);
                }
            }

        if (collision.CompareTag("Patrol") && !sense)
        {
            direction = -1*direction;
          
        }

        if (collision.tag== "Rasengan")
        {
            Health-= 9;
            healthBarScript.SetHealth(Health);
            if (Health < 0)
            {
                //monsterSpawnerScript = transform.GetComponentInParent<MonsterSpawnerScript>();
                //monsterSpawnerScript.MonsterCount();
                if (k == 1)
                {
                    playerScript.monstersKilled += 1;
                    k = 2;
                }
                Destroy(gameObject);
            }
        }
        

    }

}

