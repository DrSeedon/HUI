using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public Rigidbody2D rb;
    public GameObject coin;
    public int countCoin;
    
    
    public float health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
           
           
           for (int i = 0; i < countCoin; i++)
           {
               GameObject coinClone = Instantiate(coin);
               coinClone.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
           }
           
           Destroy(this.gameObject);
           
        }
    }
}
