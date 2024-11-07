using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] batons;
    [SerializeField] private AudioClip batonSound;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(batonSound);
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        batons[FindBaton()].transform.position = firePoint.position;
        batons[FindBaton()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindBaton()
    {
        for (int i = 0; i < batons.Length; i++)
        {
            if (!batons[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}