using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public float attackTime;
    public float xMin, xMax;
    public float yMin, yMax;
    public GameObject attackPrefab1;
    public GameObject attackPrefab2;
    public GameObject attackPrefab3;
    public GameObject attackPrefab4;
    public GameObject attackPrefab5;
    public GameObject littleBono;
    public GameObject littleBono2;
    public int deltaAttack;
    public AudioClip attackSmall;
    public AudioClip attackBig;
    public AudioClip dance;

    private AudioSource source;
    private int attackNum;
    private GameObject attack;
    private bool isDead;
    private float hp;
    private Animator anim;
    private Rigidbody2D rb2d;

    private bool isB;
    private bool isO;
    private bool isN;
    private bool isBONO;
    // Use this for initialization
    private void Awake()
    {
        attackNum = 1;
    }
    void Start () {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        attackNum = 1;
    }
	
	// Update is called once per frame
	void Update () {

		if(Time.time > attackTime && !GameController.instance.win)
        {
            if (GameController.instance.BossHp < 100)
            {
                finalAttack();
            }
            anim.SetTrigger("attack");
            attackTime = attackTime + deltaAttack;
            doAttack(attackNum);
            attackNum++;
        }
        if(Input.GetKey(KeyCode.B) || isB)
        {
            isB = true;
            if(Input.GetKey(KeyCode.O) || isO)
            {
                isO = true;
                if(Input.GetKey(KeyCode.N) || isN)
                {
                    isN = true;
                    if(Input.GetKey(KeyCode.O))
                    {
                        littleBono.SetActive(true);
                        littleBono2.SetActive(true);
                        source.PlayOneShot(dance, 0.1f);
                        GameController.instance.win = true;
                    }
                }
            }
        }
	}


    private void doAttack(int attackNum)
    {
        float vol = 1.0f;
        float xPosition = Random.Range(xMin, xMax)*2;
        float yPosition = Random.Range(yMin, yMax)*2;
        int att = attackNum % 15;
        switch (attackNum)
        {
            case 1:
            case 3:
            case 5:
            case 0:
                source.PlayOneShot(attackSmall, vol);
                GameObject attack = (GameObject) Instantiate(attackPrefab1, new Vector2(0,3), Quaternion.identity);
                Rigidbody2D rbAttack = attack.GetComponent<Rigidbody2D>();
                rbAttack.velocity = new Vector2(-xPosition, 6 - yPosition);
                break;
            case 2:
            case 4:
            case 6:
                source.PlayOneShot(attackSmall, vol);
                GameObject attack3 = (GameObject)Instantiate(attackPrefab2, new Vector2(0,3), Quaternion.identity);
                Rigidbody2D rbAttack3 = attack3.GetComponent<Rigidbody2D>();
                rbAttack3.velocity = new Vector2(-xPosition, 6 - yPosition);
                break;
            case 7:
                source.PlayOneShot(attackBig, vol);
                Instantiate(attackPrefab3, new Vector2(0, 6), Quaternion.identity);
                break;
            case 8:
            case 9:
            case 10:
                break;
            case 11:
                source.PlayOneShot(attackBig, vol);
                Instantiate(attackPrefab4, new Vector2(xPosition, 6), Quaternion.identity);
                break;
            case 12:
            case 13:
            case 14:
                break;
        }
    }
    
    private void finalAttack()
    {
        float xPosition = Random.Range(xMin, xMax);
        Instantiate(attackPrefab5, new Vector3(xPosition, -4), Quaternion.identity);
    }
}
