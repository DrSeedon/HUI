using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwarmSpawn : MonoBehaviour
{

    public GameObject SpawningThings;
    public GameObject Spawn;
    public float mass;
    public float speed;
    public float spawnRate = 1f;

    public void Fire()
    {
          Transform spawnPos =  Spawn.GetComponent<Transform>();
          Vector3 spawnPos2 = new Vector2(spawnPos.position.x, spawnPos.position.y);

          GameObject ballCopy = Instantiate(SpawningThings, spawnPos2, Quaternion.identity);
          Rigidbody2D rigidbody = ballCopy.GetComponent<Rigidbody2D>();
          rigidbody.mass = mass;
          rigidbody.velocity = new Vector2(speed, 0);     
      
    }
    

    void Start(){

       StartCoroutine(Test(Fire));
      
    }


    IEnumerator Test(Action act) {

      while (true) {  

        act();
        yield return new WaitForSeconds(spawnRate);
      }


    }

  
    

/* Мигание

while (true) {                   
        var color = obj.GetComponent<Renderer>().material.color;            
        for (float i = 1; i >= 0; i-=0.1f) {
            color.a = i;
            obj.GetComponent<Renderer>().material.color = color;
            yield return null;
        }
        
        yield return new WaitForSeconds(0.5f);

        for (float i = 0; i < 1; i += 0.1f) {
            color.a = i;
            obj.GetComponent<Renderer>().material.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
    

    */

/* НАправление пули


     Instantiate(enemy_bullet,this.transform.position, Quaternion.LookRotation(target.transform.position- this.transform.position));

     */
}
