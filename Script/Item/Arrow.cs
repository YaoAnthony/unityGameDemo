using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public int damage;
    public float destroyDis;

    //本体
    private Rigidbody2D item;
    private Vector3 startPos;
    void Start()
    {
        //获得移动
        item = GetComponent<Rigidbody2D>();
        item.velocity = transform.right * speed;
        startPos = transform.position;
    }
    void Update()
    {
        //求距离
        float distance = (transform.position - startPos).sqrMagnitude;
        if(distance > destroyDis){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            //other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            //Destroy(gameObject);
        }
    }
}
