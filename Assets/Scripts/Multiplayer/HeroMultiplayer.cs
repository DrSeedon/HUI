using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class HeroMultiplayer : MonoBehaviour , IPunObservable
{

    public Rigidbody2D rb;    
    public Animator anim;
    public SpriteRenderer sprite;

    public GameObject[] hats; 
    GameObject activeHat; 
    public float run;
    public bool Fly = false;
    
    public Color32 ColorHero;
    public Color32[] ColorSkins;

    private PhotonView photonView;

    public bool IsFlip = false;

    public TextMeshPro NicknameText;
    public string PlayerName = "Player";

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();


        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        ReloadHat();
        ColorSkin();

        StartCoroutine("Moving");
        StartCoroutine("Moving2");

        NicknameText.SetText(photonView.Owner.NickName);
        PlayerName = photonView.Owner.NickName;
        if (!photonView.IsMine)
        {
            NicknameText.color = Color.green;
        }
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

    IEnumerator  Moving2(){

        while(true){

            
            if(Input.GetKey(KeyCode.W)){
                Main.PressingJump = true;
            }
            if(Input.GetKeyUp(KeyCode.W)){
                Main.PressingJump = false;
            } 
                

            yield return new WaitForSeconds(0.001f);

        }       
       
    }

    // Update is called once per frame
    void Update()
    {
       
                  
        
    }


    //Столкновение с хитбоксом
    void OnCollisionEnter2D(Collision2D hit){
        if(hit.gameObject.tag == "Enemy"){

            if(SceneManager.GetActiveScene().name == "Scene9"){

                Invoke("ReloadLevel",7f);
            }else if(SceneManager.GetActiveScene().name == "Endless"){
                
                Main.BoosterJump = false;
                Main.BoosterSpeed = false;
                Main.BoosterCoin = false;
                PlayerPrefs.SetInt("Coin", Main.Coin);
                SceneManager.LoadScene("End");

            }else{
                ReloadLevel();
            }
           

        }
        if(hit.gameObject.tag == "Platform"){

            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * 10f, ForceMode2D.Impulse);

        }
        if(hit.gameObject.tag == "Ground"){
            Fly = false;
        }

         
    }


    
    

    //Поворот
    public void Flip(){

        if(Input.GetAxis("Horizontal") < 0) 
            transform.localRotation = Quaternion.Euler(0, 180, 0);

         if(Input.GetAxis("Horizontal") > 0) 
            transform.localRotation = Quaternion.Euler(0, 0, 0);


    }

    //Движение
    void FixedUpdate(){

        if (photonView.IsMine)
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
                IsFlip = false;
            }
            else if (Main.Move == -1)
            {

                //Налево
                transform.Translate(transform.right * Main.Move * Main.SpeedPower * Time.fixedDeltaTime);
                anim.SetInteger("Stage", 2);
                sprite.flipX = true;
                IsFlip = true;
            }
            else if (Main.Move == 0)
            {

                anim.SetInteger("Stage", 1);

            }

        }


        if (IsFlip)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

            

        

        
                
           
            
        
    }

    //Прыжок
    public void Jump(){
        
        if(Fly==false){
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * Main.JumpPower, ForceMode2D.Impulse);
            Fly = true;
            anim.SetInteger("Stage", 3);  
        }
        
    
    }

    public void ReloadLevel(){

        
        Main.Level = 1;
        Main.JumpPower = 11f;
        Main.Time = 0;
        Main.BoosterJump = false;
        Main.BoosterSpeed = false;
        Main.BoosterCoin = false;
        SceneManager.LoadScene("Scene1");
        
    }

    public void ReloadHat(){

        int hatId = PlayerPrefs.GetInt("IdSkins", -1);
        
        if(hatId == -1){                
        }else{            
            for (int i = 0; i < hats.Length; i++)
            {
                activeHat = hats[i];
                activeHat.SetActive(false);
            }
            activeHat = hats[hatId];
            activeHat.SetActive(true);
        }
    }

    public void ColorSkin(){
       int hatId = PlayerPrefs.GetInt("IdSkins", -1);

       switch (hatId)
        {
          case 0:
              this.GetComponent<SpriteRenderer>().color = ColorSkins[hatId]; 
              break;
          case 1:
              this.GetComponent<SpriteRenderer>().color = ColorSkins[hatId]; 
             
              break;
          case 2:
              this.GetComponent<SpriteRenderer>().color = ColorSkins[hatId]; 
             
              break;
          case 3:
              this.GetComponent<SpriteRenderer>().color = ColorSkins[hatId]; 
             
              break;
          case 4:
              this.GetComponent<SpriteRenderer>().color = ColorSkins[hatId]; 
             
              break;   
          default:
              
              break;
        }  

    }

    public void RemoveHat(){
        PlayerPrefs.SetInt("IdSkins", -1);
        activeHat.SetActive(false);  
        this.GetComponent<SpriteRenderer>().color = ColorHero;
    }

    [System.Obsolete]
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(IsFlip);
            stream.SendNext(rb.position);
            stream.SendNext(rb.velocity);
        }
        else
        {
            IsFlip = (bool)stream.ReceiveNext();

            rb.position = (Vector3)stream.ReceiveNext();
            rb.velocity = (Vector3)stream.ReceiveNext();

            float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.timestamp));
            rb.position += rb.velocity * lag;
        }
    }
}