using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{

  public float speed = 1500f;
  public float rotationSpeed = 15f;

  public WheelJoint2D backWheel;
  public WheelJoint2D frontWheel;

  public Rigidbody2D rb;

  private float movement = 0f;
  private float rotation = 0f;


  void Start(){
    Main.InCar = false;
  }

  void Update()
  {

    if (Main.Move == 1)
    {
      movement = -1 * speed;
    }
    else if (Main.Move == -1)
    {
      movement = speed;
    }
    else
    {
      movement = 0;
    }

    rotation = Input.GetAxisRaw("Vertical");

  }

  void FixedUpdate()
  {
    if (Main.InCar)
    {

      if (movement == 0f)
      {
        backWheel.useMotor = false;
        frontWheel.useMotor = false;
      }
      else
      {
        backWheel.useMotor = true;
        frontWheel.useMotor = true;

        JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000 };
        backWheel.motor = motor;
        frontWheel.motor = motor;
      }

      rb.AddTorque(-rotation * rotationSpeed * Time.fixedDeltaTime);

    }else{
			  backWheel.useMotor = true;
        frontWheel.useMotor = true;

        JointMotor2D motor = new JointMotor2D { motorSpeed = 0, maxMotorTorque = 10000 };
        backWheel.motor = motor;
        frontWheel.motor = motor;
		}

  }

}
