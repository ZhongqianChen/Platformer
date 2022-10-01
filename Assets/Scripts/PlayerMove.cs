using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    public AudioClip t_Audio;

    private void Start()
    {

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = t_Audio;

    }

    private void Awake()
    {

        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
        {

            transform.localScale = new Vector3(7, 7, 1);

        }

        else if (horizontalInput < -0.01f)
        {

            transform.localScale = new Vector3(-7, 7, 1);

        }

        if (Input.GetKey(KeyCode.W) && isGrounded())
        {

            Jump();

        }

        anim.SetBool("Walk", horizontalInput != 0);
        anim.SetBool("Grounded", isGrounded());

    }

    private void Jump()
    {

        body.velocity = new Vector2(body.velocity.x, speed);

        GetComponent<AudioSource>().Play();

        anim.SetTrigger("Jump");

    }

    private bool isGrounded()
    {

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;

    }

    public bool canAttack()
    {

        float horizontalInput = Input.GetAxis("Horizontal");

        return horizontalInput == 0 && isGrounded();

    }

}
