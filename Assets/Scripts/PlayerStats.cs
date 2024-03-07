using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{

    // Stats of Anya
    [SerializeField] public float camoTime;
    [SerializeField] public int health;
    [SerializeField] public int speed;
    [SerializeField] public int attackDamage;
    [SerializeField] public float knockBack;
    [SerializeField] public bool isDead;

    // When HUD updates, wanna display stats increase
    public TextMeshProUGUI camoFlaretext;
    public TextMeshProUGUI HealthFlaretext;
    public TextMeshProUGUI SPDFlaretext;
    public TextMeshProUGUI ADFlaretext;
    public TextMeshProUGUI KBFlaretext;

    public float flareDuration;

    private PlayerHUD hud;

    public FullPlayerControl camoCheck;

    public float MIN_CAMO_TIMER = 0f;

    // Variables to make player red when losing HP
    public Renderer playerRenderer;
    public Color damageColor = new Color(0.97f, 0.50f, 0.50f);
    public float damageDuration = 0.1f;

    private Color originalColor;

    private void Start()
    {
        // GameObject in unity, upon launch, is set to all 0s
        if (speed == 0)
        {
            InitVariables();

            // Runs one time, upon launch, I hope, at least it used to
            if (!StatsManager.Instance.gameHasStarted)
            {
                StatsManager.Instance.globalCamoTime = camoTime;
                StatsManager.Instance.globalHealth = health;
                StatsManager.Instance.globalSpeed = speed;
                StatsManager.Instance.globalAttackDamage = attackDamage;
                StatsManager.Instance.globalKnockBack = knockBack;
                StatsManager.Instance.globalIsDead = isDead;
                StatsManager.Instance.gameHasStarted = true;
            }

        }
        else
        {
            
        }
        hud = GetComponent<PlayerHUD>();
        originalColor = playerRenderer.material.color;
        camoFlaretext.gameObject.SetActive(false);
        HealthFlaretext.gameObject.SetActive(false);
        SPDFlaretext.gameObject.SetActive(false);
        ADFlaretext.gameObject.SetActive(false);
        KBFlaretext.gameObject.SetActive(false);
    }


    private void Update()
    {

        
        // If player is camo, must lower Camo time
        if (camoCheck.isCurrentlyCamo)
        {
            this.camoTime -= Time.deltaTime;
            StatsManager.Instance.globalCamoTime -= Time.deltaTime;
            if (camoTime < MIN_CAMO_TIMER)
            {
                Debug.Log("answer");
                camoCheck.showPlayer();
            }
            hud.UpdateCamoTime(camoTime);
        }
        else
        {
            checkIfStatsNeedUpdate();
            hud.UpdateHealth(camoTime, health, attackDamage, speed, knockBack);
        }
    }

    // When player gets damaged
    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("No negative damage");
        }
        ShowFlare(false, 1, amount);
        this.health -= amount;
        StatsManager.Instance.globalHealth -= amount;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(FlashColor());
        }
    }
    private IEnumerator FlashColor() // helps damage function above
    {
        playerRenderer.material.color = damageColor;

        yield return new WaitForSeconds(damageDuration);

        playerRenderer.material.color = originalColor;
    }
    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("No negative healing");
        }
        ShowFlare(true, 1, amount);
        this.health += amount;

    }

    // Attack Damage Functions
    public void IncreaseAD(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("No negative AD increase");
        }
        ShowFlare(true, 3, amount);
        this.attackDamage += amount;
        StatsManager.Instance.globalAttackDamage += amount;
    }
    public void DecreaseAD(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("No negative AD decrease");
        }
        if (attackDamage - amount < 1)
        {
            this.attackDamage = 1;
            StatsManager.Instance.globalAttackDamage = 1;
        }
        else
        {
            ShowFlare(false, 3, amount);
            this.attackDamage -= amount;
            StatsManager.Instance.globalAttackDamage -= amount;
        }
    }

    // Speed Functions
    public void IncreaseSpeed(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("No negative speed increase");
        }
        ShowFlare(true, 2, amount);
        this.speed += amount;
        StatsManager.Instance.globalSpeed += amount;
    }
    public void DecreaseSpeed(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("No negative speed decrease");
        }
        if (speed - amount < 5)
        {
            this.speed = 5;
            StatsManager.Instance.globalSpeed = 5;
        }
        else
        {
            ShowFlare(false, 2, amount);
            this.speed -= amount;
            StatsManager.Instance.globalSpeed -= amount;
        }
    }

    // Knockback Functions
    public void IncreaseKnockBack(float amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("No negative KO increase");
        }
        ShowFlareFloat(true, 5, amount);
        this.knockBack += amount;
        StatsManager.Instance.globalKnockBack += amount;
    }
    public void DecreaseKnockBack(float amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("No negative KO decrease");
        }
        if (speed - amount < 1)
        {
            this.speed = 1;
        }
        ShowFlareFloat(false, 5, amount);
        this.knockBack -= amount;
        StatsManager.Instance.globalKnockBack -= amount;
    }

    // Camo Functions
    public void IncreaseCamo(float amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("No negative Camo increase");
        }
        ShowFlareFloat(true, 4, amount);
        this.camoTime += amount;
        StatsManager.Instance.globalCamoTime += amount;
    }
    public void DecreaseCamo(float amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("No negative Camo decrease");
        }
        if (camoTime - amount < 0)
        {
            this.camoTime = 0;
            StatsManager.Instance.globalCamoTime = 0;
            ShowFlareFloat(false, 4, camoTime-amount);
        }
        else
        {
            this.camoTime -= amount;
            StatsManager.Instance.globalCamoTime -= amount;
            ShowFlareFloat(false, 4, amount);
        }
        
    }

    // Flare for stats that are of 'int' type
    public void ShowFlare(bool pos, int index, int amount)
    {
        if (index == 1)
        {
            if (pos)
            {
                HealthFlaretext.text = "+" + amount.ToString();
                HealthFlaretext.gameObject.SetActive(true);
                StartCoroutine(HideFlareAfterDelay(flareDuration, index));
            } else
            {
                HealthFlaretext.text = "-" + amount.ToString();
                HealthFlaretext.gameObject.SetActive(true);
                StartCoroutine(HideFlareAfterDelay(flareDuration, index));
            }
            
        }
        else if (index == 2)
        {
            if (pos)
            {
                SPDFlaretext.text = "+" + amount.ToString();
                SPDFlaretext.gameObject.SetActive(true);
                StartCoroutine(HideFlareAfterDelay(flareDuration, index));
            }
            else
            {
                SPDFlaretext.text = "-" + amount.ToString();
                SPDFlaretext.gameObject.SetActive(true);
                StartCoroutine(HideFlareAfterDelay(flareDuration, index));
            }
        }
        else if (index == 3)
        {
            if (pos)
            {
                ADFlaretext.text = "+" + amount.ToString();
                ADFlaretext.gameObject.SetActive(true);
                StartCoroutine(HideFlareAfterDelay(flareDuration, index));
            }
            else
            {
                ADFlaretext.text = "-" + amount.ToString();
                ADFlaretext.gameObject.SetActive(true);
                StartCoroutine(HideFlareAfterDelay(flareDuration, index));
            }
        }
        else
        {
            Debug.Log("Invalid flare index");
            return;
        }
    }
    IEnumerator HideFlareAfterDelay(float delay, int index)
    {
        // Want to hide flare after a delay
        yield return new WaitForSeconds(delay);
        HideFlare(index);
    }
    public void HideFlare(int index)
    {
        if (index == 1)
        {
            HealthFlaretext.gameObject.SetActive(false);
        }
        else if (index == 2)
        {
            SPDFlaretext.gameObject.SetActive(false);
        }
        else if (index == 3)
        {
            ADFlaretext.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Invalid hide flare index");
            return;
        }
    }

    // Flare for stats that are of 'float' type
    public void ShowFlareFloat(bool pos, int index, float amount)
    {
        if (index == 4)
        {
            if (pos)
            {
                camoFlaretext.text = "+" + amount.ToString("F2");
                camoFlaretext.gameObject.SetActive(true);
                StartCoroutine(HideFlareAfterDelayFloat(flareDuration, index));
            }
            else
            {
                camoFlaretext.text = "-" + amount.ToString("F2");
                camoFlaretext.gameObject.SetActive(true);
                StartCoroutine(HideFlareAfterDelay(flareDuration, index));
            }

        }
        else if (index == 5)
        {
            if (pos)
            {
                KBFlaretext.text = "+" + amount.ToString("F1");
                KBFlaretext.gameObject.SetActive(true);
                StartCoroutine(HideFlareAfterDelayFloat(flareDuration, index));
            }
            else
            {
                KBFlaretext.text = "-" + amount.ToString("F1");
                KBFlaretext.gameObject.SetActive(true);
                StartCoroutine(HideFlareAfterDelayFloat(flareDuration, index));
            }
        }
        else
        {
            Debug.Log("Invalid flare float index");
            return;
        }
    }
    IEnumerator HideFlareAfterDelayFloat(float delay, int index)
    {
        // Want to hide flare after a delay
        yield return new WaitForSeconds(delay);
        HideFlareFloat(index);
    }
    public void HideFlareFloat(int index)
    {
        if (index == 4)
        {
            camoFlaretext.gameObject.SetActive(false);
        }
        else if (index == 5)
        {
            KBFlaretext.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Invalid hide float flare index");
            return;
        }
    }

    public void InitVariables()
    {
        this.camoTime = 10.00f;
        //this.canCamo = true;
        this.health = 30;
        this.speed = 40;
        this.attackDamage = 1;
        this.knockBack = 1f;
        this.isDead = false;
        this.flareDuration = 1f;
    }


    private void Die()
    {
        Debug.Log("Perished");
        isDead = true;
        Destroy(gameObject);
    }

    private void checkIfStatsNeedUpdate()
    {
        if ((this.camoTime != StatsManager.Instance.globalCamoTime) ||
        (this.health != StatsManager.Instance.globalHealth) ||
        (this.speed != StatsManager.Instance.globalSpeed) ||
        (this.attackDamage != StatsManager.Instance.globalAttackDamage) ||
        (this.knockBack != StatsManager.Instance.globalKnockBack) ||
        (this.isDead != StatsManager.Instance.globalIsDead))
        {
            ChangeOnSceneSwitch();
        }
    }

    private void ChangeOnSceneSwitch()
    {
        Debug.Log("ChangeOnSceneSwitch");
        this.camoTime = StatsManager.Instance.globalCamoTime;
        this.health = StatsManager.Instance.globalHealth;
        this.speed = StatsManager.Instance.globalSpeed;
        this.attackDamage = StatsManager.Instance.globalAttackDamage;
        this.knockBack = StatsManager.Instance.globalKnockBack;
        this.isDead = StatsManager.Instance.globalIsDead;
    }
}
