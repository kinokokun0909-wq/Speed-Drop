using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuController : MonoBehaviour
{
    [SerializeField] private GameObject titlePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject menuPanel;

    [SerializeField] private string gameSceneName = "nikuudon scene";

    private void Start()
    {
        ShowTitle();
    }

    public void ShowTitle()
    {
        titlePanel.SetActive(true);
        settingsPanel.SetActive(false);
        menuPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        titlePanel.SetActive(false);
        settingsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void ShowMenu()
    {
        titlePanel.SetActive(false);
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void ShowModeSelect()
    {
        titlePanel.SetActive(false);
        settingsPanel.SetActive(false);
        menuPanel.SetActive(false);
    }

    public void StartNormalMode()
    {
        PlayerPrefs.SetString("SelectedMode", "Normal");
        StartGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
