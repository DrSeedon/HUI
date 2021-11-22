using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopEnter : MonoBehaviour
{
    
    public int EnterShop = 0;
    public GameObject Camera;
    public float x;
    public float y;
    public GameObject UI;
    public GameObject ShopUI;
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine("Test");
         StartCoroutine("Test2");        
    }

    // Update is called once per frame
    void Update()
    {
         x = Camera.transform.position.x;
         y = Camera.transform.position.y;
    }

    void OnTriggerEnter2D(Collider2D trigger){

        if(trigger.gameObject.tag == "Player"){
           
            if(EnterShop == 0){
                EnterShop = 1;
                ShopActive();
            }
               
                
           
        }
    }


    IEnumerator Test() {

        while(true){

            
                if(EnterShop == 1){
                    for( ; x > -56; x-=0.5f){
                        Camera.transform.position = new Vector3(x, y, -10);
                        yield return new WaitForSeconds(0.0005f);
                    }
                    EnterShop = 0;
                }else if(EnterShop == 2){
                    for( ; x < -15.5; x += 0.5f){
                        Camera.transform.position = new Vector3(x, y, -10);
                        yield return new WaitForSeconds(0.0005f);
                    }
                    EnterShop = 0;
                }
            yield return new WaitForSeconds(0.1f);
        }        
    }

    IEnumerator Test2() {

        while(true){

                if(EnterShop == 1){
                    for( ; y > -37; y-=0.5f){
                        Camera.transform.position = new Vector3(x, y, -10);
                        yield return new WaitForSeconds(0.0005f);
                    }
                    EnterShop = 0;
                }else if(EnterShop == 2){
                    for( ; y < 0; y += 0.5f){
                        Camera.transform.position = new Vector3(x, y, -10);
                        yield return new WaitForSeconds(0.0005f);
                    }
                    EnterShop = 0;
                } 
            yield return new WaitForSeconds(0.1f);
        }        
    }

    public void ShopActive(){
        UI.SetActive(false);
        ShopUI.SetActive(true);
    }

    public void ShopDisable(){
        UI.SetActive(true);
        ShopUI.SetActive(false);
        EnterShop = 2;
    }
}
