using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarEnter : MonoBehaviour
{


    public GameObject ButtonEnter;
    public GameObject Player;
    public GameObject Car;
    public Transform InCar;
    public Transform OutCar;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D trigger){
        if(trigger.gameObject.tag == "Player"){
          
            ButtonEnter.gameObject.SetActive(true);

        }
    }

    void OnTriggerExit2D(Collider2D trigger){
        if(trigger.gameObject.tag == "Player"){
            if(!Main.InCar){
                
                ButtonEnter.gameObject.SetActive(false);
            }
        }
    }


    public void PressCar(){

        var CameraMan = Camera.GetComponent<CameraMan>();

        if(!Main.InCar){
            
            Player.transform.position = InCar.position; 
            Main.InCar = true;
            CameraMan.player = Car.transform;
            CameraMan.IsFreeze = true;
            CameraMan.faceLeft = false;
        }else{
            
            Player.transform.position = OutCar.position; 
            Main.InCar = false;
            CameraMan.player = Player.transform;
            CameraMan.IsFreeze = false;
        }


    }

    
}
