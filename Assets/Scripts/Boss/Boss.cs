using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    public GameObject BossObj;
    public Rigidbody2D BossRb;
    public Transform Player;
    public Slider BossHealthBar;
    public Slider PlayerHealthBar;
    public int BossHealth;
    public Text textBoss;
    public Text textPlayer;
    public float BossSpeed = 3f;
    public float BossSpeedRepos = 5f;
    public GameObject Wild;
    public List<Transform> spawnPoints = new List<Transform>();
    public GameObject Ball;
    public GameObject Coinrb;
    public GameObject Exit;
    public Transform ExitPos;
    public Rigidbody2D Mace;
    public Transform Polaroid;

    public GameObject ColorLevel;
    public Color32 ColorStage2;
    public Color32 ColorStage3;

    public AudioClip[] Sound;
    /*
    0 - cookie
    1 - ded
    2 - lazer
    3 - lazer2
    4 - scream
    */
    public SpriteRenderer BossSprite;
    public Sprite[] Sprites;
    /*
    0 - full hp
    1 - medium hp
    2 - low hp
    3 - jump
    4 - laser
    5 - scream 
    6 - ded
    
    */

    public Transform PositionRU;
    public Transform PositionRM;
    public Transform PositionRD;
    public Transform PositionLU;
    public Transform PositionLM;
    public Transform PositionLD;
    public Transform PositionRDown;
    public Transform PositionLDown;

    public bool BossAwake = true;
    public bool BossStage1 = false;
    public bool BossStage2 = false;
    public bool BossStage3 = false;
    public bool BossFinal = false;

    public bool RightSide = true;
    public bool BossMovingBool = false;
    public bool BossLaser = false;
    public bool BossScream = false;
    public bool BossColored = false;

    public int RandomPos2;

    public AudioSource Audio;

    public GameObject[] DestroyingGun;
    public int DestroyGunCount = 0;

    public Transform DestroyIsland1;
    public Transform DestroyIsland2;
    public bool DestroingIsland1 = false;
    public bool DestroingIsland2 = false;
    public bool DestroingIsland = false;


    public GameObject[] Pieces;
    public Transform[] PiecesPos;

    public Transform LaserGun;
    public GameObject Laser;
    // Start is called before the first frame update
    void Start()
    {
        Main.PlayerHealth = 200;
        BossRb = GetComponent<Rigidbody2D>();
        BossSprite = GetComponent<SpriteRenderer>();
        //BossHealthBar.value = Main.BossHealth;
        BossHealthBar.gameObject.SetActive(false);
        PlayerHealthBar.gameObject.SetActive(false);
        textBoss.gameObject.SetActive(false);
        textPlayer.gameObject.SetActive(false);
        StartCoroutine("BossAI");
        StartCoroutine("BossMoving");
        StartCoroutine("BossMovingIsland");
        StartCoroutine("BossSpriting");
        StartCoroutine("BossScreaming");
        StartCoroutine("BossSpawningBall");
        StartCoroutine("BossDestroyGun");
        StartCoroutine("BossLasering");
        StartCoroutine("BossColoring");
        StartCoroutine("BossEnd");

        BossObj.transform.position = new Vector2(PositionRDown.position.x, PositionRDown.position.y);

    }

    // Update is called once per frame
    void Update()
    {
            PlayerHealthBar.value = Main.PlayerHealth;
            BossHealth = Main.BossHealth;

            if(!BossAwake){
                BossStage1 = true;
                BossStage2 = false;
                BossStage3 = false;
                BossFinal = false;
            }
             
            if(Main.BossHealth <= 666){
                BossStage1 = false;
                BossStage2 = true;
                BossStage3 = false;
                BossFinal = false;
            }

            if(Main.BossHealth <= 333){
                BossStage1 = false;
                BossStage2 = false;
                BossStage3 = true;
                BossFinal = false;
            }

            if(Main.BossHealth <= 0){
                BossStage1 = false;
                BossStage2 = false;
                BossStage3 = false;
                BossFinal = true;
            }

    }



    void OnTriggerEnter2D(Collider2D hit){

        if(hit.gameObject.tag == "Player"){

            Audio.clip = Sound[0];
            Audio.Play();
            Invoke("Reload",7f);
            GameObject.Find("Player").transform.position = new Vector2(99999f,99999f);
            StopCoroutine("BossScreaming");
            StopCoroutine("BossSpawningBall");
            StopCoroutine("BossDestroyGun");
            StopCoroutine("BossLasering");
            Main.PlayerHealth = 0;
            PlayerHealthBar.value = Main.PlayerHealth;
        }

        if(!(hit.gameObject.tag == "Unbreakable")){
            if(Main.BossHealth <= 222){
                    
                Destroy(hit.gameObject);

            }
        }
        
        

        

    }

    void Reload(){
         GameObject.Find("Player").SendMessage("ReloadLevel");
    }


    public void TakeDamage(int damage)
    {
        
        Main.BossHealth -= damage;
        BossHealthBar.value = Main.BossHealth;
        if(Main.BossHealth <= 0)
        {
            Die();
        }
    }

    void Die(){   
        PlayerHealthBar.gameObject.SetActive(false);
        BossHealthBar.gameObject.SetActive(false);
        textBoss.gameObject.SetActive(false);
        textPlayer.gameObject.SetActive(false);
        StopCoroutine("BossMoving");
        StopCoroutine("BossSpriting");
        StopCoroutine("BossScreaming");
        StopCoroutine("BossSpawningBall");
        StopCoroutine("BossDestroyGun");
        StopCoroutine("BossLasering");

        BossSprite.sprite = Sprites[6];
                Audio.clip = Sound[1];
                Audio.Play();

        BossObj.GetComponent<BoxCollider2D>().enabled = false;
        
        
    }

    IEnumerator BossAI(){        
        while(true)
        {
                
                if(BossAwake){
                    while(Vector3.Distance(transform.position, PositionRM.position) > 0.01f){
                         BossRb.transform.position = Vector3.MoveTowards(BossRb.transform.position, PositionRM.position, Time.deltaTime * BossSpeed);
                         //transform.position = Vector3.Lerp (transform.position, PositionRM.position, BossSpeed * Time.deltaTime);
                         Main.BossHealth = 1000;
                         yield return null;
                    }
                        BossAwake = false;
                        
                        BossHealthBar.gameObject.SetActive(true);
                        PlayerHealthBar.gameObject.SetActive(true);
                        textBoss.gameObject.SetActive(true);
                        textPlayer.gameObject.SetActive(true);
                        Audio.mute = false;
                        //transform.Translate(transform.up * 1 * 0.01f ); 
                        //transform.position = new Vector2(transform.position.x, transform.position.y + 0.05f);
                        //BossRb.MovePosition(new Vector2(transform.position.x, transform.position.x + 0.01f * 1)); 
                        
                }

                

                if(BossStage1){

                   

                    
                }

                if(BossStage2){
                    RightSide = false;
                    BossSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
                    Wild.GetComponent<AreaEffector2D>().forceAngle = 0;
                    //666 333
                    if(Main.BossHealth <= 555){

                    }

                    if(Main.BossHealth <= 444){
                        
                    }
                }

                if(BossStage3){

                    RightSide = true;
                    BossSprite.transform.rotation = Quaternion.Euler(0, 180, 0);
                    Wild.GetComponent<AreaEffector2D>().forceAngle = 180;
                    yield return new WaitForSeconds(5f);    
                    Mace.gravityScale = 1;

                    Vector2 scale = new Vector2(1.118473f, -0.591f);   

                    for (int i = 0; i < 20; i++)
                    {
                      Polaroid.localScale = Vector2.Lerp(Polaroid.localScale, scale, 0.1f);
                      yield return new WaitForSeconds(0.01f);
                    }
                    

                    while(BossStage3){

                        var piece = Instantiate(Pieces[Random.Range(0, Pieces.Length)], PiecesPos[Random.Range(0, PiecesPos.Length)]);
                        

                        piece.AddComponent<Rigidbody2D>().gravityScale = 0.1f;
                        piece.AddComponent<Rotate>();
                        piece.AddComponent<SpriteRenderer>();
                        piece.GetComponent<SpriteRenderer>().sortingOrder = Random.Range(-6,0);

                        Color32 Color;
                        Color = piece.GetComponent<SpriteRenderer>().color;
                        Color.r = 150;
                        Color.b = 150;
                        Color.g = 150;
                        piece.GetComponent<SpriteRenderer>().color = Color;

                        yield return new WaitForSeconds(0.1f);
                    }


                }

                if(BossFinal){
                   
                }

            yield return new WaitForSeconds(0.1f);
        }
    }


    Transform RandomPos(bool side){

        int i;

        do{
            i = Random.Range(1,4);
        }while(RandomPos2 == i);
        
        if(DestroingIsland1){
            while((i == 1) && (RandomPos2 == i)){
                i = Random.Range(2,4);
            }
        }

        if(DestroingIsland2){
            while((i == 3) && (RandomPos2 == i)){
                i = Random.Range(1,3);
            }
        }

        if(DestroingIsland1){
            if(DestroingIsland2){
                while((i == 1) || (i == 3)){
                    i = 2;
                }
            }
        }


        if(side){
            switch (i)
            {
                case 1:
                    return PositionRU;
                case 2:
                    return PositionRM;
                case 3:
                    return PositionRD;
            }
        }else{
            switch (i)
            {
                case 1:
                    return PositionLU;
                case 2:
                    return PositionLM;
                case 3:
                    return PositionLD;
            }
        }

        return null;

    }



    IEnumerator BossMoving(){
        while(true){
            yield return new WaitForSeconds(2f);
        
            if(!DestroingIsland){

                if(!BossAwake){

                    
                    BossMovingBool = true;
                    Transform moveTo = RandomPos(RightSide);
                    while(Vector3.Distance(transform.position, moveTo.position) > 0.01f){

                        //transform.position = Vector3.MoveTowards(transform.position, moveTo.position, Time.deltaTime * BossSpeed);
                        transform.position = Vector3.Lerp (transform.position, moveTo.position, BossSpeed * Time.deltaTime);
                        yield return null;              
                    }
                    BossMovingBool = false;
                }
            }
            
                
            yield return new WaitForSeconds(BossSpeedRepos);
        }
        
    }

    IEnumerator BossMovingIsland(){
        while(true){
            if(Main.BossHealth <= 222){
                if(!(BossMovingBool)){   

                        
                        if(!(DestroingIsland1)){
                            if(Vector3.Distance(transform.position, PositionRU.position) < 0.1f){
                                DestroingIsland = true;
                                while(Vector3.Distance(transform.position, DestroyIsland1.position) > 0.1f){
                                   

                                    transform.position = Vector3.MoveTowards (transform.position, DestroyIsland1.position, BossSpeed * Time.deltaTime);
                                    
                                    yield return null;
                                }

                                while(Vector3.Distance(transform.position, PositionRU.position) > 0.1f){
                                    
                                    
                                    transform.position = Vector3.MoveTowards (transform.position, PositionRU.position, BossSpeed * Time.deltaTime);
                                    yield return null;
                                }
                                DestroingIsland1 = true;
                                DestroingIsland = false;
                            }
                        }

                        if(!(DestroingIsland2)){
                            if(Vector3.Distance(transform.position, PositionRD.position) < 0.1f){
                                DestroingIsland = true;
                                while(Vector3.Distance(transform.position, DestroyIsland2.position) > 0.1f){
                                    

                                    transform.position = Vector3.MoveTowards (transform.position, DestroyIsland2.position, BossSpeed * Time.deltaTime);
                                    
                                    yield return null;
                                }

                                while(Vector3.Distance(transform.position, PositionRD.position) > 0.1f){
                                    
                                    
                                    transform.position = Vector3.MoveTowards (transform.position, PositionRD.position, BossSpeed * Time.deltaTime);
                                    yield return null;
                                }
                                DestroingIsland2 = true;
                                DestroingIsland = false;
                            }
                        }

                    
                }

            }
            
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator BossSpriting(){
        while(true){
            BossSprite.flipX = false;

            if(BossLaser){
                BossSprite.sprite = Sprites[4];
            }else if(BossScream){
                BossSprite.sprite = Sprites[5];
                BossSprite.flipX = true;
            }else if(BossMovingBool){
                BossSprite.sprite = Sprites[3];
            }else if(BossStage1){
                BossSprite.sprite = Sprites[0];
            }else if(BossStage2){
                BossSprite.sprite = Sprites[1];    
            }else if(BossStage3){
                BossSprite.sprite = Sprites[2];
                BossSprite.flipX = true;
            }else if(BossFinal){
                BossSprite.sprite = Sprites[6];
                Audio.clip = Sound[1];
                Audio.Play();
            }

            
            yield return new WaitForSeconds(0.1f);
        }
        
    }

    IEnumerator BossScreaming(){
        while(true){
            if(!BossAwake){
                if(Random.Range(0,2) == 1){
                    BossScream = true;
                    Wild.SetActive(true);
                    Audio.clip = Sound[4];
                    Audio.Play();
                    yield return new WaitForSeconds(1f);
                    Wild.SetActive(false);                        
                    BossScream = false;
                }
            }
            yield return new WaitForSeconds(BossSpeedRepos + 1f);
        }
    }

    IEnumerator BossSpawningBall(){
        while(true){
            if(!BossAwake){

                if (Random.Range(0, 4) == 1)
                {
                    Instantiate(Ball, spawnPoints[Random.Range(0, spawnPoints.Count)]);
                }
                else
                {
                    Instantiate(Coinrb, spawnPoints[Random.Range(0, spawnPoints.Count)]);
                }

                yield return new WaitForSeconds(5f);
                
            }
            yield return new WaitForSeconds(BossSpeedRepos + 1f);
        }
    }

    IEnumerator BossDestroyGun(){

        while(true){
            if(!BossAwake){
                if(BossStage2){

                   yield return new WaitForSeconds(30f);


                    if(!(DestroyGunCount == 2)){

                        GameObject destroy = DestroyingGun[Random.Range(0, DestroyingGun.Length)];

                        var color = destroy.GetComponent<Renderer>().material.color;    

                            for (float i = 1; i >= 0; i-=0.01f) {
                                color.a = i;
                                destroy.GetComponent<Renderer>().material.color = color;
                                yield return null;
                            }

                            yield return new WaitForSeconds(2f);
                            destroy.GetComponent<SpriteRenderer>().enabled = false;

                            Destroy(destroy);  
                        DestroyGunCount++;
                    }
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator BossLasering(){
        while(true){
            if(!BossAwake){
                if(!BossStage1){

                   
                   yield return new WaitForSeconds(10f);
                    BossLaser = true;
                   for (int i = 0; i < 11; i++)
                   {

                                            
                       if(Random.Range(0,2) == 1){
                           Audio.clip = Sound[2];
                           Audio.Play();
                       }else{
                           Audio.clip = Sound[3];
                           Audio.Play();
                       }

                       GameObject laser = Instantiate(Laser);
                       laser.transform.position = new Vector2(LaserGun.position.x, LaserGun.position.y);
                       laser.transform.right = Player.position - laser.transform.position;
                       //laser.transform.LookAt(Player);  
                       

                       yield return new WaitForSeconds(0.5f);
                   }


                   BossLaser = false;                   
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator BossEnd(){

        while(true){
            if(BossFinal){
                if(!BossColored){
                    var color = BossObj.GetComponent<Renderer>().material.color;    

                    for (float i = 1; i >= 0; i-=0.01f) {
                        color.a = i;
                        BossObj.GetComponent<Renderer>().material.color = color;
                        yield return null;
                    }

                    yield return new WaitForSeconds(0.05f);

                    BossColored = true;
                    yield return new WaitForSeconds(2f);
                    BossObj.GetComponent<SpriteRenderer>().enabled = false;
                }

                while(Vector3.Distance(Exit.transform.position, ExitPos.position) > 0.01f){
                         Exit.transform.position = Vector3.Lerp(Exit.transform.position, ExitPos.position, Time.deltaTime * 0.5f);
                        
                         yield return null;
                }
                
            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator BossColoring(){

        while(true){
            Color32 color = ColorLevel.GetComponent<GlobalColor>().Color;  

            if(BossStage2){
                        if(!(color.r == ColorStage2.r)){
                            color.r--;
                        }
                        if(!(color.b == ColorStage2.b)){
                            color.b--;
                        }
                        if(!(color.g == ColorStage2.g)){
                            color.g--;
                        }
                        ColorLevel.GetComponent<GlobalColor>().Color = color;
            }
            if(BossStage3){
                        if(!(color.r == ColorStage3.r)){
                            color.r--;
                        }
                        if(!(color.b == ColorStage3.b)){
                            color.b--;
                        }
                        if(!(color.g == ColorStage3.g)){
                            color.g--;
                        }
                        ColorLevel.GetComponent<GlobalColor>().Color = color;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    

    

    /*
    0 - full hp
    1 - medium hp
    2 - low hp
    3 - jump
    4 - laser
    5 - scream 
    6 - ded
    
    */

    /*
    while (true) {  

        for(int i = 0; i < 10; i++){
            transform.Translate(transform.up * 1  * Time.fixedDeltaTime); 
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.5f);  

        for(int i = 0; i < 10; i++){
            transform.Translate(transform.up * -1  * Time.fixedDeltaTime); 
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.5f);

      }

 -   Выходит из низа 
 -   Музло
 -   хел бар

 -   первая стадия
 -   передвигается по праву 10 32
 -   орет
 -   сверху шары падают

 -   вторая стадия
 -   переход в лево
 -   ломает пушку снизу
 -   орет
 -   лазер - пушка
 -   цвет фона меняется на красноватый

 -   третья стадия
 -   переход в право
 -   ломает все что слева
 -   фон переворачивается
 -   камни  деревья блоки падают сверху
 -   все красное как в аду
 -   кот в ахуе горят глаза
 -   когда хп меньше ломает
 -   2 острова остается 1 только
 -   стреляет из всего что есть
 -   шары теперь глаза убивают медленно падают
 -   когда хп вообще мало музыка репит маленький

 -   деад
 -   все светится кот светится все трясется
 -   музыка эпик 
 -   кот взрывается
 -   дверь медленно вылетает сверху
 -   остров спускается чтоб не задерживались


    
    */
}
