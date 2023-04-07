using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSSelector : MonoBehaviour
{
    public Sprite[] planetShapes;
    public GameObject PlanetShape;
    void Start()
    {
        int i=Random.Range(0,planetShapes.Length);
        SpriteRenderer sr1= PlanetShape.AddComponent<SpriteRenderer>();
        sr1.sprite = planetShapes[i];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
