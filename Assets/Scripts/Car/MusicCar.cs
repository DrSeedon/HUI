using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCar : MonoBehaviour
{



    public AudioClip Music1;
    public AudioClip Music1Loop;
    public AudioClip Music2;
    

    public bool Music1LoopBool = true;
    public bool NextMusic = false;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = Music1;
        audioSource.Play();

        StartCoroutine("Music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trigger){

        if(trigger.gameObject.tag == "Player"){
          
           NextMusic = true;

        }
    }

    IEnumerator Music(){
        while (true)
        {
            
                yield return new WaitForSeconds(0.01f);
                if(!audioSource.isPlaying){

                    if(Music1LoopBool){
                        audioSource.clip = Music1Loop;
                        audioSource.Play();
                    }

                    if(NextMusic){
                        audioSource.clip = Music2;
                        audioSource.Play();
                        Music1LoopBool = false;
                        NextMusic = false;
                    }

                        
                }
            
            
        }

    }
}
