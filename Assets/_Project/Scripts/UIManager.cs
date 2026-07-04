using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject titlePanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject modeSelectPanel;

    void Start()
    {
        ShowTitlePanel();
    }

    public void ShowTitlePanel()
    {
        titlePanel.SetActive(true);
        settingPanel.SetActive(false);
        modeSelectPanel.SetActive(false);
    }

    public void ShowSettingPanel()
    {
        titlePanel.SetActive(false);
        settingPanel.SetActive(true);
        modeSelectPanel.SetActive(false);
    }

    public void ShowModeSelectPanel()
    {
        titlePanel.SetActive(false);
        settingPanel.SetActive(false);
        modeSelectPanel.SetActive(true);
    }
}