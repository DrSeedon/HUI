using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarEndScene : MonoBehaviour
{


    public GameObject Panel;
    public bool IsEnd = false;
    public Image PanelImage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Ending");
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D trigger){

        if(trigger.gameObject.tag == "Player"){
          
            IsEnd = true;
            Panel.SetActive(true);
        }

    }


    IEnumerator Ending(){
        while(true){

            if(IsEnd){

                var color = PanelImage.color;

                for (float i = 0; i <= 1; i += 0.01f) {

                    color.a = i;

                    PanelImage.color = color;
                    yield return null;
                }
                IsEnd = false;
                yield return new WaitForSeconds(2f);
                GameObject.Find("Exit").SendMessage("OpenNewScene");
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
