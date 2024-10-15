using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleGameObject(GameObject go)
    {
        if (go.activeSelf)
        {
            go.SetActive(false);
        } else{
            go.SetActive(true);
        }
    }
}
