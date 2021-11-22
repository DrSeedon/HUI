using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlyText : MonoBehaviour
{

    public TextMeshPro TextPro;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        TextPro = GetComponent<TextMeshPro>();
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine("Starting");
        StartCoroutine("Starting2");
        Invoke("destroyyy", 3f);
    }

    void destroyyy()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Starting()
    {
        while (true)
        {

            for (int i = 0; i < 10; i++)
            {
                this.gameObject.transform.Translate(transform.up * 1 * Time.fixedDeltaTime);
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Starting2()
    {
        
            var color = TextPro.color;
            for (float i = 1; i >= 0; i -= 0.01f)
            {
                color.a = i;
                TextPro.color = color;
                yield return null;
            }


            yield return new WaitForSeconds(0.01f);
        
    }
}
