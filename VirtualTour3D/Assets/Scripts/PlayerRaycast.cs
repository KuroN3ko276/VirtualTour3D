using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class PlayerRaycast : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public bool enabled = true;
    public static PlayerRaycast instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);

            if(Physics.Raycast(ray, out hit))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    Debug.Log((hit.collider.name));
                    Hotspot hs = hit.collider.GetComponent<Hotspot>();
                    
                    Debug.Log(hit.collider.GetComponent<Hotspot>().targetScene);

                    if(hs.isSpawningPrefab)
                    {
                        enabled = false;
                        Instantiate(hs.prefabToSpawn);
                    }else{
                        //Instantiate(Resources.Load("Loading"));
                        StartCoroutine(ChangeScene(hs.targetScene));
                    }
                }      
		    }
        }
    }

    [DllImport("__Internal")]
    private static extern void SendSceneNameToReact(string sceneName);
    
    IEnumerator ChangeScene(string targetScene)
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadSceneAsync(targetScene);
        try
        {
            // Đoạn mã có thể gây ra ngoại lệ
            SendSceneNameToReact(targetScene);
            Debug.Log("SendMessage "+targetScene);
        }
        catch (System.NullReferenceException ex)
        {
            // Xử lý ngoại lệ
            Debug.LogError("Đã xảy ra lỗi: " + ex.Message);
        }
    }
    
}
