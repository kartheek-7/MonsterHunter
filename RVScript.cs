using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RVScript : MonoBehaviour
{
    public GameObject Monster;
    public MonsterScript monsterScript;

    private void Start()
    {
        monsterScript=Monster.GetComponent<MonsterScript>();
        
    }
    public bool OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Player RV CV Triggered");
            //Debug.Log(monsterScript.sense);
            //monsterScript.sense = true;
            //Debug.Log(monsterScript.sense + " in RVScript");
            //monsterScript.direction = 1;
            //monsterScript.monsterSpeed = 100f;
            return true;
        }
        return false;
    }
}
