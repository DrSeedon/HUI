using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moving : MonoBehaviour
{
    
    public Rigidbody2D rb; 
    public SpriteRenderer sprite;
    public float speed = 1;
    public Transform who; // down and right
    public Transform who2; // up and left
    public bool xTransform = true;
    public bool LeftMove = true;
    public bool DownMove = true;
    Vector2 position;

    float angle = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
       

    }

    
    void Update()
    {
        
    }

    void FixedUpdate(){
      angle += 0.1f;
            var x = who.position.x;
            var y = who.position.y;

        //rb.MovePosition(new Vector3(Mathf.Sin(Time.time) * 5, 0, 0));
        

            if(xTransform){
                    if(LeftMove){
                        if(transform.position.x <= who2.position.x + 0.1){
                            LeftMove = false;
                        }   
                        rb.MovePosition(new Vector2(transform.position.x + speed * -1, y));
                    }else{
                        if(transform.position.x >= who.position.x + 0.1){
                            LeftMove = true;
                        }
                        rb.MovePosition(new Vector2(transform.position.x + speed * 1, y));
                    }
            }else{
                    if(DownMove){
                        if(transform.position.y <= who.position.y + 0.1){
                            DownMove = false;
                        }
                        rb.MovePosition(new Vector2(x, transform.position.y + speed * -1));  
                    }else{
                        if(transform.position.y >= who2.position.y + 0.1){
                            DownMove = true;
                        }
                        rb.MovePosition(new Vector2(x, transform.position.y + speed * 1)); 
                    }
                
                    
            }
                                
      
    }


}
