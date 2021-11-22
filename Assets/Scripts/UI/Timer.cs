using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Lean.Localization;

public class Timer : MonoBehaviour
{
    
    public Text Timer2;
    public GameObject Timer3;
    public GameObject Toggle;
    public bool TimerVisible;

    public LeanToken Token;
    public bool IsMain = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RunTimer", 0, 0.01f);


        if(Main.TimerVisible){

                Timer3.SetActive(true);
            if(SceneManager.GetActiveScene().name == SceneManager.GetSceneByName("Menu").name)
                Toggle.GetComponent<Toggle>().isOn = true;

        }else{

                Timer3.SetActive(false);
            if(SceneManager.GetActiveScene().name == SceneManager.GetSceneByName("Menu").name)
                Toggle.GetComponent<Toggle>().isOn = false;
                
        }

        TimerVisible = Main.TimerVisible;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void RunTimer() {
    
        if(Timer2)
        {
            Main.Time += 0.01f;
            System.Math.Round(Main.Time,2);
            float res = ((int)(Main.Time * 100)) / 100f;
            Timer2.text = "Timer: " + res.ToString();
            if (IsMain == false)
            {
                Token.Value = res.ToString();
            }
        }
        
        

	}

    public void TimerVisiblility(){
        if(TimerVisible){
            Main.TimerVisible = false;
            Timer3.SetActive(false);
        }else{
            Main.TimerVisible = true;
            Timer3.SetActive(true);
        }


    }

     
    
}
