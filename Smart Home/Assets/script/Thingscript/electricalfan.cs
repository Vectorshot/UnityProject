using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricalfan : MonoBehaviour {
    public float rotationSpeedX = 0;
    public float rotationSpeedY = 30;
    public float rotationSpeedZ = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 90, 0));
        transform.Rotate(new Vector3(rotationSpeedX, rotationSpeedY, rotationSpeedZ) * Time.deltaTime);
    }
}
