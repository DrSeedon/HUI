using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TankBullet : MonoBehaviour
{

    public GameObject explosion;
    public GameObject bullet;
    public SpriteRenderer sprite;
    public float speed = 300f; 

    public Rigidbody2D rb;

    public int damageBullet = 50;

    public bool rightMove = true;
    
    // Start is called before the first frame update
    void Start()
    {

        rightMove = Main.BulletRightMove;
        rb = GetComponent<Rigidbody2D>();
        bullet = GetComponent<GameObject>();
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine("Flip");
        StartCoroutine("Move");
        Destroy(gameObject, 20);

        if(!Main.BulletRightMove){

            sprite.flipX = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnTriggerEnter2D(Collider2D coll)
	{
		
            Boss boss = coll.GetComponent<Boss>();
            if(boss != null)
            {
                boss.TakeDamage(damageBullet);
            }
			Destroy(gameObject);
		
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
        if(Main.BulletRightMove){
            while (true)
            {
              rb.velocity = transform.right * speed * Time.fixedDeltaTime;
              yield return new WaitForSeconds(0.01f);
            }
        }else{
            while (true)
            {
              rb.velocity = transform.right * speed * Time.fixedDeltaTime * -1;
              yield return new WaitForSeconds(0.01f);
            }
        }

    }
    

}
