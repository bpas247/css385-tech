using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfectedScript : MonoBehaviour
{

    private GameObject[] cells;
    public float MoveSpeed = 6.0f;
    int currentPlayer = 0;

    // Start is called before the first frame update
    //void Start()
    //{
    //    currentPlayer = Random.Range(0, cells.Length);
    //}

    // Update is called once per frame
    void Update()
    {
        cells = GameObject.FindGameObjectsWithTag("Healthy");

        if (currentPlayer >= cells.Length)
        {
            currentPlayer = Random.Range(0, cells.Length - 1);
            Debug.Log(currentPlayer);
        }

        if (cells.Length > 0)
        {
            transform.LookAt(cells[currentPlayer].transform);

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        if(cells.Length <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Healthy")
        {
            // TODO: Do not destory object, it is currently place holder for testing
            // Actual implementation will have chance of infecting healthy
            //Destroy(collision.gameObject);
            currentPlayer = Random.Range(0, cells.Length - 1);
            
        }

        if(collision.gameObject.name == "Protector")
        {
            Destroy(this.gameObject);
        }
    }
}
