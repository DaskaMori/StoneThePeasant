using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MedievalMayhem.Scripts
{
     public class GameManagerMm : MonoBehaviour
    {
        [Header("Game Settings")] 
        public float totalGameTime = 20f;
        [SerializeField] private float currentTime = 0f;
        [SerializeField] private bool gameActive = false;

        [Header("UI Panels")] 
        public GameObject titleScreen;
        public GameObject instructionScreen;
        public GameObject gameScreen;
        public GameObject gameOverScreen; 
        public Text finalScoreText;

        [Header("Spawning Targets")] 
        public List<GameObject> targetPrefab; 
        public List<Transform> spawnPoints; 
        public float spawnInterval = 1.5f;
        public int targetsPerWave = 3;
        private float nextSpawnTime = 0f;

        [Header("Scoring")]
        public int score = 0;
        public Text scoreText;
        public Text timerText;

        void Start()
        {
            ShowTitleScreen();
        }
        
        void Update()
        {
            if (!gameActive) return;

            currentTime += Time.deltaTime;
            float timeRemaining = totalGameTime - currentTime;

            if (timerText != null)
                timerText.text = Mathf.Clamp(timeRemaining, 0, totalGameTime).ToString("F2");

            if (timeRemaining <= 0f)
            {
                EndGame();
                return;
            }

            if (currentTime >= nextSpawnTime)
            {
                SpawnTargetBatch();
                nextSpawnTime = currentTime + spawnInterval;
            }
        }

        public void StartGame()
        {
            currentTime = 0f;
            score = 0;
            gameActive = true;
            nextSpawnTime = 0f;
            
            if (titleScreen != null) titleScreen.SetActive(false);
            if (instructionScreen != null) instructionScreen.SetActive(false);
            if (gameScreen != null) gameScreen.SetActive(true);
            if (gameOverScreen != null) gameOverScreen.SetActive(false);

            UpdateScoreUI();
            
            if (AudioManagerMm.Instance != null)
                AudioManagerMm.Instance.PlayMusic(AudioManagerMm.Instance.gameMusic);
        }
    
        private void EndGame()
        {
            gameActive = false;
            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(true);
            }

            int stones = CalculateStoneReward(score);
            GameScoreManager.Instance.AddtoScore(stones);
            
            if (finalScoreText != null)
            {
               finalScoreText.text = $"Stones Awarded: {stones}";
            }
            
            if (AudioManagerMm.Instance != null)
                AudioManagerMm.Instance.PlayMusic(AudioManagerMm.Instance.menuMusic);
        }

        private void SpawnTargetBatch()
        {
            for (int i = 0; i < targetsPerWave; i++)
            {
                if (spawnPoints.Count == 0 || targetPrefab.Count == 0) return;
                int randomPointIndex = Random.Range(0, spawnPoints.Count);
                Transform spawnPoint = spawnPoints[randomPointIndex];

                int randomPrefabIndex = Random.Range(0, targetPrefab.Count);
                GameObject prefabToSpawn = targetPrefab[randomPrefabIndex];

                GameObject newTarget = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
                BoxCollider2D collider = newTarget.GetComponent<BoxCollider2D>();
                Debug.Log("Collider present " + (collider != null));

                Target targetComponent = newTarget.GetComponent<Target>();
                if (targetComponent != null)
                {
                    targetComponent.spawnTime = Time.time;
                    targetComponent.isActive = true;
                }
            }
        }

        public void IncreaseScore(int points)
        {
            score += points;
            UpdateScoreUI();
        }

        private void UpdateScoreUI()
        {
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score.ToString();
            }
        }

        private void ShowTitleScreen()
        {
            if (titleScreen != null) titleScreen.SetActive(true);
            if (instructionScreen != null) instructionScreen.SetActive(false);
            if (gameScreen != null) gameScreen.SetActive(false);
            if (gameOverScreen != null) gameOverScreen.SetActive(false);
            
            if (AudioManagerMm.Instance != null)
                AudioManagerMm.Instance.PlayMusic(AudioManagerMm.Instance.menuMusic);
        }

        private void ShowinstructionScreen()
        {
            if (instructionScreen != null) instructionScreen.SetActive(true);
            if (gameOverScreen != null) gameOverScreen.SetActive(false);
        }

        public void OnPlayButtonClicked()
        {
            if (titleScreen != null) titleScreen.SetActive(false);
            if (instructionScreen != null) instructionScreen.SetActive(true);
        }

        public void OnContinueButtonClicked()
        {
            if (titleScreen != null) titleScreen.SetActive(false);
            if (instructionScreen != null) instructionScreen.SetActive(false);
        }

        public void OnReturnButtonClicked()
        {
            SceneManager.LoadScene("Main Menu");
        }
        
        private int CalculateStoneReward(int finalScore)
        {
            if (finalScore < 30) return 0;
            if (finalScore < 40) return 6;
            if (finalScore < 50) return 7;
            if (finalScore < 60) return 8;
            if (finalScore < 70) return 9;
            return 10;
        }
    }
}   