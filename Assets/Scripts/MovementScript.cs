// A Simple Movement Script
// Author: Jeff Chastine
using UnityEngine;
using System.Collections;


public class MovementScript : MonoBehaviour
{

	Animator anim;
	public float runSpeed = 2.0f;
	public bool isActive = true;
	private float h = 0.0f; // Horizontal input (A, D)
	private float v = 0.0f; // Vertical input (W, S)
	private float vAbs, hAbs, maxInput; // The absolute value of the input
	private float dfs = 0.0f; // The direction the character is facing
	private float radsToDegs; // A conversion between radians and degrees
	Inventory inventory; // The player's inventory

	// Use this for initialization
	void Start()
	{
		inventory = new Inventory();
		anim = GetComponent<Animator>();
		anim.SetFloat("Speed", 0.0f);
		radsToDegs = 180.0f / (float)Mathf.PI;
	}

	// When the player enters a trigger, add the item to the inventory
	void OnTriggerEnter(Collider other)
	{
		{
			inventory.AddToInventory(other.transform.parent);
			inventory.PrintInventory();
		}
	}
	private void Update()
	{
		CheckForDrops();
	}
	// Fixed Update is called once per frame
	void FixedUpdate()
	{
		if (!isActive)
		{
			anim.SetFloat("Speed", 0);
			return;
		}

		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		vAbs = Mathf.Abs(v);
		hAbs = Mathf.Abs(h);
		maxInput = Mathf.Max(vAbs, hAbs);

		anim.SetFloat("Speed", maxInput);
		if ((vAbs > 0.1) || (hAbs > 0.1f))
		{
			dfs = Mathf.Atan2(-v, h);
			Vector3 lookAtTarget = Quaternion.AngleAxis(dfs * radsToDegs, Vector3.up) * Vector3.forward + transform.position;
			transform.LookAt(lookAtTarget);
			transform.Translate(Vector3.forward * Time.deltaTime * maxInput * runSpeed);

		}
	}
	
	// Check for item drops based on number key input
	void CheckForDrops() {
    if (Input.GetKeyUp(KeyCode.Alpha0)) {
        inventory.DropItem(0, transform.position + transform.forward * 3);
    }
    else if (Input.GetKeyUp(KeyCode.Alpha1)) {
        inventory.DropItem(1, transform.position + transform.forward * 3);
    }
    else if (Input.GetKeyUp(KeyCode.Alpha2)) {
        inventory.DropItem(2, transform.position + transform.forward * 3);
    }
}
}
