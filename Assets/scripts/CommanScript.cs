using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class CommanScript : MonoBehaviour
{
    public static CommanScript  Instance;
    public bool Music, Sound;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        { 
            Destroy(this.gameObject);
        }    
    }
}
