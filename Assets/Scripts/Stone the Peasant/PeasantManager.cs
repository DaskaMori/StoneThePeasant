using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;


public class PeasantManager : MonoBehaviour
{
    public AudioManager audioManager;
    public int peasantHealth = 50;
    public bool peasantPhase2;
    public TextMeshProUGUI peasantHealthText;
    public GameObject player;
    public GameObject peasantPlane;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        // start phase 1 attacks, these chain until health is below half and then turn into a chain of phase 2 attacks
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.x = 0; // Lock X rotation
        transform.eulerAngles = eulerAngles;

        if (peasantHealth < 26 && !peasantPhase2)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            audioManager.ChangeAudio();
            peasantPhase2 = true;
        }
        
        if (peasantHealth < 1)
        {
            Destroy(self);
        }
        peasantHealthText.text = "Peasant Health: " + peasantHealth.ToString();
    }


}
