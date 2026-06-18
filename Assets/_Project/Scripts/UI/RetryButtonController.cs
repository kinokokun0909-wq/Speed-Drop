using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpeedDrop.UI
{
    public sealed class RetryButtonController : MonoBehaviour
    {
        public void Retry()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
