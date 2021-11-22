using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProdScript : MonoBehaviour
{

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.tag == "Player"){

                Invoke("OpenBox", 0.2f);

        }
        
    }

    public void OpenBox()
    {
        int IDSkin = int.Parse(this.name);

        PlayerPrefs.SetInt("IdSkins", IDSkin);
        GameObject.Find("Player").SendMessage("ReloadHat");
        GameObject.Find("Player").SendMessage("ColorSkin");


    
        

    }
}
