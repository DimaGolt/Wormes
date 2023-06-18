using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormShooting : MonoBehaviour
{
    private int MinPower = 0;
    private int MaxPower = 100;

    private int MinAngle = -90;
    private int MaxAngle = 90;

    [SerializeField]
    public int CurrentPower;
    [SerializeField]
    public int CurrentAngle;

    private Transform _transform;
    [SerializeField]
    public Transform crosshairTransform;
    
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CalculatePower();
        }
        else if(Input.GetKeyUp(KeyCode.Return))
        {
            //fire
            CurrentPower = 0;
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (CurrentAngle < MaxAngle)
                CurrentAngle += 1;
            else
                CurrentAngle = MaxAngle;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (CurrentAngle > MinAngle)
                CurrentAngle -= 1;
            else
                CurrentAngle = MinAngle;
            
        }
        
        UpdateCrosshairPosition();
        
    }

    void UpdateCrosshairPosition()
    {
        var aRad = Mathf.Deg2Rad * CurrentAngle;
        
        var delX = 1 * Mathf.Cos(aRad);
        var delY = 1 * Mathf.Sin(aRad);

        var position = _transform.position;
        
        var newX = position.x + (delX * Mathf.Sign(_transform.localScale.x));
        var newY = position.y + delY + 0.2f;
        
        crosshairTransform.position = new Vector3(newX , newY);
    }

    void CalculatePower()
    {
        if (CurrentPower>MaxPower)
        {
            CurrentPower = MaxPower;
            return;
        }

        CurrentPower += Mathf.CeilToInt(Time.deltaTime * 0.4f);
    }
}
