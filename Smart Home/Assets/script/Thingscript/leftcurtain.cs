using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftcurtain : MonoBehaviour {
    public float movespeed = 0.5f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float step = movespeed * Time.deltaTime;
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(0.7F, 18.54f, 0.2422227f), step);
        //transform.localScale = new Vector3(0.45f, 0.7270313F, 5.085106f);
        if(transform.localScale.x>0.5f)
            transform.localScale -= new Vector3(0.01f, 0, 0);
    }
}
