using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.AI;

public class HealthyScript : MonoBehaviour
{
    public float velocidadMax;

    public float xMax;
    public float zMax;
    public float xMin;
    public float zMin;
    public float enemyDistance = 1000f;

    //private NavMeshAgent _agent;
    private float x;
    private float z;
    private float tiempo;
    private float angulo;

    private Animator anim;
    private bool collided = false;
    public GameObject InfectedCellObject;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

        x = Random.Range(-velocidadMax, velocidadMax);
        z = Random.Range(-velocidadMax, velocidadMax);
        angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
        transform.localRotation = Quaternion.Euler(0, angulo, 0);
        //_agent = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update()
    {
		GameObject[] infectedCells = GameObject.FindGameObjectsWithTag("Infected");

		if (infectedCells.Length <= 0)
		{
			SceneManager.LoadScene("WinScene");
		}

		// Find closest enemy
		float distance = float.MaxValue;
		GameObject closestEnemy = null;

		foreach(GameObject infectedCell in infectedCells) {
			float curDistance = Vector3.Distance(transform.position, infectedCell.transform.position);
			if (curDistance < distance)
			{
				distance = curDistance;
				closestEnemy = infectedCell;
			}
		}

		tiempo += Time.deltaTime;
		
		Debug.Log("Distance: " + distance);


        if(distance < enemyDistance)
        {
             Vector3 b = transform.position - closestEnemy.transform.position;
             Vector3 newPos = transform.position + b;
            transform.Translate(4 * Time.deltaTime, 0f, 0f);

            z = Random.Range(-velocidadMax, 0.0f);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, angulo, 0);
            tiempo = 0.0f;

        }
        
		if (!collided)
        {
            if (transform.localPosition.x > xMax)
            {
                x = Random.Range(-velocidadMax, 0.0f);
                angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
                transform.localRotation = Quaternion.Euler(0, angulo, 0);
                tiempo = 0.0f;
            }
            if (transform.localPosition.x < xMin)
            {
                x = Random.Range(0.0f, velocidadMax);
                angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
                transform.localRotation = Quaternion.Euler(0, angulo, 0);
                tiempo = 0.0f;
            }
            if (transform.localPosition.z > zMax)
            {
                z = Random.Range(-velocidadMax, 0.0f);
                angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
                transform.localRotation = Quaternion.Euler(0, angulo, 0);
                tiempo = 0.0f;
            }
            if (transform.localPosition.z < zMin)
            {
                z = Random.Range(0.0f, velocidadMax);
                angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
                transform.localRotation = Quaternion.Euler(0, angulo, 0);
                tiempo = 0.0f;
            }
            if (tiempo > 1.0f)
            {
                x = Random.Range(-velocidadMax, velocidadMax);
                z = Random.Range(-velocidadMax, velocidadMax);
                angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
                transform.localRotation = Quaternion.Euler(0, angulo, 0);
                tiempo = 0.0f;
            }
            transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, transform.localPosition.z + z);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Infected")
        {
            int rand = Random.Range(0, 4);

            if (rand <= 2 && !collided)
            {
                collided = true;
                anim.SetTrigger("infected");
                Instantiate(InfectedCellObject, transform.position, Quaternion.identity);
                //Destroy(gameObject);
                //destroyTimer();
                Destroy(gameObject, 1f);
            }
        }
    }

    IEnumerator destroyTimer()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        //Instantiate(InfectedCellObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
 