using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantiateInfected : MonoBehaviour
{

    public GameObject prefab;
    public GameObject healthyCells;
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject infectedInstance = Instantiate(prefab, new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10)), Quaternion.identity);
            //infectedInstance.GetComponent<InfectedScript>().cells = healthyCells;
        }

        if (amount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
