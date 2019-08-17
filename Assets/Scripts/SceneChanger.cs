using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // 次のシーンの名前
    public string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Enterを押したら次のシーンへ遷移する。
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
