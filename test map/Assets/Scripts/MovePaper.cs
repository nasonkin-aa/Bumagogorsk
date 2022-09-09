using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
    public class MovePaper : MonoBehaviour
    {
        Vector3 originalPos;
        int speed = 3;
        // Start is called before the first frame update
        void Start()
        {
            //gameObject.AddComponent<Rigidbody2D>();
            originalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        // Update is called once per frame
        void Update()
        {
            if ((-1 * transform.position.x) >= 11)
            {
                Destroy(gameObject);
            }
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}