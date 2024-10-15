using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Hotspot"))
        {
            go.transform.LookAt(transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
