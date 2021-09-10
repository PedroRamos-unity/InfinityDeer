using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class DeathPanel : MonoBehaviour
{
    [SerializeField] private GameObject deathScren;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI maxScoreText;

    private void OnEnable()
    {
        Actions.Death += DataBank.Save;
        Actions.Death += PlayerDeath;
    }

    private void OnDestroy()
    {
        Actions.Death -= DataBank.Save;
        Actions.Death -= PlayerDeath;
    }

    private void PlayerDeath()
    {
        
        deathScren.gameObject.SetActive(true);
        maxScoreText.text = "Max score: " + DataBank.PlayerMaxScore.ToString();
        currentScoreText.text = "Score: " +DataBank.PlayerCurrentScore.ToString();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }

    public void RestartButton(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }

    public void BackToMenu(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }


}
