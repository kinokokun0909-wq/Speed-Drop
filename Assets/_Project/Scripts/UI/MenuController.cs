using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpeedDrop.UI
{
    public sealed class MenuController : MonoBehaviour
    {
        [SerializeField] private string mainSceneName = "Main";

        public void StartGame()
        {
            SceneManager.LoadScene(mainSceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
