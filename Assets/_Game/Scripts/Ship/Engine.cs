using System;
using DefaultNamespace.ScriptableEvents;
using UnityEditor.VersionControl;
using UnityEngine;
using Variables;

namespace Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Engine : MonoBehaviour
    {
        [SerializeField] private FloatVariable _throttlePower;
        [SerializeField] private FloatVariable _rotationPower;
        
        [SerializeField] private float _throttlePowerSimple;
        [SerializeField] private float _rotationPowerSimple;

        [SerializeField] private ScriptableEventInt speedBuffEvent;
        [SerializeField] private float speedMultiplier = 1f;

        private Rigidbody2D _rigidbody;
        
        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Throttle();
            }
        
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                SteerLeft();
            } 
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                SteerRight();
            }
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            //speedBuffEvent.Register(boostSpeed);
        }

        public void boostSpeed(int boostAmmount)
        {
            speedMultiplier = 1 + ((float)boostAmmount * 0.1f);
        }
    
        public void Throttle()
        {
            _rigidbody.AddForce(transform.up * (_throttlePower.Value * speedMultiplier), ForceMode2D.Force);
        }

        public void SteerLeft()
        {
            _rigidbody.AddTorque(_rotationPower.Value, ForceMode2D.Force);
        }

        public void SteerRight()
        {
            _rigidbody.AddTorque(-_rotationPower.Value, ForceMode2D.Force);
        }
    }
}
