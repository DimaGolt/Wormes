using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormWeapon : MonoBehaviour
{
    private int _selectedWeapon = 0;
    [SerializeField]
    public RuntimeAnimatorController empty;
    [SerializeField]
    public RuntimeAnimatorController bazooka;

    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        switch (_selectedWeapon)
        {
            case 1:
                _animator.runtimeAnimatorController = bazooka;
                break;
            default:
                _animator.runtimeAnimatorController = empty;
                break;
        }
    }

    public void ChangeWeapon(int weapon)
    {
        _selectedWeapon = weapon;
    }
}
