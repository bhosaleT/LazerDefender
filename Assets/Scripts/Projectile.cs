﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

	public float damage = 50f;

	public float GetDamage ()
	{
		return damage;
	}

	public void Hit ()
	{
		Destroy (gameObject);
	}
}