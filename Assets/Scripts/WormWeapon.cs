using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormWeapon : MonoBehaviour
{
    private int _selectedWeapon = 1;
    [SerializeField]
    public RuntimeAnimatorController empty;
    [SerializeField]
    public RuntimeAnimatorController bazooka;
    [SerializeField]
    public RuntimeAnimatorController shotgun;
    [SerializeField]
    public RuntimeAnimatorController uzi;
    [SerializeField]
    public RuntimeAnimatorController dragon;

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
            case 2:
                _animator.runtimeAnimatorController = bazooka;
                break;
            case 5:
                _animator.runtimeAnimatorController = shotgun;
                break;
            case 6:
                _animator.runtimeAnimatorController = uzi;
                break;
            case 7:
            case 8:
                _animator.runtimeAnimatorController = dragon;
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
