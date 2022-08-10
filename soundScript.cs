using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Wrong;
    public static soundScript soundInstance;

    private void Awake() {
        if(soundInstance!=null&&soundInstance!=this){
            Destroy(this.gameObject);
            return;
        }
        soundInstance=this;
        DontDestroyOnLoad(this.gameObject);
    }
}
