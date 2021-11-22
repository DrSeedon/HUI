using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    
    public GameObject bullet;
    public SpriteRenderer sprite;
    public float speed = 300f; 

    public Rigidbody2D rb;

    public int damageBullet = 5;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        bullet = GetComponent<GameObject>();
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine("Flip");
        StartCoroutine("Move");
        Destroy(gameObject, 20);


    }

    // Update is called once per frame
    void Update()
    {
        

    }



    void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player"){

            Main.PlayerHealth -= damageBullet;
            if(Main.PlayerHealth <= 0){
                Reload();
                //GameObject.Find("Player").transform.position = new Vector2(99999f,99999f);
            }
        }
	}

    void Reload(){
         GameObject.Find("Player").SendMessage("ReloadLevel");
    }

    IEnumerator Flip(){

        while(true){
            
            sprite.flipY = false;
            yield return new WaitForSeconds(0.1f);
            sprite.flipY = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Move(){
       
              rb.velocity = transform.right * speed * Time.fixedDeltaTime;
              yield return new WaitForSeconds(0.01f);
       
    }
    

}
