using UnityEngine;
using System.Collections;

public class GooDropParticleBehavior : MonoBehaviour 
{
	private float timer;
	public float minDeathTime;
	public float maxDeathTime;

	void Start()
	{
		timer = Random.Range (minDeathTime, maxDeathTime);
	}

	void Update()
	{
		if (timer > 0)
			timer--;
		else
			Destroy (gameObject);
	}
}
