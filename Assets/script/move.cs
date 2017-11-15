using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move : MonoBehaviour {

    public float distance;

    public float time;

    public GameObject cube;

    public Transform cube2;
    public Transform cube3;

    public bool paused;

    private Vector3 newBodyPos;

    private int bodyCount = 0;

    public static List<Transform> bodyPart;

    private float smooth = 5f;

    public string directionOfHead = "front";

    public static int lengthOfBody;

    // Use this for initialization
    void Start()
    {
        lengthOfBody = 2;
        SnakeDirection snakeDirection = this.GetComponent<SnakeDirection>();
        smooth = snakeDirection.smooth;
        bodyPart = new List<Transform>();
        bodyPart.Add(cube2);
        bodyPart.Add(cube3);
    }

    // Update is called once per frame
    void Update()
    {

        //IF PAUSING THEN DO NOTHING
        if (paused)
            return;

        Vector3 headPos = this.transform.position;

        bool didChance = false;

        //ALWAYS MOVE TOWARD
        transform.position += transform.forward * distance;

        if (bodyPart.Count > 0)
        {
            Vector3 firstPos = bodyPart[0].position;
            Vector3 secondPos = bodyPart[0].position;

            if (bodyPart[0].rotation != this.transform.rotation && didChance == false)
            {
                bodyPart[0].rotation = this.transform.rotation;
                didChance = true;
            }
            bodyPart[0].position = headPos;

            int i = 1;
            
            while (i < bodyPart.Count)
            {
                if (bodyPart[i].rotation != bodyPart[i - 1].rotation && didChance == false)
                {
                    bodyPart[i].rotation = bodyPart[i - 1].rotation;
                    didChance = true;
                }

                secondPos = bodyPart[i].position;
                bodyPart[i].position = firstPos;

                firstPos = secondPos;

                i++;
            }
        }
       StartCoroutine(Pause());
    }

    public IEnumerator Pause()
    {
        paused = true;
        yield return new WaitForSeconds(time);
        paused = false;
    }

}


