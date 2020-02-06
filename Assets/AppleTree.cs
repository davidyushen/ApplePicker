using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;

    public float speed = 1f;

    public float leftAndRightEdge = 10f;

    public float chanceToChangeDirections = 0.1f;

    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Dropping apples every second
        Invoke("DropApple",
        2f); // a
    }
    void DropApple()
    { // b
        GameObject apple = Instantiate<GameObject>(applePrefab
        ); // c
        apple.transform.position =
        transform.position; // d
        Invoke("DropApple", secondsBetweenAppleDrops
        );
}

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftAndRightEdge)
        { // a
            speed = Mathf.Abs(speed); // Move right // b
        }
        else if (pos.x > leftAndRightEdge)
        { // c
            speed = -Mathf.Abs(speed); // Move left // c

        }
    }
    void FixedUpdate()
    {
        // Changing Direction Randomly is now time-based because of
        if (Random.value < chanceToChangeDirections)
        { // b
            speed *= -1; // Change direction
        }
    }
}
