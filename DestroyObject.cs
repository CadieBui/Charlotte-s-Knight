using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObject : MonoBehaviour
{
    GameObject player;
    GameObject backpack;
    GameObject diary;
    GameObject bar;
    GameObject progress;
    GameObject enter;


    void Start()
    {

        player = GameObject.Find("player");
        backpack = GameObject.Find("CanvasBackPack");
        diary = GameObject.Find("CanvasDiary");
        bar = GameObject.Find("CanvasBar");
        progress = GameObject.Find("CanvasProgress");
        enter = GameObject.Find("CanvasEnterDoor");
        if (SceneManager.GetActiveScene().name == "start")
        {

            Destroy(player);
            Destroy(backpack);
            Destroy(diary);
            Destroy(bar);
        }
    }
}
