using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    Vector2 lookDir;
    public float angle;
    public bool Flip = false;
    
    public Transform TurretPos;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float fireRate = 0.5f;
    public float bulletDamage = 20f;

    public bool IsShoot = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine("Schooting");
    }

    

    // Update is called once per frame
    void Update()
    {

        if((angle >= 90f) || (angle <= -90f)){
            Flip = true;
           
            sprite.flipY = true;
            var firePointVec = new Vector3(-1.38f, -0.58f, firePoint.transform.position.z);
            firePoint.TransformPoint(firePointVec);
        }else{

            Flip = false;
            
            sprite.flipY = false;
            var firePointVec = new Vector3(-1.38f, 0.58f, firePoint.transform.position.z);
            firePoint.TransformPoint(firePointVec);

        }

        transform.position = TurretPos.position;
        IsShoot = false;

        if((Main.InCar)&&(Main.Move == 0)){

            if(Input.touchCount > 0 ){
                Touch touch = Input.GetTouch(0);
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                

                lookDir = touchPosition - rb.position;
                angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
                rb.rotation = angle;

                Shoot();
                IsShoot = true;

                            
            }

            if(Input.GetButton("Fire1")){
                IsShoot = true;
            }

            Vector2 touchPosition2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                

            lookDir = touchPosition2 - rb.position;
            angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;

        }

    }


    void Shoot()
    {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<BulletCar>().bulletDamage = bulletDamage;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }


    IEnumerator Schooting(){
        while(true){

            if(IsShoot){                
                Shoot();
            }
            
            yield return new WaitForSeconds(fireRate);
        }
    }

}
