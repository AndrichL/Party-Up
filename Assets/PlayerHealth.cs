using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int totalHealth = 100;
    [SerializeField] int currentHealth;

    [SerializeField] ParticleSystem vfxPrefab;
    [SerializeField] ParticleSystem vfxPrefab2;

    private void Start()
    {
        currentHealth = totalHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        vfxPrefab.Play();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    { //elke functie die gebeurd na de player dood gaat; 
        this.gameObject.SetActive(false);
        vfxPrefab2.Play();
    }

}
