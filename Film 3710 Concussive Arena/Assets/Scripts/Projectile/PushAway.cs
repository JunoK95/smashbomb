using UnityEngine;
using System.Collections;

public class PushAway : MonoBehaviour {

    
    private bool intrigger;

    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D player)
    {
        intrigger = true;
        Rigidbody2D playerbody = GetComponent<Rigidbody2D>();
        playerbody.AddForce(new Vector2(100, 0));
    }
        
    void OnTriggerExit2D(Collider2D player)
    {
        intrigger = false;
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        intrigger = true;
    }
    void Push()
    {
 
    }
}
