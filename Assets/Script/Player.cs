using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float jumpHight = 5f;
    private float movement = 0f;
    public float moveSpeed = 5f;
    public bool isGround = true;
    private bool facingRight = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        if (movement < 0f && facingRight)
        {
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
            facingRight = false;
        }
        else if (movement > 0f && facingRight == false)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            facingRight = true;
        }
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            Jump();
            isGround = false;
            animator.SetBool("Jump", true);
        }
        if (Mathf.Abs(movement) > .1f)
        {
            animator.SetFloat("Run", 1f);
        }else if(movement < .1f)
        {
            animator.SetFloat("Run", 0f);
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(movement, 0f, 0f) * Time.fixedDeltaTime * moveSpeed;


    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpHight), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            Debug.Log(collision.gameObject.name);
            animator.SetBool("Jump", false);
        }
        

    }
}
