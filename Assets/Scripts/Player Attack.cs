using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator; // to reference animator

    private GameObject attackArea = default; // Area in front of player to attack

    private bool attacking = false; 

    private float timeToAttack = 0.15f; 

    private float timer = 0f; 

    private float punchTime = 0f;

    private float punchTimeEnd = 0.2f;

    private bool punchTimerRunning = false;

    private float pastX = 1f;

    private float currX = 0f;

    [SerializeField] private Transform BigAttackArea;

    public float temptemp;



    private void Awake()
    {
        // Get punch animation
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused) return;
            
        
        // Attack animation is either left or right
        currX = animator.GetFloat("moveX");

        // Setting attack hit box to left
        if (pastX >= 0 && currX < 0)
        {
            pastX = -1;
            Vector3 temp = new Vector3(-2.8f, 0, 0);
            BigAttackArea.transform.position += temp;

        }
        // Setting attack hit box to right
        else if (pastX <= 0 && currX > 0)
        {
            pastX = 1;
            Vector3 temp = new Vector3(2.8f, 0, 0);
            BigAttackArea.transform.position += temp;
        }
        
        // punchTime keeps track of punch animation
        if (punchTimerRunning)
        {
            punchTime += Time.deltaTime;
            if (punchTime > punchTimeEnd)
            {
                animator.SetBool("isPunch", false);
                punchTime = 0;
                punchTimerRunning = false;
            }
        }

        // Attack button is space bar
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isPunch", true);
            punchTimerRunning = true;
            punchTime = 0;
            Attack();
        }

        // If attack timer exceeds, 
        if(attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);

    }
}
