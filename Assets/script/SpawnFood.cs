using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {
    public GameObject foodPrefabs;
    public static bool beEaten;

    public Transform borderLeft;
    public Transform borderRight;
    public Transform borderTop;
    public Transform borderBot;

    // Use this for initialization
    void Start () {
        beEaten = false;
	}
    
    // Update is called once per frame
    void Update () {
		if(beEaten == true)
        {
            Debug.Log("food die die die");

            int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
            
            int z = (int)Random.Range(borderBot.position.z, borderTop.position.z);
            
            transform.position = new Vector3(x, 0.5f, z);

            beEaten = false;
        }

        fixPosition();
	}

    void fixPosition()
    {
        Vector3 currentPos = this.transform.position;
        if (currentPos.x * 10 % 10 != 5 || currentPos.z * 10 % 10 != 5)
        {
            Vector3 fixPos = new Vector3();
            fixPos.x = Mathf.Floor(currentPos.x) + 0.5f;
            fixPos.y = 0.5f;
            fixPos.z = Mathf.Floor(currentPos.z) + 0.5f;
            this.transform.position = fixPos;
        }

    }
}
