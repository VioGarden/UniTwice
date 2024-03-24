using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    [SerializeField] public int monsterHealth;
    [SerializeField] public int monsterMaxHealth;
    [SerializeField] public int monsterAttackDamage;
    [SerializeField] public int monsterSpeed;
    [SerializeField] public int monsterType;

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
        if (monsterType == 0)
        {
            InitVariables1();
        }
        else if (monsterType == 1)
        {
            InitVariables2();
        }
        else
        {
            InitVariables0();
        }
        originalColor = monsterRenderer.material.color;
    }

    // Everytime monster takes damage
    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("No negative damage");
        }
        this.monsterHealth -= amount;
        healthBar.UpdateHealthBar(monsterHealth, monsterMaxHealth);
        if (monsterHealth <= 0)
        {
            ChooseBuff();
            Die();
        }
        else
        {
            StartCoroutine(FlashColor());
        }
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

    // When monster dies, player gets some buff
    public void ChooseBuff()
    {
        int randomNumber = Random.Range(1, 6);

        // Execute the corresponding function based on the selected number
        switch (randomNumber)
        {
            case 1:
                IncreaseADRandom();
                break;
            case 2:
                IncreaseHealthRandom();
                break;
            case 3:
                IncreaseSpeedRandom();
                break;
            case 4:
                IncreaseKnockBackRandom();
                break;
            case 5:
                IncreaseCamoRandom();
                break;
        }

    }

    private void IncreaseADRandom()
    {
        int randomAD = Random.Range(1, 3);
        stats.IncreaseAD(randomAD);
    }

    private void IncreaseHealthRandom()
    {
        int randomHealth = Random.Range(1, 5);
        stats.Heal(randomHealth);
    }

    private void IncreaseSpeedRandom()
    {
        int randomSpeed = Random.Range(1, 3);
        stats.IncreaseSpeed(randomSpeed);
    }

    private void IncreaseKnockBackRandom()
    {
        float randomKO = Random.Range(0.25f, 1.0f);
        stats.IncreaseKnockBack(randomKO);
    }

    private void IncreaseCamoRandom()
    {
        float randomCamo = Random.Range(0.25f, 1.0f);
        stats.IncreaseCamo(randomCamo);
    }

    public void InitVariables0()
    {
        this.monsterHealth = 1;
        this.monsterMaxHealth = 1;
        this.monsterAttackDamage = 1;
        this.monsterSpeed = 1;
        healthBar.UpdateHealthBar(1, 1);
    }

    public void InitVariables1()
    {
        this.monsterHealth = 50;
        this.monsterMaxHealth = 50;
        this.monsterAttackDamage = 2;
        this.monsterSpeed = 3;
        healthBar.UpdateHealthBar(50, 50);
    }

    public void InitVariables2()
    {
        this.monsterHealth = 80;
        this.monsterMaxHealth = 80;
        this.monsterAttackDamage = 3;
        this.monsterSpeed = 4;
        healthBar.UpdateHealthBar(80, 80);
    }



    private void Die()
    {
        Debug.Log("Monster Perished");
        Destroy(gameObject);
    }
}
