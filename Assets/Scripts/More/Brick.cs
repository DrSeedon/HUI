using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public BoxCollider2D rb; 
    public HingeJoint2D hj; 
    // Start is called before the first frame update
    void Start()
    {        
        rb = GetComponent<BoxCollider2D>();
        hj = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D hit){

        if(hit.gameObject.tag == "Player"){

            Destroy(hj, 1);
            Destroy(rb, 2);

           

        }
         
    }
}
