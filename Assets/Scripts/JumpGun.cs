using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт уже проверен
public class JumpGun : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed;
    public Transform spawnTransform;
    public Gun pistol;
    public float maxCharge = 3f;
    private float _currentCharge;
    private bool _isCharged;
    public ChargeIcon chargeIcon;

    private void Update()
    {
        if (_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerRigidbody.AddForce(-spawnTransform.forward * speed, ForceMode.VelocityChange);
                pistol.Shoot();

                _isCharged = false;
                _currentCharge = 0f;

                chargeIcon.StartCharge();
            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            chargeIcon.SetChargeValue(_currentCharge, maxCharge);
            
            if (_currentCharge >= maxCharge)
            {
                _isCharged = true;
                chargeIcon.StopCharge();
            }
        }
    }
}
