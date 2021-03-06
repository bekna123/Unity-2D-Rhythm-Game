﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set; }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;  
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public float noteSpeed = 0.005f;

    public enum judges { NONE = 0,BAD,GOOD,PERFECT,MISS }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
    