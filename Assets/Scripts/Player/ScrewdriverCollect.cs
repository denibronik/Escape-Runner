using UnityEngine;

public class ScrewdriverCollect : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    private PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with the item
        if (collision.CompareTag("Player"))
        {
            // Get the PlayerMovement component from the player on collision
            playerMovement = collision.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                CollectItem();
                SoundManager.instance.PlaySound(collectSound);
            }
            else
            {
                Debug.LogWarning("PlayerMovement component not found on the player object.");
            }
        }
    }

    private void CollectItem()
{
    // Notify the GameManager
    GameManager.instance.CollectScrewdriver();

    // Enable vents in the current scene
    VentTeleport[] allVents = FindObjectsOfType<VentTeleport>();
    foreach (VentTeleport vent in allVents)
    {
        vent.EnableVents();
    }

    // Play sound and destroy screwdriver object
    SoundManager.instance.PlaySound(collectSound);
    Destroy(gameObject);
}

}
