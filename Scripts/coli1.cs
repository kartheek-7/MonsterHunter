using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coli : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlanetTexture")
        {
            transform.SetParent(collision.transform);
        }
    }

}