using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typewriter : MonoBehaviour
{
    // Start is called before the first frame update
    private Text uiText;
    //儲存中間值
    public string words;
    //每個字符的顯示速度
    private float timer;
    // private float timer2;
    //限制條件，是否可以進行文本的輸出
    public bool isPrint = false;
    private float perCharSpeed=1;
    // private int text_length = 0;
    // private string Ctext;
    // Use this for initialization
    void Start()
    {
        GameObject.Find("dialog").GetComponent<CanvasGroup>().alpha=0;
        uiText = GetComponent<Text>();
        // words = GetComponent<Text>().text;
        // isPrint = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.GetComponent<dialogue>().level=="leading"){
            if(GameObject.Find("Main Camera").GetComponent<CameraFade>().FadeInIsDone==true){
                printText();
            }
        }else{
            printText();
        }
    }

    public void printText()
    {
        try
        {
            if (isPrint)
            {
                uiText.text = words.Substring(0, (int)(perCharSpeed * timer));//截取
                timer += Time.deltaTime*10;
            }
        }
        catch (System.Exception)
        {
            printEnd();
        }
    }

    void printEnd()
    {
        isPrint = false;
        timer=0;
        Invoke("next" , 2f);
    }

    void next(){
        transform.parent.GetComponent<dialogue>().next();
    }
}
