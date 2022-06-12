using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.ScriptableEvents;
using UnityEngine;
using Variables;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private FloatVariable throttlePower;
    
    [SerializeField] private ScriptableEventInt speedChangeEvent;
    [SerializeField] private IntObservable changeHealth;
    
    [SerializeField] private int boostAmmount = 5;
    [SerializeField] private float boostDuration = 3f;
    
    public PowerUpType powerUpType;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (powerUpType == PowerUpType.speedBoost)
            {
                speedChangeEvent.Raise(boostAmmount);
                StartCoroutine(resetSpeed());
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
            }
            else
            {
                changeHealth.ApplyChange(boostAmmount);
                Destroy(gameObject);
            }
        }
    }

    public enum PowerUpType
    {
        speedBoost,
        healthRestore
    }

    private IEnumerator resetSpeed()
    {
        yield return new WaitForSeconds(boostDuration);
        speedChangeEvent.Raise(0);
        Destroy(gameObject);
    }
}
