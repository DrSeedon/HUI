using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    

    public GameObject[] PointsText;
    public int point0 = 0;
    public int point1 = 0;



    private Vector2 direction;

   

    private void RespawnBall()
    {

        transform.position = Vector3.zero;
        var x = Random.Range(0.3f, 0.7f); 
        var y = Mathf.Sqrt(1 - x * x); 
        direction = new Vector2(x, y);
        transform.position = direction;
    }
    // Start is called before the first frame update
    void Start()
    {
        RespawnBall();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "StartPoint")
        {
            RespawnBall();
            point0++;
            PointsText[0].gameObject.GetComponent<Text>().text = point0.ToString();
        }

        if (collision.gameObject.name == "StartPoint2")
        {
            RespawnBall();
            point1++;
            PointsText[1].gameObject.GetComponent<Text>().text = point1.ToString();
        }
    }

    
}
