 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameObject obj;

    void Start()
    {
        StartCoroutine("Test");
        StartCoroutine("Test2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trigger){

        if(trigger.gameObject.tag == "Player"){
           
           Destroy(obj);           
           
           Main.JumpPower = 15f;           
            
         }


    }

    IEnumerator Test() {

      while (true) {  

        for(int i = 0; i < 10; i++){
            transform.Translate(transform.up * 1  * Time.fixedDeltaTime); 
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.5f);  

        for(int i = 0; i < 10; i++){
            transform.Translate(transform.up * -1  * Time.fixedDeltaTime); 
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.5f);

      }


    }

    IEnumerator Test2() {

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

      }


    }

    

}
