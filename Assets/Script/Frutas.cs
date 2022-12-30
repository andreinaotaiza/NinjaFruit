using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frutas : MonoBehaviour
{
    public GameObject prefabFrutaCortada;

    public void CrearFrutaCortada()
    {
        GameObject ints= (GameObject)Instantiate(prefabFrutaCortada, transform.position, transform.rotation);

        Rigidbody[] rbsDeCortados = ints.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody r in rbsDeCortados)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);
        }

        FindObjectOfType<GameManager>().AumentarPuntaje();


        Destroy(ints.gameObject,5);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CrearFrutaCortada();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Espada e = collision.GetComponent<Espada>();

        if (!e)
        {
            return;
        }

        CrearFrutaCortada();
    }
}
