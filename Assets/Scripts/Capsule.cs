using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ship") 
            Debug.Log("Nave Colpita");       
        else
            Debug.Log("la capsula ha colpito: " + other.gameObject.name);
        Debug.Log("la capsula ha colpito: " + other.gameObject.name);
    }
}
