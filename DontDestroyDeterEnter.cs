using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyDeterEnter : MonoBehaviour
{
    private static DontDestroyDeterEnter dontDestroyUI { get; set; }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (dontDestroyUI == null)
        {
            dontDestroyUI = this;

        }

        else
        {
            Destroy(this.gameObject);

        }

    }
}
