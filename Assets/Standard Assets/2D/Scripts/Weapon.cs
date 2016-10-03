using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask notToHit;
    public GameObject Bullet;
    [Tooltip("How fast the bullet will fire")]
    public float bulletSpeed = 5;
    public float bulletLifeTime = 3;


    private float timeToFire = 0;
    private Transform firePoint;

	// Use this for initialization
	void Awake () {
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("no firepoint");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1/fireRate;
                Shoot();
            }
        }

	}

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition-firePointPosition, 100, notToHit);


        GameObject tempBulletHandler;
        tempBulletHandler = Instantiate(Bullet, firePoint.position, transform.rotation) as GameObject;
        Rigidbody2D tempRigidBody;
        tempRigidBody = tempBulletHandler.GetComponent<Rigidbody2D>();
        Debug.Log(tempBulletHandler.transform.up);
        tempRigidBody.AddForce(tempBulletHandler.transform.up.normalized * bulletSpeed, ForceMode2D.Impulse);

        StartCoroutine(WaitandTrigger(bulletLifeTime*.8f,tempBulletHandler));
        Destroy(tempBulletHandler, bulletLifeTime);
    }

    IEnumerator WaitandTrigger(float waitTime, GameObject bullethandle)
    {
        yield return new WaitForSeconds(waitTime);
        bullethandle.GetComponent<CircleCollider2D>().enabled = true;
        Debug.Log("trig");
    }
}
