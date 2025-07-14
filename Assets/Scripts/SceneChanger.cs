using UnityEngine;
using UnityEngine.SceneManagement;

namespace TD
{
    public class SceneChanger : MonoBehaviour
    {
        public void SelectMainMenuScene()
        {
            SceneManager.LoadScene(0);
        }

        public void SelectMapScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}