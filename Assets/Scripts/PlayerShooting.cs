using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Gun[] guns;
    Gun currentGun;
    private int gunIndex = 0;

    [SerializeField] UnityEvent OnShoot;
    
    void Start()
    {
        //Find all guns on object
        // guns = GetComponentsInChildren<Gun>();

        //Own the guns!!!
        foreach (var g in guns)
        {
            g.SetOwner(this.gameObject);
        }
        
        //Set start gun
        currentGun = guns[0];
    }

    public void Shoot()
    {
        // Debug.Log("Shooter calls Gun Fire");
        currentGun.Fire();
        OnShoot.Invoke();
    }

    public void NextGun()
    {
        gunIndex++;
        if (gunIndex > guns.Length-1) gunIndex = 0;    //Wrap around
        currentGun = guns[gunIndex];
    }

    public void PrevGun()
    {
        gunIndex--;
        if (gunIndex < 0) gunIndex = guns.Length-1;    //Wrap around
        currentGun = guns[gunIndex];
    }

}