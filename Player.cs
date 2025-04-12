using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

    public class Player : MonoBehaviour
{
    public GameObject shieldVisual;
    private bool shieldActive = false;
    private float shieldDuration = 5f;
    private float shieldTimer;
    private float fallSpeed = 3f;

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

        if (shieldVisual != null)
            shieldVisual.SetActive(false);

        playerSpeed = 8f;

        score = 0;
        UpdateScoreText();
     }

     void Update()
     {
        Movement();
        score++;
        UpdateScoreText();

        if (shieldActive)
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer <= 0)
            {
                DeactivateShield();
            }
        }
    }

     void Movement()
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
    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        if (other.CompareTag("ShieldPowerUp"))
        {
            Destroy(other.gameObject);
            ActivateShield();
        }
    }
    public void ActivateShield()
    {
        shieldActive = true;
        shieldTimer = shieldDuration;
    }
    private void DeactivateShield()
    {
        shieldActive = false;
    }
}