using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class player : MonoBehaviour {
  // int notMoveTime=0;
  private Inventory inventory; //Inventory腳本
  float speed=5f;
  bool not_Move_Up=false,
  not_Move_Down=false,
  not_Move_Right=false,
  not_Move_Left=false;
  public bool not_move;
  RaycastHit2D[] hits;
  public GameObject foot;
  public bool AllowClick;
  public bool ShowUI;
  GameObject scriptsystem;
  public Animator playerAni;
  // public Sprite F,B,L,R;
  char moveDir;
  public bool lead_away=false;
  public bool isGoTo3_1=false;
  public static player dontDestroyUI {
    get;
    set;
  }
  //第二關用到的變數
  bool level2_autoTalk=false;
  Vector3 level2_tmpPos;
  public Vector3 level2_goalPos;
  GameObject progressBar;
  //隱形
  private SpriteRenderer InvisiblePlayer;
  public bool isInvisible=false;
  private Color invisibleColor;
  public Image bar;
  //3-2
  public bool autoTalkToWanta;
  public Vector3[] level3_1Pos;
  public GameObject knifeGo;
  private int keyDownknifeGo=0;
  public string sceneName;
  public string keyName;
  public bool isGameOver;
  public bool isLight=false;
  private void Awake() {
    scriptsystem=GameObject.Find("ScriptSystem");
    progressBar=GameObject.Find("CanvasProgress");
    DontDestroyOnLoad(this.gameObject);

    if (dontDestroyUI==null) {
      dontDestroyUI=this;
    }

    else {
      Destroy(this.gameObject);
    }

  }

  // Start is called before the first frame update
  void Start() {
    AllowClick=false;
    ShowUI=false;
    inventory=GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); //找Inventory腳本下的變數
    inventory.doorName="";
    InvisiblePlayer=GetComponent<SpriteRenderer>();
    isInvisible=false;
    invisibleColor=InvisiblePlayer.color;
    bar=GameObject.Find("bar").GetComponent<Image>();
  }

  public void NotIdol() {
    // if(moveDir==' '){
    playerAni.SetBool("B", false);
    playerAni.SetBool("F", false);
    playerAni.SetBool("R", false);
    playerAni.SetBool("L", false);
    // }
    // Debug.Log("notIdol");
  }

  public void NotMove() {
    playerAni.SetBool("back", false);
    playerAni.SetBool("foward", false);
    playerAni.SetBool("right", false);
    playerAni.SetBool("left", false);
  }

  private void FixedUpdate() {
    if(sceneName=="Level_3_forest"&&!isLight){
      transform.GetChild(1).GetComponent<Light2D>().enabled=true;
      isLight=true;
    }

    // Debug.Log(not_move);
    if (Input.GetKey(KeyCode.W) && !not_Move_Up && !not_move) {
      not_Move_Down=not_Move_Left=not_Move_Right=false;
      transform.Translate(Vector3.up * Time.deltaTime * speed);
      NotIdol();

      if (moveDir !='b') {
        NotMove();
        moveDir='b';
      }

      playerAni.SetBool("back", true);
      determine();
    }

    else if (Input.GetKey(KeyCode.S) && !not_Move_Down && !not_move) {
      not_Move_Up=not_Move_Left=not_Move_Right=false;
      transform.Translate(Vector3.down * Time.deltaTime * speed);
      NotIdol();

      if (moveDir !='f') {
        NotMove();
        moveDir='f';
      }

      playerAni.SetBool("foward", true);
      determine();
    }

    else if (Input.GetKey(KeyCode.D) && !not_Move_Right && !not_move) {
      not_Move_Down=not_Move_Left=not_Move_Up=false;
      transform.Translate(Vector3.right * Time.deltaTime * speed);

      if (moveDir !='r') {
        NotIdol();
        NotMove();
        moveDir='r';
      }

      playerAni.SetBool("right", true);
      determine();
    }

    else if (Input.GetKey(KeyCode.A) && !not_Move_Left && !not_move) {
      not_Move_Down=not_Move_Up=not_Move_Right=false;
      transform.Translate(Vector3.left * Time.deltaTime * speed);

      if (moveDir !='l') {
        NotIdol();
        NotMove();
        moveDir='l';
      }

      playerAni.SetBool("left", true);
      determine();
    }

    else if (moveDir !=' ') {
      NotMove();
      switch (moveDir) {
        case 'b':
          playerAni.SetBool("B", true);
        break;
        case 'f':
          playerAni.SetBool("F", true);
        break;
        case 'l':
          playerAni.SetBool("L", true);
        break;
        case 'r':
          playerAni.SetBool("R", true);
        break;
      }

      moveDir=' ';
    }

    if (level2_autoTalk) {
      transform.position=Vector3.MoveTowards(transform.position, level2_tmpPos, Time.deltaTime * 5f);

      if (transform.position==level2_tmpPos && transform.position !=level2_goalPos) {
        playerAni.SetBool("right", false);
        playerAni.SetBool("R", false);
        playerAni.SetBool("back", true);
        level2_tmpPos=level2_goalPos;
      }

      else if (transform.position==level2_tmpPos && transform.position==level2_goalPos) {
        level2_autoTalk=false;
        playerAni.SetBool("back", false);
        playerAni.SetBool("B", true);
        GameObject.Find("flower").GetComponent<clickNPC>().AutoTalk();
      }
    }

    else if (autoTalkToWanta) {
      playerAni.SetBool("F",false);
      transform.position=Vector3.MoveTowards(transform.position, level3_1Pos[0], Time.deltaTime * 3f);
      if (transform.position==level3_1Pos[0] && transform.position !=level3_1Pos[1]) {
        playerAni.SetBool("foward",false);
        playerAni.SetBool("right",true);
        level3_1Pos[0]=level3_1Pos[1];
      }

      else if (transform.position==level3_1Pos[0] && transform.position==level3_1Pos[1]) {
        GameObject.Find("dialog").GetComponent<dialogue>().level3_1();
        playerAni.SetBool("B", true);
        moveDir='b';
        autoTalkToWanta=false;
      }
    }

    if (isfixedPos) {
      transform.position=Vector3.MoveTowards(transform.position, fixedPos, Time.deltaTime * 2f);

      if (transform.position==fixedPos) {
        isfixedPos=false;
        Destroy(GameObject.Find("autoWalkbridge"));
        fixedPos=new Vector3(27.3f, 18.45f, 0);
        autoWalkToBridge=true;
      }
    }

    else if (autoWalkToBridge) {
      transform.position=Vector3.MoveTowards(transform.position, fixedPos, Time.deltaTime * 2f);
      if (transform.position==fixedPos) {
        SceneManager.LoadScene("GameOver");
        autoWalkToBridge=false;
        inventory.lastScene="";
        not_move=false;
        playerAni.SetBool("incline", false);
        NotMove();
        playerAni.SetBool("F", true);
        inventory.isClickWood=false;
        inventory.countClickWood=0;
        GameObject.Find("artisan").GetComponent<clickNPC>().woodnum=0;
      }
    }

    if (autoWalkToLevel2) {
      transform.position=Vector3.MoveTowards(transform.position, fixedPos, Time.deltaTime * 2f);
      playerAni.SetBool("foward", true);
      if (transform.position==fixedPos) {
        GameObject.Find("dialog").GetComponent<dialogue>().transtionScene();
        playerAni.SetBool("foward", false);
        playerAni.SetBool("F", true);
        not_move=false;
        transform.position=new Vector3(-29f,-17.5f,0);
        autoWalkToLevel2=false;
        Destroy(GameObject.Find("solider"));
      }
    }

    else if (autoTalkToFake) {
      transform.position=Vector3.MoveTowards(transform.position, fixedPos, Time.deltaTime * 3f);
      playerAni.SetBool("left", true);

      if (transform.position==fixedPos) {
        autoTalkToFake=false;
        playerAni.SetBool("left", false);
        playerAni.SetBool("L", true);
        GameObject.Find("dialog").GetComponent<dialogue>().level3();
      }
    }

    if (Input.GetKey(KeyCode.R)) {
      isInvisible=true;
    }

    else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) {
      isInvisible=false;
    }

    else if (Input.GetKeyDown("j") && keyDownknifeGo==0) {
      print("get inventory");

      for (int i=0; i < inventory.slot.Length; i++) {

        //拿到knife
        //判斷那個格子裡面有沒有東西
        if (inventory.isFull[i]==false) {
          Instantiate(knifeGo, inventory.slot[i].transform, false); //把prefab的圖片放進去slot裡面
          inventory.isFull[i]=true;
          break;
        }
      }

      keyDownknifeGo=1;
    }

    if (isInvisible) {
      invisibleColor.a=0.2f;
      InvisiblePlayer.color=invisibleColor;
      bar.fillAmount -=Time.deltaTime / 8;

      if (bar.fillAmount==0) {
        isInvisible=false;
      }
    }

    else {
      invisibleColor.a=1;
      InvisiblePlayer.color=invisibleColor;
      bar.fillAmount+=Time.deltaTime / 10;
    }

  }

  bool isfixedPos=false;
  public bool autoWalkToBridge=false;
  bool autoWalkToLevel2=false;
  bool autoTalkToFake=false;
  Vector3 fixedPos;

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.transform.tag=="wall") {
      determine();
    }

    else if (other.transform.name=="secret-door") {
      //第二關的秘密們
      SceneManager.LoadScene("Level_1_1_princess");
      inventory.lastScene="castle";
    }

    else if (other.transform.name=="Tsecret_door"&& inventory.lastScene=="castle") {
      //第一關的秘密門
      SceneManager.LoadScene("Level_1_3_castle");
      inventory.lastScene="princess";

    }

    if (other.transform.name=="beginAutoTalk") {
      not_move=true;
      NotIdol();
      NotMove();
      moveDir=' ';
      playerAni.SetBool("right", true);
      level2_autoTalk=true;
      level2_tmpPos=new Vector3(level2_goalPos.x, transform.position.y, 0);
      Destroy(other.gameObject);
    }

    else if (other.transform.name=="autoWalkbridge") {
      isfixedPos=true;
      fixedPos=other.transform.position;
      not_move=true;
      NotIdol();
      NotMove();
      moveDir=' ';
      playerAni.SetBool("incline", true);
    }

    else if (other.transform.name=="autoToLevel2") {
      fixedPos=new Vector3(transform.position.x, -14.4f, 0);
      autoWalkToLevel2=true;
      not_move=true;
      inventory.lastScene="castle";
    }

    else if (other.transform.name=="AllowClick"&&sceneName=="Level_3_1_cellar") {
      autoTalkToWanta=true;
    }

    else if (other.transform.name=="autoTalkFake") {
      fixedPos=new Vector3(-17, 3f, 0);
      autoTalkToFake=true;
      not_move=true;
    }
  }

  private void OnTriggerStay2D(Collider2D other) {
    if (other.transform.tag=="AllowTrigger"&& !ShowUI) {
      AllowClick=true;

      if (other.transform.name[0]=='w'|| other.transform.name[0]=='r') {
        inventory.doorName=other.transform.name;
      }
    }

    //疊兩層無法點擊
    if (other.transform.name=="queen") {
      AllowClick=true;
    }
  }

  private void OnTriggerExit2D(Collider2D other) {
    AllowClick=false;
    inventory.doorName="";
  }

  void determine() {
    Vector3 tmp=Camera.main.WorldToScreenPoint(foot.transform.position);
    Ray ray=Camera.main.ScreenPointToRay(tmp);
    hits=Physics2D.RaycastAll(ray.origin, Vector2.up, 0.1f, 1 << 6);

    if (hits.Length > 0) {
      not_Move_Up=true;
    }

    hits=Physics2D.RaycastAll(ray.origin, Vector2.down, 0.1f, 1 << 6);

    if (hits.Length > 0) {
      not_Move_Down=true;
    }

    hits=Physics2D.RaycastAll(ray.origin, Vector2.right, 0.1f, 1 << 6);

    if (hits.Length > 0) {
      not_Move_Right=true;
    }

    hits=Physics2D.RaycastAll(ray.origin, Vector2.left, 0.1f, 1 << 6);

    if (hits.Length > 0) {
      not_Move_Left=true;
    }
  }
}