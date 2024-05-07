using UnityEngine;
using UnityEngine.SceneManagement;

namespace StartScene
{
    public class StartSceneManager : MonoBehaviour
    {
        

        public void LoadInGameScene()
        {
            SceneManager.LoadScene("00_Scenes/InGameScene");
        }

        public void Quit()
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
