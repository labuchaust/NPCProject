using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Vector3 dir = Vector3.zero;
    public int maxHealth = 20;
    public int currentHealth;
    public float attackDamage = 10f;


    private void Start()
    {
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {

        dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        dir = transform.TransformDirection(dir);

        dir *= speed;

        transform.position += dir * Time.deltaTime;


        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }


    }


    
        private void DecreasePlayerHealth()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Death");
        GetComponent<Renderer>().material.color = Color.red;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KillFloor"))
        {
            currentHealth = 0;
            Die();
            //You can also add some code here to trigger death animation or whatever you want
            //to happen when the player dies
            Debug.Log("Player has died!");
        }
    }

}
