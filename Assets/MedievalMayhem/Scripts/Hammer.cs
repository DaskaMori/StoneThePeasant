using System.Collections;
using UnityEngine;

namespace MedievalMayhem.Scripts
{
    public class Hammer : MonoBehaviour
    {
        [Header("Hammer Animation Sprites")] 
        public Sprite idleSprite;
        public Sprite smashFrame1;
        public Sprite smashFrame2;

        [Header("Hammer Settings")]
        public float animationSpeed = 0.1f;
        public float smashRadius = 0.2f;
        public LayerMask targetLayer;
        public GameManagerMm gameManager;

        private SpriteRenderer spriteRenderer;
        private bool isSmashing = false;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        void Update()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 1.0f;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = worldPos;

            if (Input.GetKeyDown(KeyCode.Space) && !isSmashing)
            {
                StartCoroutine(SmashRoutine());
            }
        }

        private IEnumerator SmashRoutine()
        {
            isSmashing = true;

            if (smashFrame1 != null)
                spriteRenderer.sprite = smashFrame1;
            yield return new WaitForSeconds(animationSpeed);

            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, smashRadius, targetLayer);
            Debug.Log("Hits detected: " + hits.Length);
            bool hitSomething = false;
            
            foreach (Collider2D hit in hits)
            {
                Target target = hit.GetComponent<Target>();
                if (target != null && target.isActive)
                {
                    target.Hit();
                    if (gameManager != null)
                        gameManager.IncreaseScore(target.pointValue); 
                    
                    hitSomething = true;
                }
            }
            
            if (AudioManagerMm.Instance != null)
            {
                if (hitSomething)
                    AudioManagerMm.Instance.PlaySfx(AudioManagerMm.Instance.hammerSmashClip);
                else
                    AudioManagerMm.Instance.PlaySfx(AudioManagerMm.Instance.hammerMissClip);
                
            }

            if (smashFrame2 != null)
                spriteRenderer.sprite = smashFrame2;
            yield return new WaitForSeconds(animationSpeed);

            if (!hitSomething)
            {
                yield return new WaitForSeconds(2f);
            }

            if (idleSprite != null)
                spriteRenderer.sprite = idleSprite;

            isSmashing = false;
            
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, smashRadius);
        }
    }
}
