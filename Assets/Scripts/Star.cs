using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        this.material = new Material(Shader.Find("Custom/Estrella"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnControllerColliderHit(ControllerColliderHit hit){

        if(hit.gameObject.name == "7-Tip-Star"){
            GetComponentInChildren<Renderer>().material = this.material;
        }
    }
}
