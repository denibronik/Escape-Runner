using System.Collections;
using UnityEngine;

public class LaserTrap01 : MonoBehaviour
{
    [SerializeField] private float onDuration = 3f;  // Duration the laser is on
    [SerializeField] private float offDuration = 3f; // Duration the laser is off
    [SerializeField] private float damage = 1f;     // Damage to the player

    private Collider2D laserCollider;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioClip laserSound;

    private void Awake()
    {
        laserCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(LaserCycle());
    }

    private IEnumerator LaserCycle()
    {
        while (true)
        {
            laserCollider.enabled = false;
            spriteRenderer.enabled = false;
            

            yield return new WaitForSeconds(offDuration);

            laserCollider.enabled = true;
            spriteRenderer.enabled = true;
            SoundManager2.instance.PlaySound(laserSound);

            yield return new WaitForSeconds(onDuration);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && laserCollider.enabled)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
