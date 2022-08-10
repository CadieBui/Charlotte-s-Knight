using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{

    public Texture2D mouseCursor;
    public GameObject trailEffect;
    public float timeSpawn=0.1f;
    Vector2 hotSpot = new Vector2(0,0);
    CursorMode cursorMode = CursorMode.Auto;
   private static MouseCursor dontDestroyUI {get;set;}

    private void Start()
    {        
        DontDestroyOnLoad(this.gameObject);    

        if(dontDestroyUI==null){
            dontDestroyUI=this;

        }
        else {
            Destroy(this.gameObject);

        }

        Cursor.SetCursor(mouseCursor, hotSpot, cursorMode);

    }
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(timeSpawn<=0)
        {
            Instantiate(trailEffect, mousePosition, Quaternion.identity);
            timeSpawn = 0.1f;
        }
        else{

            timeSpawn-=Time.deltaTime;
        }
    }
}
