using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKeycard : MonoBehaviour
{
    [Header("Keycard")]
    [SerializeField] private GameObject keycardPrefab;
    private Health health;
    private void Awake()
    
    {
        health = GetComponent<Health>();
    }


    void Update()
    {
        if (health.currentHealth <= 0 && keycardPrefab != null)
        {
            DropKeycard();
            enabled = false; // Disable this script to prevent multiple drops
        }
    }
    private void DropKeycard()
    {
        Instantiate(keycardPrefab, transform.position, Quaternion.identity);
    }
}
