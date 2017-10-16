using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move : MonoBehaviour {

    public float distance = 1f;

    public float time = 1f;

    public GameObject cube;

    public Transform cube2;
    public Transform cube3;

    private bool paused;

    private Vector3 newBodyPos;

    private int bodyCount = 0;

    public static List<Transform> bodyPart;
    //public static List<string> dirBody;

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
        //dirBody.Add("front");
        bodyPart.Add(cube3);
        //dirBody.Add("front");
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
                //bodyPart[0].rotation = Quaternion.Lerp(transform.rotation, SnakeDirection.targetRotation, 10 * smooth * Time.deltaTime);
            bodyPart[0].position = headPos;

            int i = 1;
            
            while (i < bodyPart.Count)
            {
                if (bodyPart[i].rotation != bodyPart[i - 1].rotation && didChance == false)
                {
                    bodyPart[i].rotation = bodyPart[i - 1].rotation;
                    didChance = true;
                    //bodyPart[i].rotation = Quaternion.Lerp(transform.rotation, SnakeDirection.targetRotation, 10 * smooth * Time.deltaTime);
                }

                secondPos = bodyPart[i].position;
                bodyPart[i].position = firstPos;

                firstPos = secondPos;

                i++;
            }
        }
       StartCoroutine(Pause());
    }

    private IEnumerator Pause()
    {
        paused = true;
        yield return new WaitForSeconds(time);
        paused = false;
    }

}


