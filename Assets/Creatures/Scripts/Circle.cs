﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Enemy
{
    public int attacksInSeries;

    protected override IEnumerator AlternativeAttack()
    {
        attack = true;
        for(int i=0; i< attacksInSeries; i++)
        {
            animator.SetBool("attack", true);
            yield return new WaitForSeconds(0.5F);//animation time
            Vector2 lookDirection = new Vector2(hero.position.x, hero.position.y) - new Vector2(transform.position.x, transform.position.y);
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle)); // obiekt, pozycja startowa, kierunek
		    animator.SetBool("attack", false);
        }
        yield return new WaitForSeconds(Random.Range(2F, 4F));//attack time
        attack = false;
    }
}
