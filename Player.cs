using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject enemyOnePrefab;
    public GameObject enemyBigPrefab;

    private void Start()
    {
        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyBig", 1, 3);
    }

    private void Update()
    {

    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8.38f, 8.38f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyBig()
    {
        Instantiate(enemyBigPrefab, new Vector3(Random.Range(-8.38f, 8.38f), 6.5f, 0), Quaternion.identity);
    }
}

public class Enemy_Big : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(new Vector3(-1, -1, 0) * Time.deltaTime * 7f);
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }
}

public class Player : MonoBehaviour
{
    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 8.38f;
    private float verticalScreenLimit = 6.5f;
    private float stopYPositionUpper = 0f;
    private float stopYPositionLower = -4.47f;

    public TMP_Text scoreText;
    private int score;

    void Start()
    {
        playerSpeed = 8f;
        score = 0;
        UpdateScoreText();
    }

    void Update()
    {
        Movement();
        score ++;
        UpdateScoreText();
    }

    void Movement ()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
        if (transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
       float clampedY = Mathf.Clamp(transform.position.y, stopYPositionLower, stopYPositionUpper);
        Vector3 newPosition = transform.position;
        newPosition.y = clampedY;
        transform.position = newPosition;
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        scoreText.text = "Score: " + score.ToString();
    }
}