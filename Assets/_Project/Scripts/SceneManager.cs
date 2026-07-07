using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void BackToTitle()
    {
        SceneManager.LoadScene("title");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Survival();
    }

    public void Survival()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
}