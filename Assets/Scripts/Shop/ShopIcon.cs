using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopIcon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Test() {

      while (true) {  

        for(int i = 0; i < 10; i++){
            transform.Translate(transform.right * 1  * Time.fixedDeltaTime); 
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.5f);  

        for(int i = 0; i < 10; i++){
            transform.Translate(transform.right * -1  * Time.fixedDeltaTime); 
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.5f);

      }


    }
}
