﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<LootBag>().InsTantiateLoot(transform.position);
            Destroy(gameObject);
        }
        
    }
   
}
