using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocationScript : MonoBehaviour
{
    public GameObject Planet;
    // Start is called before the first frame update
    Vector3 RL()
    {
        float r=Planet.GetComponent<CircleCollider2D>().radius;
        float x= Random.Range(0,2*Mathf.PI);
        return new Vector3(r * Mathf.Sin(x), r * Mathf.Cos(x), Planet.transform.position.z);
    }
}
