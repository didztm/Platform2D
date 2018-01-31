using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed = 6f;
    public float jumpForce = 300f;
    public LayerMask whatIsGround;
    [HideInInspector]
    public bool lookingRight = true;
    private Animator cloudanim;
    public GameObject Cloud;
    private Rigidbody2D rb2d;
    private Animator anim;
    public bool isGrounded = false;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 10)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0.0f);
            rb2d.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
        }

    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(rb2d.position, Vector3.zero + new Vector3(0, -0.3f, 0), Color.red);
        if (Physics2D.Raycast(rb2d.position, Vector3.down, 0.3f, whatIsGround))
        {
            isGrounded = true;
        }

    }


    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(hor));

        rb2d.velocity = new Vector2(hor * maxSpeed, rb2d.velocity.y);


        anim.SetBool("IsGrounded", isGrounded);

        if ((hor > 0 && !lookingRight) || (hor < 0 && lookingRight))
            Flip();

        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
    }



    public void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;
    }

}
