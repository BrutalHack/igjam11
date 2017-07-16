using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

	private float _speed = 160f;
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.back * Time.deltaTime * _speed);
	}
}
