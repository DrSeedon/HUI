using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OutLevel(){

         SceneManager.LoadScene("Menu");    
    

    }

    public void InLevel(){

         SceneManager.LoadScene("Test");    
         Main.Time = 0;

    }
}
