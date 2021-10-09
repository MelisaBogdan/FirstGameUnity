using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Vector2 moveValue;
    private int count;
    private int value;
    public Text scoreText;
    private int numPickups = 8;
    public Text winText;

    public void Start () {
        count = 0; 
        winText.text = ""; 
        SetCountText ();
    }
    void OnMove(InputValue value) { 
        moveValue = value.Get<Vector2 >();
    }

    void FixedUpdate () {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        GetComponent <Rigidbody >().AddForce(movement * speed * Time. fixedDeltaTime);
    } 
    private void OnTriggerEnter(Collider other) { 
        if(other.gameObject.tag == "PickUp") {
            other.gameObject.SetActive(false); 
            count ++;
            SetCountText();
        } 
    }
    private void SetCountText () {
        scoreText.text = "Score: " + count.ToString(); 
        if(count >= numPickups) {
            winText.text = "WOAH YOU WON"; 
        }
    } 
}