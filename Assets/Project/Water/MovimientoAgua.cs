using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAgua : MonoBehaviour
{
    private Rigidbody2D water;
    private float waterVelocity;
    [SerializeField]private float timeToGoUp;
    [SerializeField]private float waterInitialPosition;
    [SerializeField]private float waterFinalPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, waterInitialPosition);
        water = GetComponent<Rigidbody2D>();
        waterVelocity = (waterFinalPosition - waterInitialPosition) / timeToGoUp;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= waterFinalPosition)
            water.velocity = new Vector2(0,  waterVelocity);
        else
            water.velocity = new Vector2(0, 0);
    }
}

