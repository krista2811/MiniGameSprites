using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float addForce = 50f;
    public float addUpForce = 400f;
    public float dashAmount = 0;
    public float fireRate;
    public GameObject shotPrefab;

    private bool canShoot = true;
    private Rigidbody2D rb2d;
    private bool isDead;
    private bool isJump;
    private bool isDown;
    private bool isRight;
    private bool isShoot;
    private bool isLeft;
    private bool isGround = true;
    private float nextFire;
    private Animator anim;

	// Use this for initialization
	void Start () {
		isDead = false;
		rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        if (GameController.instance.hits1 < 0)
        {
            canShoot = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (!isDead) {
            if (GameController.instance.hits1 < 0)
            {
                canShoot = false;
            }
            else if (GameController.instance.hits1 >= 0)
            {
                canShoot = true;
            }
            if (Input.GetKey (KeyCode.UpArrow)) {
                if (isGround)
                {
                    isJump = true;
                    isGround = false;
                }
			}
            if(Input.GetKey (KeyCode.RightArrow))
            {
                isRight = true;
            }
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                isLeft = true;
            }
            if(Input.GetKey(KeyCode.DownArrow))
            {
                isDown = true;
            }
            if (Input.GetKey(KeyCode.P) && Time.time > nextFire && canShoot)
            {
                nextFire = Time.time + fireRate;
                isShoot = true;
                GameController.instance.hits1--;
            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                dashAmount = 150f;
            }
            else if(Input.GetKey(KeyCode.RightShift) == false)
            {
                dashAmount = 0;
            }
		}
        if (GameController.instance.Player1Hp < 0)
        {
            GameController.instance.gameOver1 = true;
            GameController.instance.GameOver();
        }
	}

	void FixedUpdate() {
		Jump ();
        moveRight();
        moveLeft();
        Down();
        Shoot();
	}

	void Jump () {
		if (!isJump) {
			return;
		}
        rb2d.velocity = Vector2.zero;
		rb2d.AddForce (new Vector2 (0, addUpForce + dashAmount));
		isJump = false;
        anim.SetTrigger("jump");
    }

    void Down()
    {
        if (!isDown)
        {
            return;
        }
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(new Vector2(0, -addForce - dashAmount));
        isDown = false;
    }

    void moveRight ()
    {
        if(!isRight)
        {
            return;
        }
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        rb2d.AddForce(new Vector2(addForce + dashAmount, 0));
        isRight = false;
        anim.SetTrigger("walk");
        
    }

    void moveLeft()
    {
        if (!isLeft)
        {
            return;
        }
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        rb2d.AddForce(new Vector2(-addForce - dashAmount, 0));
        isLeft = false;
        anim.SetTrigger("walk");
    }

    void Shoot()
    {
        if(!isShoot)
        {
            return;
        }
        GameObject shot = (GameObject)Instantiate(shotPrefab, rb2d.position, Quaternion.identity);
        Rigidbody2D rbShot = shot.GetComponent<Rigidbody2D>();
        rbShot.velocity = new Vector2(-rb2d.position.x, 6-rb2d.position.y);
        isShoot = false;

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGround = true;
        }
    }
}
