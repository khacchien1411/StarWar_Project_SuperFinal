using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float rollBoost = 2f;
    

    private float rollTime;
    public float RollTime;
    bool rollOnce = false;

    private Rigidbody2D rb;
    public Animator animator;

    public SpriteRenderer characterSR;

    public Vector3 moveInput;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space) && rollTime <= 0)
        {
            AudioManager.Instance.PlayDashSFX();
            animator.SetBool("Roll", true);
            moveSpeed += rollBoost;
            rollTime = RollTime;
            rollOnce = true;
        }

        if (rollTime <= 0 && rollOnce == true) {
            animator.SetBool("Roll", false);
            moveSpeed -= rollBoost;
            rollOnce = false;
        }
        else
        {
            rollTime -= Time.deltaTime;
        }

        if (moveInput.x != 0)
        {
            if (moveInput.x > 0) {
                characterSR.transform.localScale = new Vector3(1, 1, 0);
            } else
            {
                characterSR.transform.localScale = new Vector3(-1, 1, 0);
            }
        }
    }


    public Health playerHealth;
    public void TakeDamage(int damage)
    {
        playerHealth.TakeDam(damage);
    }


    public GameObject[] weaponPrefabs;  // An array of weapon prefabs.
    public Transform[] playerWeaponSlots;  // An array of empty objects on the player where the weapons will be attached.

    private int currentWeaponSlot = 0;  // A variable to track the current active weapon slot.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Heart")
        {
            AudioManager.Instance.PlayLootSFX();
            playerHealth.Heal(10);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "Speed")
        {
            moveSpeed += 2;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "Damage")
        {
            
            Destroy(collision.gameObject);
        }
            
        else if (collision.gameObject.name == "Gun")
        {
            AudioManager.Instance.PlayLootSFX();
            // Check if the currentWeaponSlot is within the bounds of the arrays.
            if (currentWeaponSlot < weaponPrefabs.Length && currentWeaponSlot < playerWeaponSlots.Length)
                {
                    // Instantiate the new weapon prefab.
                    GameObject newWeapon = Instantiate(weaponPrefabs[currentWeaponSlot], playerWeaponSlots[currentWeaponSlot]);
                    newWeapon.transform.localPosition = Vector3.zero; // Position adjustment if needed.
                    newWeapon.transform.localRotation = Quaternion.identity; // Rotation adjustment if needed.

                    // Increment the currentWeaponSlot to prepare for the next weapon.
                    currentWeaponSlot++;

                    // Disable the collected weapon object in the world (optional).
                    //gameObject.SetActive(false);
                    // Optionally, you can handle other aspects of the weapon switch, such as updating the player's current weapon variable.

                    // Increment the currentWeaponSlot to prepare for the next weapon.
                    currentWeaponSlot++;
                }
            
            Destroy(collision.gameObject);
        }

    }

   


}
