using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dodge
{
    public class DILIHGameManager : MonoBehaviour
    {
        // Initialize player, audio and trigger variables.
        [Header("Audio")]
        [SerializeField] AudioClip hitSound;
        [SerializeField] AudioClip applause;
        [SerializeField] AudioClip fail;
        [SerializeField] AudioSource fxSource;
        [SerializeField] AudioSource musicSource;
        bool musicPlaying = true;

        // Initialize UI.
        [Header("UI Panels")]
        [SerializeField] private GameObject titleScreen;
        [SerializeField] private GameObject gameOverPanelOne;
        [SerializeField] private GameObject gameOverPanelTwo;
        [SerializeField] private GameObject timePanel;
        
        // Initialize player movement.
        [Header("Player Controls")]
        [SerializeField] private GameObject player;
        public Player playerControl;
        [SerializeField] private Animator runAnimation;
        [SerializeField] private Animator idleAnimation;

        // Initialize game settings.
        [Header("Game Settings")]
        public HazardSpawner hazard;
        public float respawnTime = 0.5f;
        private bool gameActive = false;
        private bool gameWon = false;
        private bool gameLost = false;
        private IEnumerator coroutine;

        public void Start()
        {
            ShowTitleScreen();
            idleAnimation.enabled = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (!gameActive) return;

            // Toggle music by pressing 'M'
            if (Input.GetKeyDown(KeyCode.M))
            {
                musicPlaying = !musicPlaying;
                if (musicPlaying) { musicSource.Play(); }
                else { musicSource.Stop(); }
            }
        }

        // Function called by the Play Button
        public void PressPlayButton()
        {
            // When the Play button is pressed, the splash screen is removed, and the countdown starts.
            if (titleScreen != null) titleScreen.SetActive(false);
            if (gameOverPanelOne != null) gameOverPanelOne.SetActive(false);
            if (gameOverPanelTwo != null) gameOverPanelTwo.SetActive(false);
            timePanel.SetActive(true);
            gameActive = true;
            // Play background music.
            musicSource.Play();
            musicPlaying = true;
            // Start function Survive as a coroutine.
            coroutine = Survive(20.0f);
            StartCoroutine(coroutine);
            // Enable player movement.
            playerControl.enabled = true;
            // Spawn rocks.
            StartCoroutine(RockFall());
        }

        private IEnumerator Survive(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            GameOverOne();
        }

        public IEnumerator RockFall()
        {
            while (true)
            {
                yield return new WaitForSeconds(respawnTime);
                hazard.SpawnRocks();
            }
        }

        // If the player survived.
        public void GameOverOne()
        {
            if (gameLost != true)
            {
                // Stop spawning rocks
                gameActive = false;
                timePanel.SetActive(false);
                StopAllCoroutines();
                // player character stops
                playerControl.enabled = false;
                player.GetComponent<Collider2D>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                // bring up game over UI
                if (gameOverPanelOne != null)
                {
                    gameOverPanelOne.SetActive(true);
                }
                // plauy sfx and stop music
                fxSource.clip = applause;
                fxSource.Play();
                musicSource.Stop();
                musicPlaying = false;

                // Add the stones the player earned to the GameScoreManager
                GameScoreManager.Instance.AddtoScore(10);
                gameWon = true;
            }
            else
            {
                return;
            }
        }

        // If the player didn't succeed.
        public void GameOverTwo()
        {
            if (gameWon == false || gameLost == false)
            {
                // Stop spawning rocks 
                gameActive = false;
                gameLost = true;
                timePanel.SetActive(false);
                StopAllCoroutines();
                // player character stops
                playerControl.enabled = false;
                player.GetComponent<Collider2D>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                // bring up game over UI
                if (gameOverPanelTwo != null)
                {
                    gameOverPanelTwo.SetActive(true);
                }
                // plauy sfx and stop music
                fxSource.clip = fail;
                fxSource.Play();
                musicSource.Stop();
                musicPlaying = false;
            }
            else
            {
                return;
            }
        }

        public void PressPlayButtonTwo()
        {
            // When the button is pressed, the scene is changed to a main memnu.
            SceneManager.LoadScene(0);
        }

        private void ShowTitleScreen()
        {
            if (titleScreen != null) titleScreen.SetActive(true);
            if (gameOverPanelOne != null) gameOverPanelOne.SetActive(false);
            if (gameOverPanelTwo != null) gameOverPanelTwo.SetActive(false);
        }
    }
}
