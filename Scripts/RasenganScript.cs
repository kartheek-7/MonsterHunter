using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasenganScript : MonoBehaviour
{
    private float rasenganSpeed = 50f;
    public PlayerScript playerScript;
    public int direction;
    public float rasenganLifeTimer = 1.1f;
    public void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerScript=player.GetComponent<PlayerScript>();
        direction=playerScript.direction;
    }

    public void Update()
    {
        transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, direction), angle: rasenganSpeed * Time.deltaTime);
        rasenganLifeTimer-= Time.deltaTime;
        if (rasenganLifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Monster")
        {
            Destroy(gameObject);
        }
    }
}
