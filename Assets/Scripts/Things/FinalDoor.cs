using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    private bool isPlayerNear = false;

    private void Update()
    {
        // Check if the player is near and presses "E"
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            // Call the UIManager to show the Next Level Screen
            UIManager.Instance.ShowNextLevelScreen();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detect if the player is near the door
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Detect if the player leaves the door area
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
