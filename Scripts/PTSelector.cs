using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PTSelector : MonoBehaviour
{
    public Sprite[] planetTextures;
    public GameObject PlanetTexture;
    public float circleColliderRadius = 4f;
    public GameObject player;
    void Start()
    {
        int i = Random.Range(0, planetTextures.Length);
        SpriteRenderer sr1 = PlanetTexture.AddComponent<SpriteRenderer>();
        sr1.sprite = planetTextures[i];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     /*void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.SetParent(transform);
    }*/
}
