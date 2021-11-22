using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    public GameObject Item;
    public GameObject Self;
    // Start is called before the first frame update
    void Start()
    {
           StartCoroutine("Test");
           Item = GameObject.Find("Barrier");
           Self = GameObject.FindGameObjectWithTag("Key");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trigger){

        if(trigger.gameObject.tag == "Player"){
           

           Destroy(Self);
           
           Destroy(Item);
           
           
           
            
        
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

}

