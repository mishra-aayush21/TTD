// PlayerShooting.cs
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Camera playerCamera;
    public float range = 100f;
    public int damagePerShot = 20;
    public LayerMask shootableLayer;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position,
                          playerCamera.transform.forward,
                          out hit,
                          range,
                          shootableLayer))
        {
            Health targetHealth = hit.transform.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damagePerShot);
                Debug.Log("HIT!!");
            }
        }
    }
}