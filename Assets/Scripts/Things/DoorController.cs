using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;
    private BoxCollider2D boxCollider;
    [SerializeField] private AudioClip openDoorSound;
    [SerializeField] private AudioClip closeDoorSound;


    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>(); // Get the BoxCollider2D component
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;  // Toggle the door's open/close state
        if (isOpen)
        {
            animator.SetTrigger("Open");
            SoundManager.instance.PlaySound(openDoorSound);
        }
        else
        {
            animator.SetTrigger("Close");
        }
        boxCollider.enabled = !isOpen; // Disable collider when the door is open, enable when closed
        SoundManager.instance.PlaySound(closeDoorSound);

    }
}
