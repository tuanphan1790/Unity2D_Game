using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float moveForce = 20f;
    public float jumpForce = 700f;
    public float maxVelocity = 4f;

    private bool grounded;

    private Rigidbody2D myBody;
    private Animator anim;

    private bool moveLeft, moveRight;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Nếu ko gán sự kiện click ở bên ngoài thì có thể tạo sự kiện ở đây
        //GameObject.Find("Button Jump").GetComponent<Button>().onClick.AddListener(() => Jump());
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerWalkKeyBoard();
        //PlayWalkJoystick();
    }

    public void SetMoveRight(bool set)
    {
        moveRight = set;
        moveLeft = !set;
    }

    public void SetMoveLeft(bool set)
    {
        moveLeft = set;
        moveRight = !set;
    }

    public void StopMoving()
    {
        moveRight = false;
        moveLeft = false;
    }

    void PlayWalkJoystick()
    {
        float forceX = 0f;

        float nowVel = Mathf.Abs(myBody.velocity.x);
        if (moveRight)
        {
            if (nowVel < maxVelocity)
            {
                if (grounded)
                    forceX = moveForce;
                else
                {
                    forceX = moveForce * 1.1f;
                }
            }

            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        }
        else if (moveLeft)
        {
            forceX = grounded ? -moveForce : -moveForce * 1.1f;

            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        myBody.AddForce(new Vector2(forceX, 0));
    }

    private void PlayerWalkKeyBoard()
    {
        float forceX = 0f;
        float forceY = 0f;

        float nowVel = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            if (nowVel < maxVelocity)
            {
                if (grounded)
                    forceX = moveForce;
                else
                {
                    forceX = moveForce * 1.1f;
                }
            }

            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        }
        else if (h < 0)
        {
            if (grounded)
                forceX = -moveForce;
            else
            {
                forceX = -moveForce * 1.1f;
            }

            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                forceY = jumpForce;
            }
        }

        myBody.AddForce(new Vector2(forceX, forceY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    public void BoucePlayerWithBouncy(float force)
    {
        if(grounded)
        {
            grounded = false;
            myBody.AddForce(new Vector2(0, force));
        }
    }

    public void Jump()
    {
        float forceY = 0f;

        if (grounded)
        {
            grounded = false;
            forceY = jumpForce;
        }

        myBody.AddForce(new Vector2(0, forceY));
    }
}
