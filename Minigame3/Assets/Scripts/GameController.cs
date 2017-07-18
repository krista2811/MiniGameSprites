using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public bool gameOver1 = false;
	public bool gameOver2 = false;
    public bool win = false;
    public Text bossHp;
    public Text player1Hp;
    public Text player2Hp;
    public GameObject GameOverText;
    public GameObject WinText;
    public GameObject startScene;
    public int BossHp;
    public int PlayerHp;
    public int hits1;
    public int hits2;

    public int Player1Hp;
    public int Player2Hp;


	void Awake () {

        Player1Hp = PlayerHp;
        Player2Hp = PlayerHp;
        bossHp.text = "HP : " + BossHp.ToString();
        player1Hp.text = "HP : " + Player1Hp.ToString();
        player2Hp.text = "HP : " + Player2Hp.ToString();

        if (instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy (gameObject); 
		}
	}
	// Use this for initialization
	void Start () {
        startScene.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
		if(gameOver1 && gameOver2 && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if(win && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(Input.anyKey)
        {
            startScene.SetActive(false);
        }
	}

    public void bossHit()
    {
        if (!win)
        {
            BossHp -= 10;
            bossHp.text = "HP : " + BossHp.ToString();
        }
    }

    public void player1Hit()
    {
        if (!gameOver1)
        {
            Player1Hp -= 10;
            player1Hp.text = "HP : " + Player1Hp.ToString();
        }
    }

    public void player2Hit()
    {
        if (!gameOver2)
        {
            Player2Hp -= 10;
            player2Hp.text = "HP : " + Player2Hp.ToString();
        }
    }

    public void GameOver() {
	    if(gameOver1 && gameOver2)
        {
            GameOverText.SetActive(true);
        }
        return;
	}
    public void Win()
    {
        if(win)
        {
            WinText.SetActive(true);
        }
    }


}
