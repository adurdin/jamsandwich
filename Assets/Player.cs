﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public int playerNum = 0;
	public float speed = 4;
	public float jumpSpeed = 8;

	Rigidbody2D rb;
	Carry carry;

	int jumpTimer = 0;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		carry = GetComponent<Carry>();
	}
	
	// Update is called once per frame
	void Update() {
		Vector2 vel = rb.velocity;

		vel.x = Input.GetAxis("Horizontal" + playerNum) * speed;
		rb.velocity = vel;
		if (Input.GetButton("Jump" + playerNum)) {
			Jump();
		}
		if (Input.GetButton("Fire" + playerNum)) {
			carry.Throw(new Vector2(100, 100));
		}

		if (jumpTimer > 0) {
			jumpTimer--;
		}
	}

	void Jump() {
		if (jumpTimer <= 0) {
			rb.velocity += new Vector2(0, jumpSpeed);
			jumpTimer = 60;
		}
	}
}
