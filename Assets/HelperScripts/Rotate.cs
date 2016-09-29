using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    public float Speed = 20f;

	void Start ()
    {

	}

	void Update ()
    {
        Vector3 r = transform.localEulerAngles;
        r.y += Time.deltaTime * Speed;
        transform.localEulerAngles = r;
	}
}
