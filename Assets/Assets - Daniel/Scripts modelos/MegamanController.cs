using UnityEngine;
using System.Collections;

public class MegamanController : MonoBehaviour {
    public bool onGround = false;
    public bool onWall = false;

    private float movementDuration = 0.0f;
    private float shootDuration = 1.0f;

    private float horizontalMovement;
    private float wallJumpXForce = 160;
    private float wallJumpYForce = 170;
    public int direction = 1;

    float speed = 70;
    Rigidbody2D rgbd2D;
    public Animator anim;
    private float shootDelay = 0.1f;
    private float shootTime;
    public int bulletCount = 3;

    public GameObject simpleBullet;
    public Transform gunEnd;


    void Awake()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Time.timeScale = 0.25f;
    }
		
    // Update is called once per frame
	void Update ()
    {
        Movement();
        Flip();
        Jump();
        Climb();
        Shoot();
	}

    void Movement()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("hSpeed", Mathf.Abs(horizontalMovement));

        //Mudancas feitas
        if (horizontalMovement == 0)
            movementDuration = 0.0f;
        if (Mathf.Abs(horizontalMovement) == 1)
            movementDuration += Time.deltaTime;

        anim.SetFloat("movementDuration", 2*movementDuration % 1.0f);


        rgbd2D.velocity = new Vector2(horizontalMovement * speed * Time.deltaTime, rgbd2D.velocity.y);

    }

    void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        direction = (int)transform.localScale.x;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (onWall)
            {
                rgbd2D.AddForce(new Vector2(wallJumpXForce, wallJumpYForce));
            }
            else if (onGround)
            {
                rgbd2D.AddForce(new Vector2(0, 170));
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && rgbd2D.velocity.y>0)
        {
            rgbd2D.velocity = new Vector2(rgbd2D.velocity.x, 0);
        }

        anim.SetFloat("vSpeed", rgbd2D.velocity.y);
    }

    void Shoot()
    {
        if (shootDuration > 0)
        shootDuration -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && Time.time >=shootTime && bulletCount>0)
        {
            shootTime = Time.time + shootDelay;
            Instantiate(simpleBullet, gunEnd.position, Quaternion.identity);
            bulletCount--;
            anim.SetBool("isShooting", true);
            shootDuration = 1;
        }

        if(shootDuration < 0)
            anim.SetBool("isShooting", false);

        anim.SetFloat("shootDuration", shootDuration);
    }

    void Climb()
    {
        if(onWall && horizontalMovement != 0 && rgbd2D.velocity.y<0)
        {
            rgbd2D.velocity = new Vector2(0, -30*Time.deltaTime);
            anim.SetBool("onWall", true);
            if (transform.localScale.x == -1)
                direction = 1;

            if (transform.localScale.x == 1)
                direction = -1;
        }
        else
            anim.SetBool("onWall", false);

    }
}
