using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{

    public GameObject Panel;
    public bool IsBegin = false;
    public Image PanelImage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Ending");
        Invoke("Starting", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void Starting(){

        IsBegin = true;
        

    }

    IEnumerator Ending(){
        while(true){

            if(IsBegin){
                var color = PanelImage.color;

                color.a = 1;
                for (float i = 1; i >= 0; i -= 0.01f) {

                    color.a = i;

                    PanelImage.color = color;
                    yield return null;
                }
                IsBegin = false;
                Panel.SetActive(false);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
