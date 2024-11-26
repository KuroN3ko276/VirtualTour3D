using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class SkyBoxManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void SetSkybox(Material material)
    // {
    //     RenderSettings.skybox = material;
    // }

    [DllImport("__Internal")]
    private static extern void SendSceneNameToReact(string sceneName);
    
    public void SetScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
        try
        {
            // Đoạn mã có thể gây ra ngoại lệ
            SendSceneNameToReact(sceneName);
            Debug.Log("SendMessage"+sceneName);
        }
        catch (System.NullReferenceException ex)
        {
            // Xử lý ngoại lệ
            Debug.LogError("Đã xảy ra lỗi: " + ex.Message);
        }

    }

}
