using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Collections;

public class myscript : MonoBehaviour
{
    GameObject[] cubes = new GameObject[4];
    GameObject[] gos = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            cubes[i] = GameObject.Find("Cube" + i);
            gos[i] = GameObject.Find("GameObject" + i);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        foreach (GameObject obj in cubes)
        {
            obj.transform.Rotate(new Vector3(1f, 1f, 1f));
        }
        Vector3 v = transform.position;
        v.y += 2;
        v.z -= 7;
        Camera.main.transform.position = v;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(new Vector3(-1f, 0, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(new Vector3(1f, 0, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.AddForce(new Vector3(0, 0, 1f));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.AddForce(new Vector3(0, 0, -1f));
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.StartsWith("Cube"))
        {
            for (int i = 0; i < 4; i++)
            {
                if (cubes[i] == collider.gameObject)
                {
                    ParticleSystem ps = gos[i].GetComponent<ParticleSystem>();
                    ps.Play();
                    cubes[i].SetActive(false);
                }
            }
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.name == "Cylinder")
        {
            Behaviour b = (Behaviour)collider.gameObject.GetComponent("Halo");
            b.enabled = true;
        }

    }
}
