using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerScript : MonoBehaviour
{
    public GameObject MonsterPrefab;
    //public GameObject Player;
    public GameObject Planet;
    //public PlanetScript planetScript1;
    public Vector3 Centre;
    //public int monsterCount;
    //public GameObject MonsterBody;

    private int k = 0;
    public int x;
    private List<GameObject> inactiveMonsters = new List<GameObject>();
    private List<GameObject> inactivecanvasClone = new List<GameObject>();
    private List<GameObject> inactiveMonsterBody= new List<GameObject>();

    public float y;
    public float r;

    void Start()
    {
        Centre=Planet.GetComponent<PlanetScript>().GetPosition();
        x = Random.Range(1, 5);
        //planetScript1 = Planet.GetComponent<PlanetScript>();
        // monsterCount = x + 1;
        // Debug.Log("Initial count is: "+ monsterCount);
        // Pre-populate the inactiveMonsters list with a specified number of monsters.
        for (int i = 0; i < x+1; i++)
        {
            GameObject monster = Instantiate(MonsterPrefab);
            monster.transform.parent = Planet.transform;
            
            //monster.transform.position=Planet.transform.position;
            monster.SetActive(false);
            inactiveMonsters.Add(monster);
            
            MonsterScript monsterScript = monster.GetComponent<MonsterScript>();
            //monsterScript.planetScript = planetScript1;
            monsterScript.canvasClone.SetActive(false);
            inactivecanvasClone.Add(monsterScript.canvasClone) ;

           monsterScript.monsterBody.SetActive(false);
           inactiveMonsterBody.Add(monsterScript.monsterBody) ;

           // monsterScript.Centre=Centre;

            
            
        }

        y = Random.Range(0, 2 * Mathf.PI);
        r = 6.7f;
    }

    void Update()
    {
        if (k > x)
        {
            return;
        }

        
        float z = ((float)(180 * y / Mathf.PI));
        if (y > Mathf.PI)
        {
            z = (360 - z);
        }
        else
        {
            z = -z;
        }
        Vector3 mv= new Vector3(r * Mathf.Sin(y), r * Mathf.Cos(y), 0)+Centre;
        Quaternion mr = Quaternion.Euler(0, 0, z);
        GameObject monster;
        GameObject canvasClone;
        GameObject monsterbody;

        if (inactiveMonsters.Count > 0)
        {
            monster = inactiveMonsters[0];
            inactiveMonsters.RemoveAt(0);
            monster.SetActive(true);

            canvasClone = inactivecanvasClone[0];
            inactivecanvasClone.RemoveAt(0);
            canvasClone.SetActive(true);

            monsterbody = inactiveMonsterBody[0];
            inactiveMonsterBody.RemoveAt(0);
            monsterbody.SetActive(true);
        }
        else
        {
            return;
        }

        

        monster.transform.position = mv;
        canvasClone.transform.position = mv;
        monsterbody.transform.position = mv;

        monster.transform.rotation = mr;
        canvasClone.transform.rotation = mr;
        monsterbody.transform.rotation = mr;

        
        //monster.transform.parent = Planet.transform;

  
        y=(y+Mathf.PI/3)%(Mathf.PI*2);
        k++;
    }

  /*  public void MonsterCount()
   {
        //monsterCount = x + 1;
        monsterCount--;
        Debug.Log("Monster Count is: " + monsterCount);
    }*/
}

