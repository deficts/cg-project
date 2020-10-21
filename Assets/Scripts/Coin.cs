using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private float x = 0.001f;
    public Material material;
    public Texture mainTexture;
    public Texture noiseTexture;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator dissolve(ControllerColliderHit hit){
        hit.gameObject.GetComponent<Renderer>().material = this.material;
        hit.gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", this.mainTexture);
        hit.gameObject.GetComponent<Renderer>().material.SetTexture("_NoiseTex", this.noiseTexture);
        while(this.x < 1){
            x += 0.01f;
            hit.gameObject.GetComponent<Renderer>().material.SetFloat("_Level", x);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit){
        if(hit.gameObject.name == "Moneda"){
            StartCoroutine(dissolve(hit));
        }
    }
}
