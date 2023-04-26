using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour
{
    [SerializeField] Eagle eagle;
    [SerializeField] Amongus amongus;
    [SerializeField] float initialTimer = 10;
    float timer;
    void Start()
    {
        timer = initialTimer;
        eagle.gameObject.SetActive(false);
    }

    void Update()
    {
        if (timer <=0 && eagle.gameObject.activeInHierarchy ==  false)
        {
            eagle.gameObject.SetActive(true);
            eagle.transform.position = amongus.transform.position+new Vector3(0,0,13);
            amongus.SetMoveable(false);
        }
        timer -= Time.deltaTime;
    }

    public void ResetTimer(){
        timer = initialTimer;
    }
}
