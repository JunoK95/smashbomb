using UnityEngine;
using System.Collections;

public class BulletExplosion : MonoBehaviour {

    public float knockBackStunTime = 5;
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
            Debug.Log("Hit");
            trigger.gameObject.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled = false;
            
            trigger.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-1000, 0, 0);
            StartCoroutine(knockBackStun(knockBackStunTime));
            trigger.gameObject.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled = true;      
        }
    }

    IEnumerator knockBackStun(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
    }
}
