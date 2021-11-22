using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GlobalColor : MonoBehaviour
{

    public Color32 Color;
    public SpriteRenderer sprite;
    public bool First = false;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        /*
        GameObject[] allObjects = Object.FindObjectsOfType<GameObject>();
        
        foreach (GameObject obj in allObjects)
        {
            SpriteRenderer objectSpriteRenderer = obj.GetComponent<SpriteRenderer>();

            if (objectSpriteRenderer != null && objectSpriteRenderer.color != null)
            {
               objectSpriteRenderer.gameObject.AddComponent<GlobalColor>();
            }
        }
        */
     }

    // Update is called once per frame
    void Update()
    {
        if(First){
            Main.Color = Color;
        }
        
        Color = Main.Color;
        sprite.color = Main.Color;


    }
}
