using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemStats : MonoBehaviour
{
    [SerializeField] public int golemHealth;
    [SerializeField] public int golemMaxHealth;
    [SerializeField] public int golemAttackDamage;
    [SerializeField] public int golemSpeed;

    [SerializeField] floatingHealthBar healthBar;

    public PlayerStats stats;

    public Renderer monsterRenderer;

    // When damaged, flash red
    public Color damageColor = new Color(253f, 100f, 99f);
    public float damageDuration = 0.1f;
    private Color originalColor;

    private void Awake()
    {
        healthBar = GetComponentInChildren<floatingHealthBar>();
    }

    void Start()
    {
        InitVariablesGolem();
    }

    private IEnumerator FlashColor()
    {
        // Change the color to damage color
        monsterRenderer.material.color = damageColor;

        // Wait for a short duration
        yield return new WaitForSeconds(damageDuration);

        // Revert back to the original color
        monsterRenderer.material.color = originalColor;
    }

    public void DamageGolem(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("No negative damage");
        }
        this.golemHealth -= amount;
        healthBar.UpdateHealthBar(golemHealth, golemMaxHealth);
        if (golemHealth <= 0)
        {
            ChooseBuffGolem();
            Die();
        }
        else
        {
            StartCoroutine(FlashColor());
        }
    }


    // When monster dies, player gets some buff
    public void ChooseBuffGolem()
    {
        int randomNumber = Random.Range(1, 6);

        // Execute the corresponding function based on the selected number
        switch (randomNumber)
        {
            case 1:
                IncreaseADRandomGolem();
                break;
            case 2:
                IncreaseHealthRandomGolem();
                break;
            case 3:
                IncreaseSpeedRandomGolem();
                break;
            case 4:
                IncreaseKnockBackRandomGolem();
                break;
            case 5:
                IncreaseCamoRandomGolem();
                break;
        }

    }

    private void IncreaseADRandomGolem()
    {
        int randomAD = Random.Range(50, 50);
        stats.IncreaseAD(randomAD);
    }

    private void IncreaseHealthRandomGolem()
    {
        int randomHealth = Random.Range(600, 600);
        stats.Heal(randomHealth);
    }

    private void IncreaseSpeedRandomGolem()
    {
        int randomSpeed = Random.Range(30, 30);
        stats.IncreaseSpeed(randomSpeed);
    }

    private void IncreaseKnockBackRandomGolem()
    {
        float randomKO = Random.Range(40f, 40f);
        stats.IncreaseKnockBack(randomKO);
    }

    private void IncreaseCamoRandomGolem()
    {
        float randomCamo = Random.Range(20f, 20f);
        stats.IncreaseCamo(randomCamo);
    }

    public void InitVariablesGolem()
    {
        this.golemHealth = 800;
        this.golemMaxHealth = 1000;
        this.golemAttackDamage = 5;
        this.golemSpeed = 5;
    }

    private void Die()
    {
        Debug.Log("Golem Perished");
        Destroy(gameObject);
    }

}
