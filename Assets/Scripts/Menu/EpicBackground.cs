using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EpicBackground : MonoBehaviour
{
    
    public Rigidbody2D rb; 
    public SpriteRenderer sprite;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public float speed = 1;
    public Transform who;
    public Transform who2;
    public bool xTransofrm = true;
    public bool LeftMove = true;
    public bool DownMove = true;
    public bool Teleport = true;
    public bool ToPlayer = false;
    public bool SpeedToSpeed = false;
    public float SpeedToSpeedPower = 15f;
    public bool SpeedToSpeedScale = false;
    

    public Transform Player;    
	private int lastX;

    Vector2 position;

    public float ChangeBackgroundTimer = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        if(SceneManager.GetActiveScene().name == "End"){
            StartCoroutine("ChangeBackground");
        }
        
        StartCoroutine("Speed");
    }

    
    void Update()
    {
        

    }

    void FixedUpdate(){


            var x = who.position.x;
            var y = who.position.y;
        if(!ToPlayer){
            if(xTransofrm){
                if(Teleport){
                    if(LeftMove){
                        if(transform.position.x <= who2.position.x+0.1){
                            transform.position = new Vector2(x,y);
                        }                   
                        transform.Translate(transform.right * -1 * speed * Time.fixedDeltaTime);  
                    }else{
                        if(transform.position.x >= who2.position.x+0.1){
                            transform.position = new Vector2(x,y);
                        }
                        transform.Translate(transform.right * 1 * speed * Time.fixedDeltaTime);  
                    }    
                }else{
                    if(LeftMove){
                        if(transform.position.x <= who2.position.x+0.1){
                            LeftMove = false;
                        }   
                        transform.Translate(transform.right * -1 * speed * Time.fixedDeltaTime);
                    }else{
                        if(transform.position.x >= who.position.x+0.1){
                            LeftMove = true;
                        }
                        transform.Translate(transform.right * 1 * speed * Time.fixedDeltaTime);
                    }
                }
            }else{
                if(Teleport){
                    if(DownMove){
                        if(transform.position.y <= who2.position.y+0.1){
                        transform.position = new Vector2(x,y);
                        }
                        transform.Translate(transform.up * -1 * speed * Time.fixedDeltaTime);  
                    }else{
                        if(transform.position.y >= who2.position.y+0.1){
                            transform.position = new Vector2(x,y);
                        }
                        transform.Translate(transform.up * 1 * speed * Time.fixedDeltaTime);  
                    }
                }else{
                    if(DownMove){
                        if(transform.position.y <= who.position.y+0.1){
                            DownMove = false;
                        }
                        transform.Translate(transform.up * -1 * speed * Time.fixedDeltaTime);  
                    }else{
                        if(transform.position.y >= who2.position.y+0.1){
                            DownMove = true;
                        }
                        transform.Translate(transform.up * 1 * speed * Time.fixedDeltaTime);  
                    }
                }
                    
            }
        }else{

            if(xTransofrm){

                    if(LeftMove){
                        if(transform.position.x <= Player.position.x - 0.2f){
                            LeftMove = false;
                        }   
                        transform.Translate(transform.right * -1 * speed * Time.fixedDeltaTime);
                    }else{
                        if(transform.position.x >= Player.position.x + 0.2f){
                            LeftMove = true;
                        }
                        transform.Translate(transform.right * 1 * speed * Time.fixedDeltaTime);
                    }
                
            }else{

                    if(DownMove){
                        if(transform.position.y <= Player.position.y - 0.2f){
                            DownMove = false;
                        }
                        transform.Translate(transform.up * -1 * speed * Time.fixedDeltaTime);  
                    }else{
                        if(transform.position.y >= Player.position.y + 0.2f){
                            DownMove = true;
                        }
                        transform.Translate(transform.up * 1 * speed * Time.fixedDeltaTime);  
                    }
                
                    
            }
        }                         
      



    }


    IEnumerator ChangeBackground() {

      while (true) {                  

          int rand = Main.RandomBackground;

        while(Main.RandomBackground == rand)
        {
            Main.RandomBackground = Random.Range(1,4);  
        }


        yield return new WaitForSeconds(ChangeBackgroundTimer);

        var color = sprite.material.color;   

        for (float i = 1; i >= -1; i-=0.05f) {

            color.a = i;

            sprite.material.color = color;

            yield return null;

        }

        if(Main.RandomBackground == 1){
            sprite.sprite = sprite1;
        }else if(Main.RandomBackground == 2){
            sprite.sprite = sprite2;
        }else{
            sprite.sprite = sprite3;
        }
        

        
        for (float i = 0; i < 1; i += 0.05f) {

            color.a = i;

            sprite.material.color = color;

            yield return null;

        }


      }

    }


    IEnumerator Speed(){
        while(true){

            if(SpeedToSpeed){     


                var startPoint = transform.position.x;          
                yield return new WaitForSeconds(0.1f);  
                var finishPoint = transform.position.x;

                var dist = finishPoint - startPoint;

                dist /= SpeedToSpeedPower;

                if(Main.Move == 1){

                    speed = Mathf.Lerp(speed, dist, 1);
                    
                }else if(Main.Move == -1){

                    speed = Mathf.Lerp(speed, dist, 1);

                }else{

                    speed = Mathf.Lerp(speed, 0, 1);

                }

                if(SpeedToSpeedScale){
                    Vector3 vec = new Vector3(speed, speed, speed);
                    transform.position.Scale(vec);
                }
            }    

          yield return new WaitForSeconds(0.1f);
 
        }
    }

}
/*
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
*/