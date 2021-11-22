using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D hit)
    {


        if (hit.gameObject.GetComponent<Rigidbody2D>())
        {
            var rb = hit.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * 10f, ForceMode2D.Impulse);
        }

        

    }
}
