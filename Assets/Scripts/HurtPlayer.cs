﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public int damageToGive;
    private int currentDamage;
    public GameObject damageNumber;

    private Hero hero;

	// Use this for initialization
	void Start () {
        hero = FindObjectOfType<Hero>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            currentDamage = damageToGive - hero.GetStats().GetCurrentStat(2);//defence
            if (currentDamage <= 0)
            {
                currentDamage = 1;
            }

            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);
            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }
    
}
