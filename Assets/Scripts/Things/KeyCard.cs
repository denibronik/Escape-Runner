using UnityEngine;

public class KeyCard : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    private PlayerMovement playerMovement;
    private KeypadController keypad;

    private void Start()
    {
        // Find the KeypadController in the scene when the keycard is instantiated
        keypad = FindObjectOfType<KeypadController>();
        if (keypad == null)
        {
            Debug.LogError("KeypadController not found in the scene.");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMovement = collision.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                CollectCard();
                SoundManager.instance.PlaySound(collectSound);
            }
            else
            {
                Debug.LogWarning("PlayerMovement component not found on the player object.");
            }
        }
    }

    private void CollectCard()
    {
        if (keypad != null)
        {
            keypad.ObtainKeycard();
        }
        
        Destroy(gameObject);
    }
}
