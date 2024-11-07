using UnityEngine;

public class BatonCollect : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    private PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with the item
        if (collision.CompareTag("Player"))
        {
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
        
        playerMovement.EnableAttack();

        // Destroy the item to make it disappear
        Destroy(gameObject);
    }
}
