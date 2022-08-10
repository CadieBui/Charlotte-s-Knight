using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Experimental.Rendering.Universal;

public class dialogue : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;//prefab圖
    public GameObject itemButton2;//prefab圖
    private DiaryItem isOpenDiary;
    string[] PlayDialogy;
    string[,] mulDialogy;
    //第幾句//三個變數
    string[,] NPCDialogy;
    public Sprite Queen,Princess,Knight,Narration,King;
    public Sprite flower,artisan,boy,girl,man,woman,older,bird;
    public Sprite unknown,wanta,solider;
    public Sprite fakeKnight,fakeKnight1;
    public Sprite NotHaveName;
    public Image dialogyBorder;
    public Text dialogyText;
    int textLength=0;
    int num_Dialogy=0;
    CanvasGroup CG;
    GameObject player;
    public string level;
    string excelUrl="https://script.google.com/macros/s/AKfycbybj_gdYwyQb-HrxOhk1NgK_IEqIJnpI3WkZBjSXFX59G2SJvNu38qm28q95CniA6Pf/exec";
    private int keydown=0;
    public bool mul=false;
    int talkNum;
    public Sprite[] wood;//prefab圖
    public Sprite knife;
    public Animator BtnAni;
    public bool runoption=false;
    public bool islevel2talk=false;
    public bool isEnd=false;

    public Sprite[] plot3;

    // Start is called before the first frame update
    private void Awake() {
        CG=GameObject.Find("dialog").transform.GetComponent<CanvasGroup>();
        player=GameObject.Find("player");
        if(level=="leading"){
            StartCoroutine(dataLeading());
        }else{
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();//找Inventory腳本下的變數
            isOpenDiary = GameObject.FindGameObjectWithTag("Player").GetComponent<DiaryItem>();
            BtnAni=GameObject.Find("backPackImg").GetComponent<Animator>();

        }

        if(level=="1-1"&&inventory.lastScene=="castle"){
            player.transform.GetComponent<player>().not_move=false;
        }else if(level=="1-1"){
            StartCoroutine(data1_1());
            player.transform.GetComponent<player>().not_move=true;
        }
        if(level=="1-2"){
            StartCoroutine(data1_2());
        }else if(level=="1-3"){
            StartCoroutine(Transtiondata("plot1"));
        }else if(level=="2"){
            mul=true;
            mulDialogy=new string[8,1];
            StartCoroutine(data2());
        }else if(level=="3-1"){
            StartCoroutine(data3_1());
            runoption=true;
        }else if(level=="3"){
            StartCoroutine(data3());
            runoption=true;
            if(player.transform.GetComponent<player>().lead_away){                
                Destroy(GameObject.Find("solider").gameObject);
            }
        }
    }
    private void Update() {
        if (Input.GetKeyDown("b")&&keydown==0){
            // print("get inventory");
            isOpenDiary.queenTalk=true;
                //拿到麵包
                for(int i=0;i<inventory.slot.Length;i++)
                {   
                    //判斷那個格子裡面有沒有東西
                    if(inventory.isFull[i]==false)
                    {   
                        Instantiate(itemButton,inventory.slot[i].transform,false);//把prefab的圖片放進去slot裡面
                        inventory.isFull[i]=true;
                        // Destroy(gameObject);//刪掉object
                        break;  
                    } 
                    else if(inventory.isFull[i]==false)
                    {   
                        BtnAni.SetTrigger("shake");                
                        BtnAni.SetTrigger("idle");
                        GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

                        Instantiate(itemButton,inventory.slot[i].transform,false);//把prefab的圖片放進去slot裡面
                        inventory.isFull[i]=true;
                        break;  
                    } 
                }
            keydown=1;
        }
        if(Input.GetKeyDown(KeyCode.T)){
            End();
        }
        if(Input.GetKeyDown(KeyCode.Y)){
            clickFake();
        }
        if(Input.GetKeyDown(KeyCode.P)){
            for(int i=0;i<inventory.slot.Length;i++)
            {   
                //判斷那個格子裡面有沒有東西
                if(inventory.isFull[i]==false)
                {   
                    Instantiate(itemButton,inventory.slot[i].transform,false);//把prefab的圖片放進去slot裡面
                    inventory.isFull[i]=true;
                    // Destroy(gameObject);//刪掉object
                    break;  
                } 
                else if(inventory.isFull[i]==false)
                {   
                    BtnAni.SetTrigger("shake");                
                    BtnAni.SetTrigger("idle");
                    GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

                    Instantiate(itemButton,inventory.slot[i].transform,false);//把prefab的圖片放進去slot裡面
                    inventory.isFull[i]=true;
                    break;  
                } 
            }
        }
    }
    IEnumerator dataLeading(){
        WWWForm form=new WWWForm();
        form.AddField("method","ReadLeading");
        using (UnityWebRequest www=UnityWebRequest.Post(excelUrl,form)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError||www.result == UnityWebRequest.Result.ProtocolError){
                Debug.Log(www.error);
            }else{
                PlayDialogy = www.downloadHandler.text.Split('_');
                // for(int i=0;i<PlayDialogy.Length;i++){
                //     Debug.Log(PlayDialogy[i]);
                // }
                textLength=PlayDialogy.Length-1;
                CG.alpha=1;
                CG.blocksRaycasts=true;
                CG.interactable=true;
                string[] tmp = PlayDialogy[0].Split('|');
                dialogyBorder.sprite=Narration;
                dialogyText.text=tmp[1];
                if(level=="leading"){
                    dialogyText.GetComponent<typewriter>().words=tmp[1];
                    dialogyText.GetComponent<typewriter>().isPrint=true;
                }
            }
        }
    }
    IEnumerator data1_1(){
        WWWForm form=new WWWForm();
        form.AddField("method","Read1-1");
        using (UnityWebRequest www=UnityWebRequest.Post(excelUrl,form)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError||www.result == UnityWebRequest.Result.ProtocolError){
                Debug.Log(www.error);
            }else{
                PlayDialogy = www.downloadHandler.text.Split('_');
                textLength=PlayDialogy.Length-1;
                CG.alpha=1;
                CG.blocksRaycasts=true;
                CG.interactable=true;
                string[] tmp = PlayDialogy[0].Split('|');
                dialogyBorder.sprite=Princess;
                dialogyText.text=tmp[1];
            }
        }
    }
    IEnumerator data1_2(){
        WWWForm form=new WWWForm();
        form.AddField("method","Read1-2");
        using (UnityWebRequest www=UnityWebRequest.Post(excelUrl,form)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError||www.result == UnityWebRequest.Result.ProtocolError){
                Debug.Log(www.error);
            }else{
                PlayDialogy = www.downloadHandler.text.Split('_');
                textLength=PlayDialogy.Length-1;
                
            }
        }
    }
    IEnumerator data2(){
        WWWForm form=new WWWForm();
        form.AddField("method","Read2-1");
        using (UnityWebRequest www=UnityWebRequest.Post(excelUrl,form)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError||www.result == UnityWebRequest.Result.ProtocolError){
                Debug.Log(www.error);
            }else{
                mulDialogy[0,0] = www.downloadHandler.text;
            }
        }

        WWWForm form1=new WWWForm();
        form1.AddField("method","Read2-1-1");
        using (UnityWebRequest www=UnityWebRequest.Post(excelUrl,form1)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError||www.result == UnityWebRequest.Result.ProtocolError){
                Debug.Log(www.error);
            }else{
                mulDialogy[1,0] = www.downloadHandler.text;
            }
        }

        WWWForm form2=new WWWForm();
        form2.AddField("method","Read2-2");
        using (UnityWebRequest www=UnityWebRequest.Post(excelUrl,form2)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError||www.result == UnityWebRequest.Result.ProtocolError){
                Debug.Log(www.error);
            }else{
                mulDialogy[2,0] = www.downloadHandler.text;
            }
        }

        WWWForm form3=new WWWForm();
        form3.AddField("method","Read2-3");
        using (UnityWebRequest www=UnityWebRequest.Post(excelUrl,form3)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError||www.result == UnityWebRequest.Result.ProtocolError){
                Debug.Log(www.error);
            }else{
                mulDialogy[3,0] = www.downloadHandler.text;
            }
        }

        WWWForm form4=new WWWForm();
        form4.AddField("method","Read2-4");
        using (UnityWebRequest www=UnityWebRequest.Post(excelUrl,form4)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError||www.result == UnityWebRequest.Result.ProtocolError){
                Debug.Log(www.error);
            }else{
                mulDialogy[4,0] = www.downloadHandler.text;
            }
        }

        WWWForm form5=new WWWForm();
        form5.AddField("method","Read2-5");
        using (UnityWebRequest www=UnityWebRequest.Post(excelUrl,form5)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError||www.result == UnityWebRequest.Result.ProtocolError){
                Debug.Log(www.error);
            }else{
                mulDialogy[5,0] = www.downloadHandler.text;
            }
        }

        WWWForm form6=new WWWForm();
        form6.AddField("method","Read2-6");
        using (UnityWebRequest www=UnityWebRequest.Post(excelUrl,form6)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError||www.result == UnityWebRequest.Result.ProtocolError){
                Debug.Log(www.error);
            }else{
                mulDialogy[6,0] = www.downloadHandler.text;
                // Debug.Log(mulDialogy[6,0]);
            }
        }

        WWWForm form7=new WWWForm();
        form7.AddField("method","Read2-7");
        using (UnityWebRequest www=UnityWebRequest.Post(excelUrl,form7)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError||www.result == UnityWebRequest.Result.ProtocolError){
                Debug.Log(www.error);
            }else{
                mulDialogy[7,0] = www.downloadHandler.text;
            }
        }
    }
    IEnumerator data3_1(){
        WWWForm form=new WWWForm();
        form.AddField("method","Read3-1");
        using (UnityWebRequest www=UnityWebRequest.Post(excelUrl,form)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError||www.result == UnityWebRequest.Result.ProtocolError){
                Debug.Log(www.error);
            }else{
                PlayDialogy = www.downloadHandler.text.Split('_');
                textLength=PlayDialogy.Length-1;
            }
        }
    }

    IEnumerator data3(){
        WWWForm form=new WWWForm();
        form.AddField("method","Read3");
        using (UnityWebRequest www=UnityWebRequest.Post(excelUrl,form)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError||www.result == UnityWebRequest.Result.ProtocolError){
                Debug.Log(www.error);
            }else{
                PlayDialogy = www.downloadHandler.text.Split('_');
                textLength=PlayDialogy.Length-1;
            }
        }
    }

    IEnumerator Transtiondata(string scene){
        isEnd=true;
        WWWForm form=new WWWForm();
        form.AddField("method",scene);
        using (UnityWebRequest www=UnityWebRequest.Post(excelUrl,form)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError||www.result == UnityWebRequest.Result.ProtocolError){
                Debug.Log(www.error);
            }else{
                PlayDialogy = www.downloadHandler.text.Split('_');
                textLength=PlayDialogy.Length-1;
                num_Dialogy=0;
                Debug.Log(PlayDialogy[0]);
                string[] tmp = PlayDialogy[0].Split('|');
                dialogyBorder.sprite=NotHaveName;
                dialogyText.text="";
                tmpWord=tmp[2];
                if(level=="2"||level=="3"){
                    transtionScene();
                }
            }
        }
    }
    string tmpWord;

    public void scene2to3(){
        mul=false;
        StartCoroutine(Transtiondata("plot2"));
    }

    public void clickFake(){
        transtionScene();
    }

    public void End(){
        mul=false;
        StartCoroutine(Transtiondata("plot3"));
    }

    public void transtionScene(){
        CG.alpha=1;
        CG.blocksRaycasts=true;
        CG.interactable=true;
        GameObject.Find("dialog").transform.GetChild(2).GetComponent<Image>().enabled=false;
        GameObject.Find("dialog").transform.GetChild(3).GetComponent<Image>().enabled=false;
        GameObject.Find("TScene").GetComponent<CanvasGroup>().alpha=1;
        GameObject.Find("TScene").GetComponent<CanvasGroup>().blocksRaycasts=true;
        GameObject.Find("TScene").GetComponent<CanvasGroup>().interactable=true;
        dialogyText.GetComponent<typewriter>().words=tmpWord;
        dialogyText.GetComponent<typewriter>().isPrint=true;
    }

    public void level1_2(){
        if(player.transform.GetComponent<player>().AllowClick){
            player.transform.GetComponent<player>().not_move=true;
            CG.alpha=1;
            CG.blocksRaycasts=true;
            CG.interactable=true;
            string[] tmp = PlayDialogy[0].Split('|');
            dialogyBorder.sprite=Queen;
            dialogyText.text=tmp[1];
        }
    }

    string[] tmp;
    string NPCName;
    public void level2(string who,int times,int stance_num){
        player.transform.GetComponent<player>().not_move=true;
        talkNum=times;
        NPCName=who;
        switch(who){
            case "flower":
                tmp=mulDialogy[0,0].Split('_');
                break;
            case "bird":
                tmp=mulDialogy[1,0].Split('_');
                break;
            case "older":
                tmp=mulDialogy[2,0].Split('_');
                break;
            case "boy":
                tmp=mulDialogy[3,0].Split('_');
                break;
            case "girl":
                tmp=mulDialogy[4,0].Split('_');
                break;
            case "woman":
                tmp=mulDialogy[5,0].Split('_');
                break;
            case "artisan":
                tmp=mulDialogy[6,0].Split('_');
                break;
            case "man":
                tmp=mulDialogy[7,0].Split('_');
                break;
        }
        NPCDialogy=new string[tmp.Length,3];
        textLength=tmp.Length-1;
        num_Dialogy=stance_num;
        for(int i=0;i<tmp.Length;i++){
            string[] tmp1=tmp[i].Split('|');
            for(int j=0;j<3;j++){
                NPCDialogy[i,j]=tmp1[j];
            }
            give_sprite_text2();
        }
        islevel2talk=true;
    }

    public void level3_1(){
        player.transform.GetComponent<player>().not_move=true;
        CG.alpha=1;
        CG.blocksRaycasts=true;
        CG.interactable=true;
        num_Dialogy=GameObject.Find("sprite-wanta_0").GetComponent<wantaTalk>().begin;
        string[] tmp = PlayDialogy[num_Dialogy].Split('|');
        dialogyText.text=tmp[2];
        textLength=GameObject.Find("sprite-wanta_0").GetComponent<wantaTalk>().nowstance;
        talkNum=GameObject.Find("sprite-wanta_0").GetComponent<wantaTalk>().clicknum;
        if(talkNum==0||talkNum==1||talkNum==3||talkNum==4){
            dialogyBorder.sprite=Princess;
        }else if(talkNum==2){
            dialogyBorder.sprite=Narration;
        }else if(talkNum==5){
            dialogyBorder.sprite=unknown;
        }else if(talkNum==6){
            dialogyBorder.sprite=wanta;
        }
    }

    public void level3(){
        player.transform.GetComponent<player>().not_move=true;
        CG.alpha=1;
        CG.blocksRaycasts=true;
        CG.interactable=true;
        num_Dialogy=GameObject.Find("sprite-fake").GetComponent<FakeTalk>().begin;
        string[] tmp = PlayDialogy[num_Dialogy].Split('|');
        dialogyText.text=tmp[2];
        textLength=GameObject.Find("sprite-fake").GetComponent<FakeTalk>().nowstance;
        talkNum=GameObject.Find("sprite-fake").GetComponent<FakeTalk>().clicknum;
        if(talkNum==0){
            dialogyBorder.sprite=fakeKnight;
        }else if(talkNum==1||talkNum==6){
            dialogyBorder.sprite=Narration;
        }else if(talkNum==2||talkNum==3||talkNum==4||talkNum==5||talkNum==7){
            dialogyBorder.sprite=Princess;
        }
    }

    public void next(){
        num_Dialogy++;
        if(mul){
            if(num_Dialogy<textLength+1&&NPCDialogy[num_Dialogy,0]==talkNum.ToString()){
                give_sprite_text2();
            }else{
                if(NPCName=="flower"&&num_Dialogy<7){
                    GameObject.Find("flowerShow").GetComponent<CanvasGroup>().alpha=0;
                }
                else if(NPCName=="artisan"&&num_Dialogy<15&&inventory.countClickWood>5){
                    inventory.countClickWood-=6;
                    for(int i=0;i<inventory.slot.Length;i++)
                    {  
                        if(inventory.isClickWood==true){
                    
                            if(inventory.slot[i].transform.childCount>0)
                            {
                                if(inventory.slot[i].transform.GetChild(0).name=="wood1(Clone)")
                                {
                                    switch (inventory.countClickWood)
                                    {
                                        case 0:
                                            inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=null;
                                            inventory.slot[i].transform.GetChild(0).GetComponent<Image>().color=new Color(1,1,1,0);
                                            // Destroy(inventory.slot[i].transform.GetChild(0).gameObject);
                                            break;
                                        case 1:
                                            inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[0];
                                            BtnAni.SetTrigger("shake");                
                                            BtnAni.SetTrigger("idle");
                                            GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

                                            break;
                                        case 2:
                                            inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[1];
                                            BtnAni.SetTrigger("shake");
                                            BtnAni.SetTrigger("idle");
                                            GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
            
                    }
                }
                else if(NPCName=="artisan"&&num_Dialogy==24&&GameObject.Find("artisan").GetComponent<clickNPC>().woodnum==8)
                {
                    for(int i=0;i<inventory.slot.Length;i++)
                    {  
                        if(inventory.isClickWood==true){
                    
                            if(inventory.slot[i].transform.childCount>0)
                            {
                                if(inventory.slot[i].transform.GetChild(0).name=="wood1(Clone)")
                                {
                                    BtnAni.SetTrigger("shake");                
                                    BtnAni.SetTrigger("idle");
                                    GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

                                    inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=knife;
                                }
                            }
                        }
            
                    }
                }
                skip();
            }
        }else{
            if(num_Dialogy<textLength+1){
                string[] tmp = PlayDialogy[num_Dialogy].Split('|');
                if(level=="3-1"||level=="3"||level=="1-3"||level=="2"){
                    if(isEnd){
                        dialogyBorder.sprite=NotHaveName;
                    }else{
                        if(tmp[1]=="夏洛特"){
                            dialogyBorder.sprite=Princess;
                        }else if(tmp[1]=="？？？"){
                            dialogyBorder.sprite=unknown;
                        }else if(tmp[1]=="旁白"){
                            dialogyBorder.sprite=Narration;
                        }else if(tmp[1]=="士兵"){
                            dialogyBorder.sprite=solider;
                        }else if(tmp[1]=="旺妲"){
                            dialogyBorder.sprite=wanta;
                        }else if(tmp[1]=="假騎士1"){
                            dialogyBorder.sprite=fakeKnight;
                        }else if(tmp[1]=="假騎士"){
                            dialogyBorder.sprite=fakeKnight1;
                        }else if(tmp[1]=="鳥兒"){
                            dialogyBorder.sprite=bird;
                        }else if(tmp[1]=="花店店長"){
                            dialogyBorder.sprite=flower;
                        }
                        dialogyText.text=tmp[2];
                    }
                }else{
                    if(tmp[0]=="夏洛特"){
                        dialogyBorder.sprite=Princess;
                    }else if(tmp[0]=="皇后"){
                        dialogyBorder.sprite=Queen;
                    }else if(tmp[0]=="旁白"){
                        dialogyBorder.sprite=Narration;
                    }else if(tmp[0]=="國王"){
                        dialogyBorder.sprite=King;
                    }else if(tmp[0]=="伯特萊姆"){
                        dialogyBorder.sprite=Knight;
                    }
                    dialogyText.text=tmp[1];
                }
                if(level=="leading"){
                    dialogyText.GetComponent<typewriter>().words=tmp[1];
                    dialogyText.GetComponent<typewriter>().isPrint=true;
                }else if(isEnd){
                    dialogyText.GetComponent<typewriter>().words=tmp[2];
                    dialogyText.GetComponent<typewriter>().isPrint=true;
                }
            }else{
                skip();
            }
        }

        if(level=="1-2"&&keydown==0&&num_Dialogy==22){
            isOpenDiary.queenTalk=true;
            //拿到麵包
            for(int i=0;i<inventory.slot.Length;i++)
            {   
                //判斷那個格子裡面有沒有東西
                if(inventory.isFull[i]==false)
                {   
                    BtnAni.SetTrigger("shake");                
                    BtnAni.SetTrigger("idle");
                    GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

                    Instantiate(itemButton,inventory.slot[i].transform,false);//把prefab的圖片放進去slot裡面
                    inventory.isFull[i]=true;
                    break;  
                } 
            }
            // keydown=1;
        }
        else if(level=="1-2"&&keydown==0&&num_Dialogy==24)
        {           
             //拿到花
            for(int i=0;i<inventory.slot.Length;i++)
            {   
                //判斷那個格子裡面有沒有東西
                if(inventory.isFull[i]==false)
                {   
                    BtnAni.SetTrigger("shake");                
                    BtnAni.SetTrigger("idle");
                    GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

                    Instantiate(itemButton2,inventory.slot[i].transform,false);//把prefab的圖片放進去slot裡面
                    inventory.isFull[i]=true;
                    break;  
                } 
            }
            keydown=1;
        }else if(level=="2"&&isEnd&&num_Dialogy==5){
            GameObject.Find("TScene").transform.GetChild(0).GetComponent<Image>().color=new Color(1,1,1,1);
        }else if(level=="3"&&isEnd&&num_Dialogy==1){
            GameObject.Find("TScene").transform.GetChild(0).GetComponent<Image>().color=new Color(1,1,1,1);
        }else if(level=="3"&&isEnd&&num_Dialogy==11){
            GameObject.Find("TScene").transform.GetChild(0).GetComponent<Image>().sprite=plot3[0];
        }else if(level=="3"&&isEnd&&num_Dialogy==12){
            GameObject.Find("TScene").transform.GetChild(0).GetComponent<Image>().sprite=plot3[1];
        }else if(level=="3"&&isEnd&&num_Dialogy==14){
            GameObject.Find("TScene").transform.GetChild(0).GetComponent<Image>().sprite=plot3[2];
        }
    }
    
    void option(){
        if(level=="3-1"){
            GameObject.Find("sprite-wanta_0").GetComponent<SpriteRenderer>().color=new Color(1,1,1,1);
            for(int i=0;i<4;i++){
                GameObject.Find("3-2_magic").transform.GetChild(i).GetComponent<Light2D>().enabled=true;
            }
            GameObject.Find("3-2_magic").GetComponent<SpriteRenderer>().color=new Color(156/255f,153/255f,153/255f,1);
            if(GameObject.Find("sprite-wanta_0").GetComponent<wantaTalk>().begin==0){
                GameObject.Find("sprite-wanta_0").GetComponent<wantaTalk>().begintime=true;
            }
            
        }else if(level=="3"){
            if(GameObject.Find("sprite-fake").GetComponent<FakeTalk>().begin==0){
                GameObject.Find("sprite-fake").GetComponent<FakeTalk>().begintime1=true;
            }
        }
        GameObject.Find("option").GetComponent<CanvasGroup>().alpha=1;
        GameObject.Find("option").GetComponent<CanvasGroup>().blocksRaycasts=true;
        GameObject.Find("option").GetComponent<CanvasGroup>().interactable=true;
    }

    public void skip(){
        if(runoption){
            option();
        }else{
            if(level=="1-3"&&isEnd){
                SceneManager.LoadScene("Level_2_town");
                isEnd=false;
            }
            if(level=="2"&&isEnd){
                SceneManager.LoadScene("Level_3_forest");
                isEnd=false;
            }
            if(level=="3-1"){
                if(GameObject.Find("sprite-wanta_0").GetComponent<wantaTalk>().lose){
                    SceneManager.LoadScene("GameOver");
                    inventory.lastScene="";
                }
                if(talkNum==6){
                    player.transform.GetComponent<player>().lead_away=true;
                }
            }
            if(level=="3"){
                if(talkNum==1||talkNum==2){
                    SceneManager.LoadScene("GameOver");
                }else{
                    Destroy(GameObject.Find("sprite-fake"));
                }
            }
            CG.alpha=0;
            CG.blocksRaycasts=false;
            CG.interactable=false;
            if(level=="leading"){
                GameObject.Find("Canvasillustrate").GetComponent<CanvasGroup>().alpha=1;
                GameObject.Find("Canvasillustrate").GetComponent<CanvasGroup>().blocksRaycasts=true;
                GameObject.Find("Canvasillustrate").GetComponent<CanvasGroup>().interactable=true;
                GameObject.Find("Main Camera").GetComponent<AudioSource>().Pause();
            }else{
                player.GetComponent<player>().not_move=false;
                if(level=="1-2"&&keydown==0){
                    //DiaryItem
                    isOpenDiary.queenTalk=true;
                    //拿到麵包
                    for(int i=0;i<inventory.slot.Length;i++){   
                        //判斷那個格子裡面有沒有東西
                        if(inventory.isFull[i]==false)
                        {   
                            BtnAni.SetTrigger("shake");                
                            BtnAni.SetTrigger("idle");
                            GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

                            Instantiate(itemButton,inventory.slot[i].transform,false);//把prefab的圖片放進去slot裡面
                            inventory.isFull[i]=true;
                            // Destroy(gameObject);//刪掉object
                            break;  
                        } 
                        if(inventory.isFull[i]==false)
                        {   
                            BtnAni.SetTrigger("shake");                
                            BtnAni.SetTrigger("idle");
                            GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

                            Instantiate(itemButton2,inventory.slot[i].transform,false);//把prefab的圖片放進去slot裡面
                            inventory.isFull[i]=true;
                            break;  
                        } 
                    }
                    keydown=1;
                }
                if(level=="2"){
                    // for(int i=0;i<GameObject.Find("solider").transform.childCount;i++){
                    //     islevel2talk=false;
                    // }
                }
            }
        }
    }

    public void close_illustrate(){
        GameObject.Find("Canvasillustrate").GetComponent<CanvasGroup>().alpha=0;
        GameObject.Find("Canvasillustrate").GetComponent<CanvasGroup>().blocksRaycasts=false;
        GameObject.Find("Canvasillustrate").GetComponent<CanvasGroup>().interactable=false;
        GameObject.Find("Main Camera").GetComponent<CameraFade>().FadeOutIsStart=true;        
    }

    void give_sprite_text2(){
        if(NPCDialogy[num_Dialogy,1]=="夏洛特"){
            dialogyBorder.sprite=Princess;
        }else if(NPCDialogy[num_Dialogy,1]=="皇后"){
            dialogyBorder.sprite=Queen;
        }else if(NPCDialogy[num_Dialogy,1]=="旁白"){
            dialogyBorder.sprite=Narration;
        }else if(NPCDialogy[num_Dialogy,1]=="國王"){
            dialogyBorder.sprite=King;
        }else if(NPCDialogy[num_Dialogy,1]=="花店店長"){
            dialogyBorder.sprite=flower;
        }else if(NPCDialogy[num_Dialogy,1]=="老人"){
            dialogyBorder.sprite=older;
        }else if(NPCDialogy[num_Dialogy,1]=="男孩"){
            dialogyBorder.sprite=boy;
        }else if(NPCDialogy[num_Dialogy,1]=="女孩"){
            dialogyBorder.sprite=girl;
        }else if(NPCDialogy[num_Dialogy,1]=="中年女性"){
            dialogyBorder.sprite=woman;
        }else if(NPCDialogy[num_Dialogy,1]=="工匠"){
            dialogyBorder.sprite=artisan;
        }else if(NPCDialogy[num_Dialogy,1]=="中年大叔"){
            dialogyBorder.sprite=man;
        }else if(NPCDialogy[num_Dialogy,1]=="？？？"){
            dialogyBorder.sprite=unknown;
        }else if(NPCDialogy[num_Dialogy,1]=="士兵"){
            dialogyBorder.sprite=solider;
        }else if(NPCDialogy[num_Dialogy,1]=="旺妲"){
            dialogyBorder.sprite=wanta;
        }
        dialogyText.text=NPCDialogy[num_Dialogy,2];
    }

}
