using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public AudioClip Music1;
    public AudioClip Music2Loop;
    public AudioClip Music3;
    public AudioClip Music3Loop;
    public AudioClip Music4;
    public AudioClip Music4Loop;
    public AudioClip Music5Loop;
    public AudioClip Music5;
    

    public bool Music2LoopBool = true;
    public bool Music3LoopBool = true;
    public bool Music4LoopBool = true;
    public bool Music3Bool = true;
    public bool Music4Bool = true;
    public bool Music5LoopBool = true;
    public bool Music5Bool = true;
    public AudioSource audioSource;

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

    IEnumerator Music(){
        while (true)
        {
            
                yield return new WaitForSeconds(0.01f);
                if(!audioSource.isPlaying){

                    if(Music2LoopBool){
                        audioSource.clip = Music2Loop;
                        audioSource.Play();
                    }

                    if(Main.BossHealth <= 666){

                        if(Music3Bool){
                            audioSource.clip = Music3;
                            audioSource.Play();
                            Music3Bool = false;
                        }
                        Music2LoopBool = false;

                        if(!audioSource.isPlaying){

                            if(Music3LoopBool){
                                audioSource.clip = Music3Loop;
                                audioSource.Play();
                            }

                            if(Main.BossHealth <= 333){

                                if(Music4Bool){
                                    audioSource.clip = Music4;
                                    audioSource.Play();
                                    Music4Bool = false;
                                }
                                Music3LoopBool = false;

                                if(!audioSource.isPlaying){

                                    if(Music4LoopBool){
                                        audioSource.clip = Music4Loop;
                                        audioSource.Play();
                                    }
                                    
                                    if(Main.BossHealth <= 100){

                                        Music4LoopBool = false;
                                        
                                        if(!audioSource.isPlaying){

                                            if(Music5LoopBool){
                                                audioSource.clip = Music5Loop;
                                                audioSource.Play();
                                            }                                            
                                        
                                            if(Main.BossHealth <= 0){

                                                if(Music5Bool){
                                                    audioSource.clip = Music5;
                                                    audioSource.Play(); 
                                                    Music5Bool = false;
                                                }
                                                Music5LoopBool = false;
                                                
                                                if(!audioSource.isPlaying){ 
                                                }

                                            }
                                        }
                                    }      
                                }
                            }
                        }
                    }
                }
            
            
        }

    }
}