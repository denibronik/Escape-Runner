using UnityEngine;

public class VentTeleport : MonoBehaviour
{
    [SerializeField] private Transform targetVent;
    private bool isPlayerNear = false;
    private bool canTeleport = false;
    [SerializeField] private AudioClip ventSound;

    private void Start()
    {
        // Check if the screwdriver has been collected and enable the vent
        if (GameManager.instance != null && GameManager.instance.screwdriverCollected)
        {
            EnableVents();
        }
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && canTeleport)
        {
            TeleportPlayer();
            SoundManager.instance.PlaySound(ventSound);
        }
    }

    private void TeleportPlayer()
    {
        if (targetVent != null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                player.transform.position = targetVent.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    public void EnableVents()
    {
        canTeleport = true;
        Debug.Log("Vent enabled");
    }
}
