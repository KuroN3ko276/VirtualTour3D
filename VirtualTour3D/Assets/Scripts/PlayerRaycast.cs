using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerRaycast : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);

		if(Physics.Raycast(ray, out hit))
		{
			if(Input.GetMouseButtonDown(0))
            {
                Debug.Log((hit.collider.name));
                Debug.Log(hit.collider.GetComponent<Hotspot>().targetScene);
                StartCoroutine(ChangeScene(hit.collider.GetComponent<Hotspot>().targetScene));
            }
		}
    }

    IEnumerator ChangeScene(string targetScene)
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadSceneAsync(targetScene);
    }
}
