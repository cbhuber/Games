using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour {

    public Collider2D attackTrigger;

    private Animator anim;

    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCooldown = 0.3f;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }
	
	// Update is called once per frame
	void Update()
    {

	    if (Input.GetKeyDown(KeyCode.C) && !attacking)
        {
            attacking = true;
            attackTimer = attackCooldown;

            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }

        anim.SetBool("Attack", attacking);
	}
}
