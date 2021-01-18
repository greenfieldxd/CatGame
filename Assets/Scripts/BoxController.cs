using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private Rigidbody2D boxBody;
    [SerializeField] private LayerMask groundLayerMask;

    void Awake()
    {
        boxBody = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        Debug.Log(boxBody.transform.name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (groundLayerMask.Equals("Ground"))
        boxBody.transform.SetParent(collision.transform);
    }


}
