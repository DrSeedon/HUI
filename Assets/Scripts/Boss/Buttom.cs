using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttom : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public SpriteRenderer render;
    public bool click;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(click){
            render.sprite = sprite2;
        }else{
            render.sprite = sprite1;
        }
    }

    void OnCollisionEnter2D(Collision2D hit){
        click = true;
        gameObject.transform.parent.gameObject.SendMessage("Fire");
        
    }

    void OnCollisionExit2D(Collision2D hit){
        click = false;
    }

}
