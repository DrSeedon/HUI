using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Test2");
    }

    // Update is called once per frame
    void Update()
    {
        
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
