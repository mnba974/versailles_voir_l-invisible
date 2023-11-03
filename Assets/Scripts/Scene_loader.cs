using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 1)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("SampleScene");
            SceneManager.UnloadSceneAsync(scene.buildIndex);
            Destroy(gameObject);
        }
    }
}
