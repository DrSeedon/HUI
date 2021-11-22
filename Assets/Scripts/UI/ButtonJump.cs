using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonJump : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    private void Start()
    {
        Main.PressingJump = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {      
        Main.PressingJump = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {      
         Main.PressingJump = false;
    }

    void Update(){

    } 


    
   

}
