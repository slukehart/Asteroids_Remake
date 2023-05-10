using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance;

        [SerializeField]
        private GameObject gameOverUI;

        private bool isGameOver;

        private void Awake()
        {
           _instance = this;
        }

        private void Update()
        {
            if (isGameOver && Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Scene_1");
            }
        }

        public void TriggerGameOver()
        {
            gameOverUI?.SetActive(true);
            isGameOver = true;
        }
    }
}
