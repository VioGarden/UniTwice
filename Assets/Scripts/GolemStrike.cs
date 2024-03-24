using System.Collections;
using UnityEngine;

public class GolemStrike : MonoBehaviour
{

    public Collider2D playerCollider;
    public Collider2D playerCamoCollider;

    public GameObject[] attackAreas;

    public float blinkDuration = 1f;
    public float blinkInterval = 0.5f;
    public int maxBlinkCount = 3;
    public float damageAmount = 10f;

    Color red1 = new Color(0.98f, 0.718f, 0.718f, 0.3f);
    Color red2 = new Color(1f, 0.18f, 0.18f, 0.5f);

    Color transparent = new Color(0f, 0f, 0f, 0f);

    public GolemStats gStats;
    public PlayerStats pStats;

    public bool setCoroutine;
    public bool currCoroutine;

    IEnumerator co;

    private void Start()
    {
        attackAreas = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            attackAreas[i] = transform.GetChild(i).gameObject;
            attackAreas[i].SetActive(false);
        }
        setCoroutine = false;
        currCoroutine = false;

        co = AttackRoutine();
    }

    private void Update()
    {
        if (setCoroutine && !currCoroutine)
        {
            Debug.Log("start coroutine");
            StartCoroutine(co);
            currCoroutine = true;
        }
        else if (!setCoroutine && currCoroutine)
        {
            Debug.Log("stop coroutine");
            StopCoroutine(co);
            currCoroutine = false;
        }
    }

    private IEnumerator AttackRoutine()
    {
        while (true)  // Continuously loop the attack routine
        {
            // Select a random attack area
            int randomIndex = Random.Range(0, attackAreas.Length);
            GameObject selectedArea = attackAreas[randomIndex];
            Color originalColor = selectedArea.GetComponent<Renderer>().material.color;
            Color colorWithOpacity = new Color(originalColor.r, originalColor.g, originalColor.b, 0.1f);

            // Show the attack area

            Collider2D lodgeCollider = selectedArea.GetComponent<Collider2D>();

            // Timer to track elapsed time
            float timer = 0f;
            float colliderTimer = 0f;

            //selectedArea.SetActive(true);
            //Debug.Log("showing");
            //Debug.Log(selectedArea);

            selectedArea.SetActive(true);
            selectedArea.GetComponent<Renderer>().material.color = transparent;

            while (timer < 4.5f)  // Wait for 4.5 seconds
            {
                // Change color to red at the 2nd second
                if ((0.02f <= timer && timer <= 0.12f) || (1f <= timer && timer <= 1.1f) || (2f <= timer && timer <= 2.1f))
                {
                    selectedArea.GetComponent<Renderer>().material.color = red1;
                }
                else if ((0.5f <= timer && timer <= 0.6f) || (1.5f <= timer && timer <= 1.6f) || (2.5f <= timer && timer <= 2.6f)) {
                    selectedArea.GetComponent<Renderer>().material.color = colorWithOpacity;
                }
                else if (timer >= 3f)
                {
                    selectedArea.GetComponent<Renderer>().material.color = red2;
                    if (lodgeCollider.IsTouching(playerCollider))
                    {
                        colliderTimer += Time.deltaTime;
                        if (colliderTimer >= 0.2f)
                        {
                            DealDamageToPlayer();
                            colliderTimer = 0f;
                        }
                    }
                }
                timer += Time.deltaTime;  // Increment timer based on real time
                yield return null;  // Wait for the next frame
            }

            // Hide the attack area
            selectedArea.SetActive(false);

            setCoroutine = false;
            gStats.golemSpeed = 5;
        }
    }



    private void DealDamageToPlayer()
    {
        // You can implement your logic here to deal damage to the player
        pStats.Damage(gStats.golemLodgeDamage);
    }
}
