using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Sprite[] sprites;
	public GameObject bulletPosition01, bulletPosition02;
	public GameObject bullet; 
	public float speed = 10f;

	// Use this for initialization
	void Start () {
		Debug.Log ("start");
		GetComponent <SpriteRenderer> ().sprite = sprites[0];
	}
	
	// Update is called once per frame
	void Update () {
		
		//Preleviamo la posizione del player
		Vector2 pos = transform.position;

		//Prelevare i bordi in alto a destra e in basso a sinistra della 
		//visuale della telecamera
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
		Debug.Log("min :"+min.ToString() + "max :"+max.ToString());

		max.x -= 0.7f;
		min.x += 0.7f;


		if(Input.GetKey(KeyCode.LeftArrow)){
			//Modifica della posizione
			pos.x -= speed * Time.deltaTime;

			//Cambio immagine in Left Player quando la nava va sinistra
			GetComponent <SpriteRenderer> ().sprite = sprites[1];


			//Debug.Log(transform.position.ToString());
		}else if(Input.GetKey(KeyCode.RightArrow)){
			//Modifica della posizione
			pos.x += speed * Time.deltaTime;

			//Cambio immagine in Left Player quando la nava va sinistra
			GetComponent <SpriteRenderer> ().sprite = sprites[2];

			//Debug.Log(transform.position.ToString());
		} else{
			GetComponent <SpriteRenderer> ().sprite = sprites[0];
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject bullet01 = Instantiate (bullet);
			bullet01.transform.position = bulletPosition01.transform.position;

			GameObject bullet02 = Instantiate (bullet);
			bullet02.transform.position = bulletPosition02.transform.position;

			AudioSource bulletAudio = GetComponent <AudioSource> ();
			bulletAudio.Play ();
		}

		pos.x = Mathf.Clamp (pos.x, min.x, max.x);

		//Applicare lo spostamento
		transform.position = pos;
	}
}
