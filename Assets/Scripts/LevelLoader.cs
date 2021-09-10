using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance { get; private set; }

    [SerializeField] private GameObject loadingScene;
    [SerializeField] private TextMeshProUGUI textSlider;
    [SerializeField] private Slider slider;
    private void Awake()
    {
        Instance = this;
    }

    public void LoadLevel(int index)
    {
        StartCoroutine(LoadSceneAsynchronosly(index));
    }

    IEnumerator LoadSceneAsynchronosly(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScene.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Round(operation.progress / 0.9f);
            slider.value = progress;
            textSlider.text = progress * 100f + "%";
            yield return null;
        }
    }


}
