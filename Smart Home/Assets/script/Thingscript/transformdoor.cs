using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformdoor : MonoBehaviour {
    
    public float rotationSpeedX = 0;
    public float rotationSpeedY = 30;
    public float rotationSpeedZ = 0;
    // Use this for initialization
    /*
    void Start () {
        //transform.Rotate(new Vector3(0,90,0));
        transform.RotateAround(GameObject.Find("Pole1").transform.position, Vector3.up, 90);
    }
	*/
    
	// Update is called once per frame
    
	void Update () {
        //transform.Rotate(new Vector3(0, 90, 0));
        //transform.Rotate(new Vector3(rotationSpeedX, rotationSpeedY, rotationSpeedZ) * Time.deltaTime);
        Quaternion target = Quaternion.Euler(0, 90, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, 2.0f);
        //transform.RotateAround(GameObject.Find("Pole").transform.position, Vector3.up, 90);

    }
    
}
