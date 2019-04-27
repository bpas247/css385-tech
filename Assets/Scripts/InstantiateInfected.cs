using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            infectedInstance.GetComponent<InfectedScript>().cells = healthyCells;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
