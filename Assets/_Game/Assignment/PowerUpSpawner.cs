using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.GameEvents;
using DefaultNamespace.ScriptableEvents;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameEventVector3 OnAsteroidDestroyedPos;

    [SerializeField] private GameObject powerUp;
    
    void Start()
    {
     OnAsteroidDestroyedPos.Register(spawnPowerUp);
     
    }
    public void spawnPowerUp(Vector3 spawnPos)
    {
        int random = Random.Range(0, 100); 
        if (random <= 25)
        {
            
            GameObject speedpowerUp = Instantiate(powerUp, spawnPos, Quaternion.identity);
            speedpowerUp.GetComponent<PowerUp>().powerUpType = PowerUp.PowerUpType.speedBoost;
            speedpowerUp.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (random >= 25 && random <= 50)
        {
            GameObject healthpowerUp = Instantiate(powerUp, spawnPos, Quaternion.identity);
            healthpowerUp.GetComponent<PowerUp>().powerUpType = PowerUp.PowerUpType.healthRestore;
           healthpowerUp.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
    }
}
