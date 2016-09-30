﻿using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {


    public int rotation_offset = 90;
	// Update is called once per frame
	void Update () {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotation_offset);
	}
}
