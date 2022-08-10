using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFade : MonoBehaviour
{
    public float FadeInTime = 10f;
    public float FadeOutTime = 10f;
    public Color FadeInColor = new Color(0.1F, 0.1F, 0.1F, 1);
    public Color FadeOutColor = new Color(0.1F, 0.1F, 0.1F, 1);
 
    public bool FadeInIsStart = false;
    public bool FadeOutIsStart = false;
    public bool FadeInIsDone = false;
    public bool FadeOutIsDone = false;
 
    private Texture2D t2d;
    private GUIStyle gs;
 
    private static float a = 0;
 
    void Awake (){
        FadeInIsStart = false;
        FadeOutIsStart = false;
        FadeInIsDone = false;
        FadeOutIsDone = false;
        a = 0;
 
        t2d = new Texture2D (1, 1);
        t2d.SetPixel (0, 0, FadeInColor);
        t2d.Apply ();

        gs = new GUIStyle ();
        gs.normal.background = t2d;
    }

    private void Start() {
        FadeIn();
    }
 
    void OnGUI (){
        GUI.depth = -1000;
        GUI.Label (new Rect (0, 0, Screen.width, Screen.height), t2d, gs);
    }
 
    void Update () {
        if(FadeInIsStart){
            if (a > 0) {
                a -= Time.deltaTime / FadeInTime;
                t2d.SetPixel (0, 0, new Color (FadeInColor.r, FadeInColor.g, FadeInColor.b, a));
                t2d.Apply ();
            }else{
                FadeInIsStart = false;
                FadeInIsDone = true;
                GameObject.Find("dialog").GetComponent<CanvasGroup>().alpha=1;
                transform.GetComponent<AudioSource>().Play();
            }
        }
 
        if(FadeOutIsStart){
            if (a < 1) {
                a += Time.deltaTime / FadeOutTime;
                t2d.SetPixel (0, 0, new Color (FadeOutColor.r, FadeOutColor.g, FadeOutColor.b, a));
                t2d.Apply ();
            }else{
                FadeOutIsStart = false;
                FadeOutIsDone = true;
                SceneManager.LoadScene("Level_1_1_princess");
            }
        }
 
    }
 
    // 淡入
    public void FadeIn(){
        a = 1;
        FadeInIsStart = true;
        FadeInIsDone = false;
    }
 
    // 淡出
    public void FadeOut(){
        a = 0;
        FadeOutIsStart = true;
        FadeOutIsDone = false;
    }
}
