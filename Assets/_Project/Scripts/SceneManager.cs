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
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Survival()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("kobayashi");
    }
}