using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float Speed = 0f;
    private float movex = 0f;
    private float movey = 0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");
        if (movex > 0)
        {
            movex = 1;
        }
        if (movex < 0)
        {
            movex = -1;
        }
        rigidbody.velocity = new Vector2(movex * Speed, movey * Speed);
    }
}
