using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border2 : MonoBehaviour
{

    public Transform Player;
    private Vector3 offset; 
    float PrevPos;
    // Start is called before the first frame update
    void Start()
    {
         offset = transform.position - Player.transform.position;
    }
   
    // Update is called once per frame
    void Update()
    {


        if(Player.transform.position.x > PrevPos)
        {
            transform.position = Player.transform.position + offset;
            PrevPos = Player.position.x;
        }
        
        


    }
}
