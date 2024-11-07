using UnityEngine;

public class LeverController : MonoBehaviour
{
    public Sprite offSprite;
    public Sprite onSprite;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isOn = false;
    private bool playerNear = false;
    public DoorController door;
    [SerializeField] private AudioClip leverSound;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        UpdateLeverSprite();
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            ToggleLever();
            SoundManager.instance.PlaySound(leverSound);
        }
    }

    private void ToggleLever()
    {
        isOn = !isOn;
        animator.SetTrigger(isOn ? "TurnOn" : "TurnOff"); // Triggers the animation
        UpdateLeverSprite();
        door.ToggleDoor();
    }

    private void UpdateLeverSprite()
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
}
