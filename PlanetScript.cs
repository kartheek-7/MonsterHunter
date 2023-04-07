using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public float speed = 16f;
    public int monsterCount;
    public bool movePlanet;
    public GameObject Player;
    public PlayerScript playerScript;
    //public int count;

    public float planetSpeed = 16f;

    public Rigidbody2D playerPartsRigidbody;
    public Rigidbody2D playerRigidbody;
    //public MonsterSpawnerScript monsterSpawnerScript;
    void Start()
    {
        //monsterSpawnerScript=transform.GetComponentInChildren<MonsterSpawnerScript>();

        foreach (Transform child in transform)
        {
            monsterCount = 0;
            if (child.gameObject.CompareTag("Monster"))
            {
                monsterCount++;

            }
            //Debug.Log("Initial Count: " + monsterCount);

        }
       playerScript=Player.GetComponent<PlayerScript>();
        playerPartsRigidbody = playerScript.playerPartsRigidbody;
        playerRigidbody = playerScript.playerRigidbody;
        //movePlanet=playerScript.movePlanet;
    }

        void Update()
        {
            //Debug.Log("Monster Count is: " + monsterSpawnerScript.monsterCount);
            transform.Rotate(0f, 0f, speed * Time.deltaTime);
            monsterCount = 0;
            movePlanet = playerScript.movePlanet;
        foreach (Transform child in transform)
            {
            
                if (child.gameObject.CompareTag("Monster"))
                {
                    monsterCount++;

                }
               // Debug.Log("Number of Monsters: " + monsterCount);
            }

        if (playerScript.movePlanet)
        {
            transform.position += Vector3.left * planetSpeed * Time.deltaTime;
            float x=transform.position.x;
            //if((x>-30.5f && x<-29.5f) || (x > -0.5f && x < 0.5f) || (x > 29.5f && x < 30.5f))
            //if (x==-30 || x==0 || x==30)
           /* if ((x > -30.5f && x < -29.5f) || (x > -0.5f && x < 0.5f) || (x > 29.5f && x < 30.5f))
            {
                playerScript.movePlanet = false;
                playerPartsRigidbody.bodyType = RigidbodyType2D.Dynamic;
                playerRigidbody.bodyType = RigidbodyType2D.Dynamic;
                //playerScript.fromPlanet = true;
            }*/
            if (transform.position.x < -44f)
            {
                //count--;
                Destroy(gameObject);
            }
            /*if (transform.position.x == 0)
            {
                //movePlanet= false;
                playerScript.movePlanet = false;
            }*/
        }
        }

        private void Rlr(GameObject gameObject)
        {
            float y = UnityEngine.Random.Range(0, 2 * Mathf.PI);
            float r = 6.7f;
            float z = ((float)(180 * y / Mathf.PI));
            if (y > Mathf.PI)
            {
                z = (360 - z);
            }
            else
            {
                z = -z;
            }
            gameObject.transform.position = new Vector3(r * Mathf.Sin(y), r * Mathf.Cos(y), 0);
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, z);
        }

        private void Rr(GameObject gameObject)
        {
            float y = UnityEngine.Random.Range(0, 2 * Mathf.PI);
            float r = 6.7f;
            float z = ((float)(180 * y / Mathf.PI));
            if (y > Mathf.PI)
            {
                z = (360 - z);
            }
            else
            {
                z = -z;
            }
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, z);
        }

    public int MonsterCount()
    {
        return monsterCount;
    }

    public Vector3 GetPosition()
    {
        return  transform.position;
    }

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Center"))
        {
            playerScript.movePlanet = false;
        }
    }*/
}
