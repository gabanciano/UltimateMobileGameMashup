using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpaceShooter : MonoBehaviour {

	[Header("Player's Bullet")]
	public GameObject ShipBullet;
	[Space]

	[Header("Player Hover Speed")]
	public float playerSpeed;
	[Space]

	[HideInInspector]
	public bool shipMoveUp;
	[HideInInspector]
	public bool shipMoveDown;

	[System.NonSerialized]
	public bool targetAcquired;


	Rigidbody2D ShipRigid2D;
	Vector2 ShipPosition;

	void InitializeData(){
		GameData.GAME_REQUIRED = 20;
		targetAcquired = false;
		ShipRigid2D = GetComponent<Rigidbody2D> ();
	}

	void Awake(){
		InitializeData ();
	}

	void Start(){
		InvokeRepeating ("ShootBullets", 0, 0.1f);
	}

	void Update(){
		ClampPlayer ();

        DetectKeyboardInput();
	}

    void DetectKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveShipUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveShipDown();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            StopShipFromMoving();
        }
    }

    void ClampPlayer(){
		ShipPosition = ShipRigid2D.position;
		ShipPosition.y = Mathf.Clamp (ShipPosition.y, -4.2f, 3.2f);
		ShipRigid2D.position = ShipPosition;
	}

	public void MoveShipUp(){
		ShipRigid2D.velocity = new Vector2 (ShipRigid2D.velocity.x, playerSpeed);
	} 

	public void MoveShipDown(){
		ShipRigid2D.velocity = new Vector2 (ShipRigid2D.velocity.x, -playerSpeed);
	}

	public void StopShipFromMoving(){
		ShipRigid2D.velocity = Vector2.zero;
	}

	void ShootBullets(){
		if (targetAcquired) {
			Instantiate (ShipBullet, transform.position,transform.rotation);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Space_Enemy") {
			SceneManager.LoadScene ("game_over");
		}
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Space_Enemy") {
			targetAcquired = true;
			Debug.Log (targetAcquired);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Space_Enemy" || col.gameObject.tag == "Space_DeadEnemy") {
			targetAcquired = false;
			Debug.Log (targetAcquired);
		}
	}
}
