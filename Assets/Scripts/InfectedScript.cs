using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedScript : MonoBehaviour
{

    public GameObject cells;
    public float MoveSpeed = 6.0f;
    int currentPlayer = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = Random.Range(0, cells.transform.childCount);
    }

    // Update is called once per frame
    void Update()
    {

        if (currentPlayer >= cells.transform.childCount)
        {
            currentPlayer = Random.Range(0, cells.transform.childCount - 1);
            Debug.Log(currentPlayer);
        }

        if (cells.transform.childCount > 0)
        {
            transform.LookAt(cells.transform.GetChild(currentPlayer));

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Healthy_cell")
        {
            // TODO: Do not destory object, it is currently place holder for testing
            // Actual implementation will have chance of infecting healthy
            Destroy(collision.gameObject);
            currentPlayer = Random.Range(0, cells.transform.childCount - 1);
            
        }
    }
}
