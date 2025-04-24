using UnityEngine;

namespace MedievalMayhem.Scripts
{
    public class Target : MonoBehaviour
    {
        [Header("Target Sprites")]
        public Sprite healthySprite;
        public Sprite injuredSprite;
        
        [Header("Target Settings")]
        public bool isActive = true;
        public float visibleDuration = 3.0f;  
        public float spawnTime = 0.2f;          
        public int pointValue = 1;
        public float injuredDisplayTime = 0.2f;
        
        private SpriteRenderer spriteRenderer;
        
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (healthySprite != null)
            {
                spriteRenderer.sprite = healthySprite;
            }
        }

        void Update()
        {
            if (Time.time - spawnTime > visibleDuration)
            {
                isActive = false;
                Destroy(gameObject);
            }
        }

    
        public void Hit()
        {
            if (injuredSprite != null)
            {
                spriteRenderer.sprite = injuredSprite;
            }

            isActive = false;
            
            if (AudioManagerMm.Instance != null)
                AudioManagerMm.Instance.PlaySfx(AudioManagerMm.Instance.targetHitClip);
            StartCoroutine(DestroyAfterInjured());
        }

        private System.Collections.IEnumerator DestroyAfterInjured()
        {
            yield return new WaitForSeconds(injuredDisplayTime);
            Destroy(gameObject);
        }
    } 
}

