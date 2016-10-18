using UnityEngine;
using System.Collections;

public class ParticleDemo : MonoBehaviour 
{
	public GameObject projectileParticle;
    public GameObject projectileExplosion;
	public float minSpeed;
	public float maxSpeed;

	void OnDestroy()
	{
        GameObject explosion = Instantiate (projectileExplosion, gameObject.transform.position, Quaternion.identity) as GameObject;

        int randCount = Random.Range (4, 8);

		for (int i = 0; i < randCount; i++)
		{
			GameObject particle = Instantiate (projectileParticle, gameObject.transform.position, Quaternion.identity) as GameObject;

			//create random direction
			Vector2 randDir = new Vector2 (Random.Range (-10, 10), Random.Range (-10, 10));
			randDir.Normalize ();

			//create random speed
			float randSpeed = Random.Range (minSpeed, maxSpeed);

			particle.GetComponent<Rigidbody2D> ().AddForce (randDir * randSpeed);
		}

	}
}
