using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    public Transform target;
    private void LateUpdate() {
        transform.position = new Vector3(target.position.x, target.position.y, this.transform.position.z);
    }
}
