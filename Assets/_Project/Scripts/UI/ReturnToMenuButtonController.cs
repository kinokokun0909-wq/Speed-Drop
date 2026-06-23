using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpeedDrop.UI
{
    public sealed class ReturnToMenuButtonController : MonoBehaviour
    {
        private const string OpenModeSelectKey = "OpenModeSelectOnTitle";

        [SerializeField] private string menuSceneName = "title";

        public void ReturnToMenu()
        {
            Time.timeScale = 1f;
            PlayerPrefs.SetInt(OpenModeSelectKey, 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene(menuSceneName);
        }
    }
}
