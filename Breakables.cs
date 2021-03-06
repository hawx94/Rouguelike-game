using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{
    public GameObject[] brokenPiece;
    public int maxPieces = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(PlayerControler.instance.dashCounter > 0)
            {
                Destroy(gameObject);

                int piecesToDrop = Random.Range(1, maxPieces);

                for(int i = 0; i < piecesToDrop; i++)
                {
                    int randomPiece = Random.Range(0, brokenPiece.Length);
                    Instantiate(brokenPiece[randomPiece], transform.position, transform.rotation);
                }
                
            }
            
        }
    }
}
