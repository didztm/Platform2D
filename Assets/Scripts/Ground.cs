﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    // Use this for initialization
    private float timeUnity;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("platform"))
        {
            collision.transform.gameObject.SetActive(false);
        }
        if (collision.transform.CompareTag("player"))
        {
            collision.transform.gameObject.SetActive(false);
            timeUnity = Time.timeScale;
            Time.timeScale = 0f;
            Debug.Log(timeUnity);
        }
    }
    
}
