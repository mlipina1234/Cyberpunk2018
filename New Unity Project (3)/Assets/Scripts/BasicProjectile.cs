﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    [SerializeField] private List<Projectile> projectilePool;

    public List<Projectile> ProjectilePool { get { return projectilePool; } }

	// Update is called once per frame
	void Update ()
    {
        //shoots the bullet when you click
		if(Input.GetMouseButtonDown(0))
        {
            Projectile projectile = projectilePool[projectilePool.Count - 1];
            projectilePool.RemoveAt(projectilePool.Count - 1);

            projectile.gameObject.SetActive(true);

            projectile.transform.localPosition = new Vector3(.2f * -1, 0);

            projectile.Shoot(1 * -1);
        }
	}
}