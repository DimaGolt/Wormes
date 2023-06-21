using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WormAiming : MonoBehaviour
{
    private int MinPower = 0;
    private int MaxPower = 100;

    private int MinAngle = -90;
    private int MaxAngle = 90;

    [SerializeField]
    public int CurrentPower;
    [SerializeField]
    public int CurrentAngle;

    [SerializeField]
    public Transform muzzleTransform;
    [SerializeField]
    public Transform crosshairTransform;

    public WormShooting shootScript;

    private Transform _wormTransform;

    private void Start()
    {
        _wormTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            shootScript.FireProjectile(CurrentPower);
            CurrentPower = MinPower;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            CalculatePower();
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (CurrentAngle < MaxAngle)
                CurrentAngle += Mathf.CeilToInt(Time.deltaTime * 0.01f);
            else
                CurrentAngle = MaxAngle;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (CurrentAngle > MinAngle)
                CurrentAngle -= Mathf.CeilToInt(Time.deltaTime * 0.01f);
            else
                CurrentAngle = MinAngle;
            
        }
        
        UpdateCrosshairPosition();
        
    }

    void UpdateCrosshairPosition()
    {
        var direction = Mathf.Sign(_wormTransform.localScale.x);
        
        var aRad = Mathf.Deg2Rad * CurrentAngle;
        
        var delX = Mathf.Cos(aRad);
        var delY = Mathf.Sin(aRad);

        var position = muzzleTransform.position;
        
        var newX = position.x + (delX * direction);
        var newY = position.y + delY;
        
        crosshairTransform.position = new Vector3(newX , newY);
    }

    public Vector3 getShootingVector()
    {
        return crosshairTransform.position - muzzleTransform.transform.position;
    }

    void CalculatePower()
    {
        if (CurrentPower>MaxPower)
        {
            CurrentPower = MaxPower;
            return;
        }

        CurrentPower += Mathf.CeilToInt(Time.smoothDeltaTime * 0.04f);
    }
}
