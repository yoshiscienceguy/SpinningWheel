using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour {
    public float rotationSpeed = 60;
    public float min = 3;
    public float max = 10;
    public bool rotating;
    public float randomTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            rotating = !rotating;
            if (rotating == true) {
                randomTime = Random.Range(min, max);
            }
            
        }
        if (rotating)
        {
            Vector3 spin = new Vector3(0, rotationSpeed, 0);
            transform.Rotate(spin * Time.deltaTime);
            StartCoroutine(WheelWait());
        }
        

	}

    IEnumerator WheelWait() {

        yield return new WaitForSeconds(randomTime);
        rotating = false;
    }
}
