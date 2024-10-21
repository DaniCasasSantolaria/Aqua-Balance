using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour{

    [SerializeField] private float initialX;
    [SerializeField] private float initialY;
    private Transform player;
    // Start is called before the first frame update
    void Start() {
        player = GetComponent<Transform>();
        player.transform.position = new Vector2(initialX, initialY);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
