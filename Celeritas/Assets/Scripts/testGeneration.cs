using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGeneration : MonoBehaviour
{

    public int NumberOfBiome = 4;
    private int id;
    public int NumberOfPrefab = 10;
    private int ChoosedPrefab;
    private int count;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            id = Random.Range(1, NumberOfBiome);
        }

        if (id == 1) //winter
        {
            while (count < 10)
            {
                count++;
                ChoosedPrefab = Random.Range(1, NumberOfPrefab);
                Debug.Log("winter" + ChoosedPrefab);

            }

        }

        if (id == 2) //spring
        {
            while (count < 10)
            {
                count++;
                ChoosedPrefab = Random.Range(1, NumberOfPrefab);
                Debug.Log("spring" + ChoosedPrefab);

            }

        }

        if (id == 3) //summer
        {
            while (count < 10)
            {
                count++;
                ChoosedPrefab = Random.Range(1, NumberOfPrefab);
                Debug.Log("summer" + ChoosedPrefab);

            }

        }
        if (id == 4) //autumn
        {
            while (count < 10)
            {
                count++;
                ChoosedPrefab = Random.Range(1, NumberOfPrefab);
                Debug.Log("autumn" + ChoosedPrefab);

            }

        }

        TEst();

    }

    void TEst()
    {
       
    }
}
