using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;

    public GameObject[] hats;
    GameObject activeHat;
    public float run;
    public bool Fly = false;

    public Color32 Color;
    public Color32[] ColorSkins;

    public GameObject DeadBody;
    public Color ColorDeadBody;



    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        ReloadHat();
        ColorSkin();

        StartCoroutine("Moving");
        StartCoroutine("Moving2");
    }

    IEnumerator Moving()
    {

        while (true)
        {

            if (Input.GetKey(KeyCode.D))
            {
                Main.Move = 1;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                Main.Move = 0;
            }
            if (Input.GetKey(KeyCode.A))
            {
                Main.Move = -1;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                Main.Move = 0;
            }


            yield return new WaitForSeconds(0.001f);

        }

    }

    IEnumerator Moving2()
    {

        while (true)
        {


            if (Input.GetKey(KeyCode.W))
            {
                Main.PressingJump = true;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                Main.PressingJump = false;
            }


            yield return new WaitForSeconds(0.001f);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GroundLaber")
        {
            Fly = false;
        }
    }


    //Столкновение с хитбоксом
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {

            if (SceneManager.GetActiveScene().name == "Scene9")
            {

                Invoke("ReloadLevel", 4f);
            }
            else
            {
                ReloadLevel();
            }


        }
        if (hit.gameObject.tag == "Ground")
        {
            Fly = false;
        }


    }






    //Поворот
    public void Flip()
    {

        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);


    }

    //Движение
    void FixedUpdate()
    {


        //Джойстик

        if (Main.PressingJump)
            Jump();



        if (Main.Move == 1)
        {

            //Направо
            transform.Translate(transform.right * Main.Move * Main.SpeedPower * Time.fixedDeltaTime);
            anim.SetInteger("Stage", 2);
            sprite.flipX = false;
        }
        else if (Main.Move == -1)
        {

            //Налево
            transform.Translate(transform.right * Main.Move * Main.SpeedPower * Time.fixedDeltaTime);
            anim.SetInteger("Stage", 2);
            sprite.flipX = true;
        }
        else if (Main.Move == 0)
        {

            anim.SetInteger("Stage", 1);

        }




    }

    //Прыжок
    public void Jump()
    {

        if (Fly == false)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * Main.JumpPower, ForceMode2D.Impulse);
            Fly = true;
            anim.SetInteger("Stage", 3);

        }


    }

    public void ReloadLevel()
    {


        Main.Level = 1;
        Main.JumpPower = 11f;
        Main.SpeedPower = 6f;
        Main.Time = 0;
        Main.BoosterJump = false;
        Main.BoosterSpeed = false;
        Main.BoosterCoin = false;


        Transform spawnPos = GetComponent<Transform>();
        Vector3 spawnPos2 = new Vector2(spawnPos.position.x, spawnPos.position.y);



        GameObject deadbody = Instantiate(DeadBody, spawnPos2, Quaternion.identity);
        Rigidbody2D rigidbody = deadbody.GetComponent<Rigidbody2D>();

        deadbody.GetComponent<SpriteRenderer>().color = ColorDeadBody;
        foreach (SpriteRenderer i in deadbody.GetComponentsInChildren<SpriteRenderer>())
        {
            i.color = ColorDeadBody;
        }



        deadbody.GetComponent<Die>().Deading();

        if (Main.Move == 1)
        {

            rigidbody.velocity = new Vector2(10, 0);

        }
        else if (Main.Move == -1)
        {

            rigidbody.velocity = new Vector2(-10, 0);

        }
        else if (Main.Move == 0)
        {

            rigidbody.velocity = rb.velocity;

        }



        Destroy(this.gameObject);

    }



    public void ReloadHat()
    {


        int hatId = PlayerPrefs.GetInt("IdSkins", -1);

        if (hatId == -1)
        {
        }
        else
        {
            for (int i = 0; i < hats.Length; i++)
            {
                activeHat = hats[i];
                activeHat.SetActive(false);
            }
            activeHat = hats[hatId];
            activeHat.SetActive(true);
        }
    }

    public void ColorSkin()
    {
        int hatId = PlayerPrefs.GetInt("IdSkins", -1);
        if (hatId == -1) return;

        this.GetComponent<SpriteRenderer>().color = ColorSkins[hatId];
        ColorDeadBody = ColorSkins[hatId];

    }

    public void RemoveHat()
    {
        PlayerPrefs.SetInt("IdSkins", -1);
        activeHat.SetActive(false);
        this.GetComponent<SpriteRenderer>().color = Color;
    }


}