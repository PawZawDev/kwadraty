﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : Enemy
{
    protected override IEnumerator AlternativeAttack()
    {
        attack = true;
        animator.SetBool("attack", true);
        yield return new WaitForSeconds(1.5F);//animation time

        for(int i=0; i<8; i++)
        {
            float angle = i * Mathf.PI * 14;
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle)); // obiekt, pozycja startowa, kierunek
		    
        }

        animator.SetBool("attack", false);
        yield return new WaitForSeconds(Random.Range(2F, 4F));//attack time
        attack = false;
    }
}
