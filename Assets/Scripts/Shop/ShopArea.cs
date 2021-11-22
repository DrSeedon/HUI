using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopArea : MonoBehaviour
{

    public bool ShopEnter = false;
    public bool Move = false;
    public GameObject Camera;
    void Start()
    {
        StartCoroutine("Test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 

    void OnTriggerEnter2D(Collider2D trigger){

        if(trigger.gameObject.tag == "Player"){
           
            if(!ShopEnter){
                ShopEnter = true;
                Move = true;
            }else{
                ShopEnter = false;
                Move = true;
            }
               
                
           
        }
    }




    IEnumerator Test() {

        while(true){

            if(Move == true){

                if(ShopEnter){

                    for(float i = 0; i > -15.5; i-=0.5f){
                        Camera.transform.position = new Vector3(i, 0, -1);
                        yield return new WaitForSeconds(0.001f);
                    }

                }else{

                    for(float i = -15; i < 0.5; i+=0.5f){
                        Camera.transform.position = new Vector3(i, 0, -1);
                        yield return new WaitForSeconds(0.001f);
                    }

                }
                
                Move = false; 
            }
            yield return new WaitForSeconds(0.1f);
        }        
    }
}
