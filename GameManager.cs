using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject shieldPowerUpPrefab;

    private void Start()
    {
        InvokeRepeating("SpawnShieldPowerUp", 5f, 5f);
    }

    void SpawnShieldPowerUp()
    {
        Instantiate(shieldPowerUpPrefab, new Vector3(Random.Range(-8.38f, 8.38f), 6.5f, 0), Quaternion.identity);
    }
}
