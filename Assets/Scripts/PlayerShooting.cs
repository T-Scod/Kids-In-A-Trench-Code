using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class PlayerShooting : MonoBehaviour
{
    [Header("Guns")]
    [SerializeField] List<Gun> guns;
    Gun currentGun;
    private int gunIndex = 0;

    [SerializeField] UnityEvent OnShoot;
    
    float timer;


    void Start()
    {
        //Own the own guns!!!
        foreach (var g in guns)
        {
            g.SetOwner(this.gameObject);
        }
        
        // Assert.IsTrue(guns.Count > 0);     //Make sure there is atleast one gun
        currentGun = guns[0];

        // Assert.IsNotNull(randomAudio);
    }

    private void Update()
    {
        //Keep track of time for fire delay
        timer += Time.deltaTime;
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
        if (gunIndex > guns.Count-1) gunIndex = 0;    //Wrap around
        currentGun = guns[gunIndex];
    }

    public void PrevGun()
    {
        gunIndex--;
        if (gunIndex < 0) gunIndex = guns.Count-1;    //Wrap around
        currentGun = guns[gunIndex];
    }

}