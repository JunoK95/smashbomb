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
        if (trigger.gameObject.tag == "Player")
        {
            if (trigger.gameObject.transform.position.x <= this.transform.position.x)
            {
                xdirection = -1;
            } 
            else
            {
                xdirection = 1;
            }
            if (trigger.gameObject.transform.position.y <= this.transform.position.y)
            {
                ydirection = -1;
            }
            else
            {
                ydirection = 1;
            }
            Debug.Log("Hit");
            //trigger.gameObject.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled = false;
            
            trigger.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(xdirection,ydirection,0).normalized * knockBackSpeed;
            StartCoroutine(knockBackStun(knockBackStunTime));
            //trigger.gameObject.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled = true;      
        }
    }

    IEnumerator knockBackStun(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
    }
}
