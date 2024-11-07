using UnityEngine;

public class KeypadController : MonoBehaviour
{
    public Sprite offSprite;
    public Sprite onSprite;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isOn = false;
    private bool playerNear = false;
    public DoorController door;

    [SerializeField] private AudioClip approveSound;
    [SerializeField] private AudioClip rejectSound;
    
    public bool KeycardIsObtained = false; // Placeholder for keycard status, update this later

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        UpdateKeypadSprite();
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            TryToggleDoor();
        }
    }

    private void TryToggleDoor()
    {
        if (KeycardIsObtained)
        {
            isOn = true;
            animator.SetTrigger("Approve"); // Trigger "Approve" if keycard is obtained
            UpdateKeypadSprite();
            door.ToggleDoor(); // Open the door
            SoundManager.instance.PlaySound(approveSound);
        }
        else
        {
            animator.SetTrigger("Reject"); // Trigger "Reject" if keycard is not obtained
            Debug.Log("Access Denied: Keycard required.");
            SoundManager.instance.PlaySound(rejectSound);
        }
    }

    private void UpdateKeypadSprite()
    {
        spriteRenderer.sprite = isOn ? onSprite : offSprite;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
        }
    }

    public void ObtainKeycard()
    {
        KeycardIsObtained = true;
        Debug.Log("Keycard obtained");
    }
}
