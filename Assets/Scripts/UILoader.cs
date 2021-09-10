using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoader : MonoBehaviour
{
    private void Awake()
    {
        if(SceneManager.GetSceneByName("UI").isLoaded == false)
        {
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);

        }
    }

    private void Start()
    {
        Scene scene = SceneManager.GetSceneByName("Game");
        SceneManager.SetActiveScene(scene);
    }
}
