using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerFocus : MonoBehaviour
{
    public GameObject Player;
    public PlayerScript playerScript;
    public Vector3 offsetp;

    public Camera camera;
    public int count = 0;

    //public GameObject spaceShip;
    //public SpaceShipScript spaceShipScript;
    // Start is called before the first frame update
    void Start()
    {
        offsetp = transform.position+new Vector3(0f,-9f,0f);
        playerScript = Player.GetComponent<PlayerScript>();

        camera = transform.GetComponent<Camera>();
        //spaceShipScript=spaceShip.GetComponent<SpaceShipScript>();  
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerScript.onPlanet)
        {
            //transform.position = Player.transform.position + offsetp;
            //camera.orthographicSize = 2.63f;
            if (count == 0)
            {
                StartCoroutine(MoveCameraSmoothly(Player.transform.position , 3.2f, 0.7f));
                count++;
            }

            transform.position = Player.transform.position + new Vector3(0f, 0f, -10f);

            //spaceShipScript.count2 = 0;

        }

    }

    public IEnumerator MoveCameraSmoothly(Vector3 targetPosition, float targetSize, float duration)
    {
        Vector3 startPosition = transform.position;
        float startSize = camera.orthographicSize;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, Player.transform.position, elapsedTime / duration)+ new Vector3(0f, 0f, -10f);
            camera.orthographicSize = Mathf.Lerp(startSize, targetSize, elapsedTime / duration);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = Player.transform.position + new Vector3(0f,0f,-10f);
        camera.orthographicSize = targetSize;
    }

}
