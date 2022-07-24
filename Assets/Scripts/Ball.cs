using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;

    public GameObject splashPrefab;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(Vector3.up * jumpForce);
        string materialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;

        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0f,-0.2f,0f), transform.rotation);
        splash.transform.SetParent(collision.gameObject.transform);

        if (materialName == "Unsafe Color (Instance)")
        {
            gm.Restart();
        }
        else if (materialName == "LastRing (Instance)")
        {
            gm.Restart();

        }
    }
}
