using UnityEngine;
using System.Collections;
public class keyboardController : MonoBehaviour {
	public float moveSpeed = 50f;
    public float maxSpeed = 3f;
    public float jumpHeight;

    public bool facingRight = true;
    public bool canJump = true;

    public AudioClip jumpsound;
    public AudioClip powerup;

    public int maxHealth = 5;
    public int currentHealth;

    private Rigidbody2D rb2d;
    private Animator anim;

    /*
    public void SetColliderForSprite( int spriteNum )
	{
		colliders[currentColliderIndex].enabled = false;
		currentColliderIndex = spriteNum;
		colliders[currentColliderIndex].enabled = true;
	}
	private PolygonCollider2D[] colliders;
	private int currentColliderIndex = 0;
    */
	void Start ()
	{
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        currentHealth = maxHealth;
	}

	void Update ()
    {
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            die();
        }
	}

    void FixedUpdate()
    {
        /*
        float h = Input.GetAxis("Horizontal");

        if (h < 0)
        {
            transform.Translate(new Vector3(-moveSpeed, 0, 0));
            if (facingRight)
            {
                Flip();
            }
        }
        if (h > 0)
        {
            transform.Translate(new Vector3(moveSpeed, 0, 0));
            if (!facingRight)
            {
                Flip();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb2d.AddForce(Vector2.up * jumpHeight);
            gameObject.GetComponent<AudioSource>().PlayOneShot(jumpsound);
            canJump = false;
        }
        */
        float h = Input.GetAxis("Horizontal");

        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveSpeed);
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }

        if (h > 0 && !facingRight)
        {
            Flip();
        }

        if (h < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb2d.AddForce(Vector2.up * jumpHeight);
            gameObject.GetComponent<AudioSource>().PlayOneShot(jumpsound);
            canJump = false;
        }

    }

    void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        gameObject.GetComponent<Animation>().Play("DamageFlash");
    }

    public IEnumerator knockback(float knockDuration, float knockbackPower, Vector3 knockbackDirection)
    {
        float timer = 0;

        while (knockDuration > timer)
        {
            timer += Time.deltaTime;

            rb2d.AddForce(new Vector3(knockbackDirection.x * -100, knockbackDirection.y * knockbackPower, transform.position.z));
        }
        yield return 0;
    }

    void die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "ground")
        {
            canJump = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "burger")
        {
            Destroy(col.gameObject);
            gameObject.GetComponent<AudioSource>().PlayOneShot(powerup);
            currentHealth += 1;
        }
    }
}