using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{

    public Transform SpawnBullet;
    public Transform TankTurret;
    public GameObject Bullet;
    public GameObject TankBoom;
    public bool TankFire = false;
    public Transform TurretPosFire;
    public Transform TurretPos;
    public bool RightPos = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Boom");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(){

    
        if(RightPos){
            Main.BulletRightMove = true;
        }else{
            Main.BulletRightMove = false;
        }

        GameObject bulletCopy = Instantiate(Bullet);
        bulletCopy.transform.position = new Vector2(SpawnBullet.position.x, SpawnBullet.position.y);
        TankFire = true;

        
    }

    IEnumerator Boom(){
        while (true)
        {   
            if(TankFire){
                TankBoom.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                TankFire = false;
                TankTurret.transform.position = new Vector2(TurretPosFire.position.x, TurretPosFire.position.y);
            }else{
                TankBoom.SetActive(false);
                yield return new WaitForSeconds(0.02f);
                TankTurret.transform.position = new Vector2(TurretPos.position.x, TurretPos.position.y);
            }
            yield return new WaitForSeconds(0.1f);
            
        }
    }
}
