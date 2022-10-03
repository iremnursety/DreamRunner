using TMPro;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private GameObject settingsPanel;
    private void Start()
    {
        countText.enabled = false;
        settingsPanel.SetActive(false);
    }

    public void SettingsClicked()
    {
        Time.timeScale = 0f;
        settingsPanel.SetActive(true);
    }

    public void BackToGameButton()
    {
        settingsPanel.SetActive(false);
        StartGame();
    }

   
    private void StartGame()
    {
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

   
}