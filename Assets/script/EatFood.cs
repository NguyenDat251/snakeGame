﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour {

    //public GameObject food;
    public GameObject body;
    


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food")
        {
            SpawnFood.beEaten = true;
            Vector3 temp = move.bodyPart[move.lengthOfBody - 1].position;
            move.lengthOfBody++;
            GameObject g = (GameObject)Instantiate(body, temp, Quaternion.identity);
            move.bodyPart.Add(g.transform);
            Debug.Log("Ate");
        }
        if (other.tag == "body")
            Debug.Log("Die");
    }
}