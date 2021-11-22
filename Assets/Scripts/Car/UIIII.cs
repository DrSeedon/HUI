using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIII : MonoBehaviour
{


    public AudioSource Audio;
    public bool IsPlayed = false;
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
          
            if(!IsPlayed){                    
                Audio.Play();
                IsPlayed = true;
            }

        }

    }
}
