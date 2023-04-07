using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawnerScript : MonoBehaviour
{

    public GameObject Planet;
    public GameObject planet;
    public PlanetScript planetScript;
    public GameObject planetSpawnPosition;
    public GameObject spaceShip;
    public SpaceShipScript spaceShipScript;
    private int x = 0;

    public List<GameObject> PlanetsList = new List<GameObject>();

    public GameObject Player;
    public PlayerScript playerScript;
    public int count;

    public MonsterSpawnerScript monsterSpawnerScript;
    public GameObject Center;
    public CenterScript centerScript;
    public void Start()
    {
       spaceShipScript=spaceShip.GetComponent<SpaceShipScript>();
        playerScript = Player.GetComponent<PlayerScript>();
        InitialPlanets();
        centerScript= Center.GetComponent<CenterScript>();
    }

    void InitialPlanets()
    {
        for(int i = 0; i < 2; i++)
        {
            Vector3 v=new Vector3(x,0,0);
            GameObject temp=Instantiate(Planet, new Vector3(x, 0, 0), Quaternion.Euler(0,0,0));
           planetScript = temp.GetComponent<PlanetScript>();
            monsterSpawnerScript = temp.GetComponentInChildren<MonsterSpawnerScript>();
            monsterSpawnerScript.Planet = temp;
            planetScript.Player = Player;
            PlanetsList.Add(temp);
            //spaceShipScript.planet=temp;
            //planet.transform.position = v;

            x += 30;
        }
       spaceShipScript.planet = PlanetsList[0];
       playerScript.planet= PlanetsList[0];
        PlanetsList.RemoveAt(0);
        count = 2;
    }
    
    void Update()
    {
        //bool one = false;
        if (playerScript.movePlanet)
        {
            if (count < 4 && centerScript.toSpawn)
            {
                GameObject temp = Instantiate(Planet, new Vector3(60, 0, 0), Quaternion.Euler(0, 0, 0));
                PlanetsList.Add(temp);
                planetScript = temp.GetComponent<PlanetScript>();
                monsterSpawnerScript = temp.GetComponentInChildren<MonsterSpawnerScript>();
                monsterSpawnerScript.Planet = temp;
                planetScript.Player = Player;
                //spaceShipScript.planet = PlanetsList[0];
               //playerScript.planet = PlanetsList[0];
                PlanetsList.RemoveAt(0);
                count++;
                centerScript.toSpawn= false;
            }

            
        }
        count = GameObject.FindGameObjectsWithTag("Planet").Length;
    }
}
