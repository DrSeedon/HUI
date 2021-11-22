using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRotation : MonoBehaviour
{
    
    public float speed;
    public Rigidbody2D rb2D;
    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {
        rb2D.MoveRotation(rb2D.rotation + speed * Time.fixedDeltaTime);
    }
}
