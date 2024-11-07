
using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 3;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 3;
    }

public void InitializeHealthbar()
    {
        if (playerHealth != null)
        {
            totalhealthBar.fillAmount = playerHealth.startingHealth / playerHealth.startingHealth;
            currenthealthBar.fillAmount = playerHealth.currentHealth / playerHealth.startingHealth;
        }
    }

    public void SetPlayerHealth(Health health)
    {
        playerHealth = health;
        InitializeHealthbar();
    }
}
