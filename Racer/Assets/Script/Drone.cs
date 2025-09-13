using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Drone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public IObjectPool<Drone> dronePool { get; set; }
    public float currentHealth;

    [SerializeField]
    private float maxHealth = 100.0f;

    [SerializeField]
    private float timeToSelfDestuct = 3.0f;
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        AttackPlayer();
        StartCoroutine(SelfDestruct());
    }

    private void OnDisable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeToSelfDestuct);
        TakeDamage(maxHealth);
    }

    private void ReturnToPool()
    {
        dronePool.Release(this);
    }

    private void ResetDrone()
    {
        currentHealth = maxHealth;
    }

    public void AttackPlayer()
    {
        Debug.Log("Attack Player");
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            ReturnToPool();
        }
    }
}
