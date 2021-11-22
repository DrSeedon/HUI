using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    
    public float fallMultiplier = 2.5f;
    public float lowJumpMultilier = 2f;
    
    Rigidbody2D rb;

    void Awake(){
         rb = GetComponent<Rigidbody2D>();
    }

    void Update(){

        if(rb.velocity.y < 0){
            if(rb.velocity.y > -20){
                 rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }else if(rb.velocity.y > 20)
            {
                rb.velocity = new Vector2(0,-20);
            }
        }else if(rb.velocity.y > 0 && Main.PressingJump == false){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultilier - 1) * Time.deltaTime;
        }


    }

}
