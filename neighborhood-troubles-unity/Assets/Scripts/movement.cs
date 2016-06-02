using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public float speed = 3.0f;
	public float pacelength = 2.0f;
	public float origX;

    private bool facingRight = true;

    private keyboardController player;
	
    // Use this for initialization
	void Start ()
	{
		origX = transform.position.x;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<keyboardController>();
	}
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(speed * Time.deltaTime, 0, 0);
		if(Mathf.Abs(origX - transform.position.x) > pacelength)
		{
			speed *= -1.0f; //change direction
            transform.position = new Vector3(transform.position.x + 2 * speed * Time.deltaTime, transform.position.y, transform.position.z);
            Flip();
            /*
            if (speed < 0 && facingRight)
            {
                Flip();
            }
            if (speed > 0 && !facingRight)
            {
                Flip();
            }
            */
		}
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.takeDamage(1);

            StartCoroutine(player.knockback(0.02f, 50, player.transform.position));
        }
    }
}
