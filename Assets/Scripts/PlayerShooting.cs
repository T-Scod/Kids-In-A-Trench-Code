using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Guns")]
    [SerializeField] List<Gun> guns;
    Gun currentGun;
    private int gunIndex = 0;

    [SerializeField] UnityEvent OnShoot;
    
    float timer;

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