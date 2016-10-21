using UnityEngine;
using System.Collections;

public class BulletExplosion : MonoBehaviour {

    public float knockBackStunTime = 5;
    public float knockBackSpeed = 50;

    private float xdirection = 1;
    private float ydirection = 1;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerStay2D (Collider2D trigger)
    {
        float gameObjectPosx = trigger.gameObject.transform.position.x;
        float gameObjectPosy = trigger.gameObject.transform.position.y;
        Vector3 directionVector;
        if (trigger.gameObject.tag == "Player")
        {
            if (gameObjectPosx <= this.transform.position.x)
            {
                xdirection = 1;
            } 
            else
            {
                xdirection = -1;
            }
            if (gameObjectPosy > this.transform.position.y)
            {
                ydirection = -1;
            }
            else
            {
                ydirection = 1;
            }
            Debug.Log(ydirection);

            directionVector = (new Vector3((this.gameObject.transform.position.x - gameObjectPosx)*xdirection, (this.gameObject.transform.position.y - gameObjectPosy) * ydirection, 0).normalized);
            trigger.gameObject.GetComponent<Rigidbody2D>().velocity = directionVector * knockBackSpeed;     
        }
    }   
}
