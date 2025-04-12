using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldPowerUp : MonoBehaviour
{
    private float fallSpeed = 3f;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);
        if (transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }
    }
}