using UnityEngine;
using System.Collections;

namespace Main_Menu
{
    public class CreditsManager : MonoBehaviour
    {
        [Header("Scene objects")]
        [SerializeField] GameObject mainMenuCanvas; 
        [SerializeField] GameObject gameScoreCanvas;
        [SerializeField] GameObject creditsCanvas;       
        [SerializeField] RectTransform creditsContent; 
        
        [Header("Scrolling")]
        [SerializeField] float scrollSpeed = 100f;     
        [SerializeField] float pauseAtEnd = 1f;       
        
        Vector2 startPos;
        float endY;
        Coroutine scrollRoutine;

        void Awake()
        {
            startPos = creditsContent.anchoredPosition;

            float viewportHeight = ((RectTransform)creditsContent.parent).rect.height;
            endY = creditsContent.rect.height + viewportHeight;
        }
        
        public void ShowCredits()
        {
            mainMenuCanvas.SetActive(false);
            gameScoreCanvas.SetActive(false);
            creditsCanvas.SetActive(true);

            creditsContent.anchoredPosition = startPos;
            scrollRoutine = StartCoroutine(ScrollCredits());
        }
        public void ReturnToMenu()
        {
            if (scrollRoutine != null) StopCoroutine(scrollRoutine);

            creditsCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
            gameScoreCanvas.SetActive(true);
        }

        IEnumerator ScrollCredits()
        {
            while (creditsContent.anchoredPosition.y < endY)
            {
                creditsContent.anchoredPosition += Vector2.up * (scrollSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(pauseAtEnd);
            ReturnToMenu();
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
