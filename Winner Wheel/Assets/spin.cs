using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour {
    public float rotationSpeed = 60;
    public float min = 3;
    public float max = 10;
    public bool rotating;
    public float randomTime;
    public bool spinning;
    public float currentSpeed;
    private bool reductionReady;
	// Use this for initialization
	void Start () {
        currentSpeed = rotationSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !spinning) {
            rotating = !rotating;
            if (rotating == true) {
                currentSpeed = rotationSpeed;
                reductionReady = false;
                
                randomTime = Random.Range(min, max);
            }
            StartCoroutine(WheelWait());
        }
        if (rotating)
        {
            if (currentSpeed > 0)
            {
                Vector3 spin = new Vector3(0, currentSpeed, 0);
                transform.Rotate(spin * Time.deltaTime);
                if (!reductionReady)
                {
                    StartCoroutine(speedReduction());
                }
            }
            
        }
        

	}
    IEnumerator speedReduction() {
        currentSpeed -= 10;
        reductionReady = true;
        yield return new WaitForSeconds(.200f);
        reductionReady = false;
        
    }
    IEnumerator WheelWait() {
        spinning = true;
        yield return new WaitForSeconds(randomTime);
        rotating = false;
        spinning = false;
    }
}
