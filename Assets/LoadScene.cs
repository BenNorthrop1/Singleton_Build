using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        string scene = SceneManager.GetActiveScene().name;

        if(scene == "Scene 1" && Input.GetKey("l"))
        {
                SceneManager.LoadScene("Scene 2");
        }

            if(scene == "Scene 2" && Input.GetKey("l"))
        {
                SceneManager.LoadScene("Scene 1");
        }
    }
}
