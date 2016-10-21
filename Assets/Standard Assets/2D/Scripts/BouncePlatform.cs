using UnityEngine;
using System.Collections;

public class BouncePlatform : MonoBehaviour {

    public float bounceSpeed = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D trigger)
    {
        trigger.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,bounceSpeed)) ;
    }
}
