using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletCar : MonoBehaviour
{


    public GameObject hitEffect;
    GameObject effect;
    public float bulletDamage = 10f;

    void Start(){
        Destroy(this.gameObject, 10f);
    }
 


    void OnTriggerEnter2D(Collider2D trigger){

        if(trigger.gameObject.tag == "Enemy"){

            Enemy enemy = trigger.gameObject.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.health -= bulletDamage;
            }
            
            effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(gameObject);

        }else if(trigger.gameObject.tag == "Unbreakable"){
            
            Destroy(gameObject);
        }


    }






}
