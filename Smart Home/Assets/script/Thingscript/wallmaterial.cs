using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallmaterial : MonoBehaviour {
    public static bool state = true;
    void transparentwalls()
    {
        /*
        Material material = new Material(Shader.Find("Transparent/Diffuse"));
        //material.color = Color.white;
        material.SetVector("_Color",new Vector4(1,1,1,0.4f));
        // GetComponent<Renderer>().material = material;
        */
        this.gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/item/Mat3d66-517373-3-444");
    }
    void solidwalls()
    {
        /*
        Material material = new Material(Shader.Find("Transparent/Diffuse"));
        //material.color = Color.white;
        material.SetVector("_Color", new Vector4(1, 1, 1, 1f));
        GetComponent<Renderer>().material = material;
        */
        this.gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/item/woodiness1");
    }
	// Use this for initialization
	void Start () {
        if (state)
            transparentwalls();
        else
            solidwalls();
    }
	
	// Update is called once per frame
	void Update () {
        if (state)
            transparentwalls();
        else
            solidwalls();
    }
}
