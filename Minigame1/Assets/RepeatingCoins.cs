using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingCoins : MonoBehaviour
{
    public GameObject coinPreFab;

    private GameObject[] coins;
    private Rigidbody2D Coin;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private int coinPoolSize = 40;
    private float groundHorizontalLength; //store the x position

    // Use this for initialization
    void Awake()
    {
        Coin = GetComponent<Rigidbody2D>();
        groundHorizontalLength = 20.48f; //get size of the collider.
    }

    void Start()
    {

        coins = new GameObject[coinPoolSize];
        for (int i = 0; i < coinPoolSize; i++)
        {
            coins[i] = (GameObject)Instantiate(coinPreFab, objectPoolPosition, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -12)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{

    public int coinPoolSize = 20;
    public GameObject coinPreFab;
    public float spawnRate = 1f;
    public float coinMin = -1f;
    public float coinMax = 3.5f;

    private GameObject[] coins;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 2f;
    private int currentCoin = 0;


    // Use this for initialization
    void Start()
    {
        timeSinceLastSpawned = 0f;

        coins = new GameObject[coinPoolSize];
        for (int i = 0; i < coinPoolSize; i++)
        {
            coins[i] = (GameObject)Instantiate(coinPreFab, objectPoolPosition, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.game1Over == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;
            float spawnYPosition = Random.Range(coinMin, coinMax);
            coins[currentCoin].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentCoin++;
            if (currentCoin >= coinPoolSize)
            {
                currentCoin = 0;
            }
        }
    }
}*/
