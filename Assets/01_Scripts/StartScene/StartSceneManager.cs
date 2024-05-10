using UnityEngine;
using UnityEngine.SceneManagement;

namespace StartScene
{
    public class StartSceneManager : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private int clickAmount = 0;
        private float _alpha = 0;

        private void Awake()
        {
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        }

        public void LoadInGameScene()
        {
            SceneManager.LoadScene("00_Scenes/InGameScene");
        }

        public void ClickStartCount()
        {
            clickAmount++;
            if (clickAmount >= 5)
            {
                _alpha += 0.01f;
                clickAmount = 0;
                _spriteRenderer.color = new Color(1,1,1,_alpha);
            }
        }

        public void Quit()
        {
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
