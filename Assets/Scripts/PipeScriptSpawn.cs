using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScriptSpawn : MonoBehaviour
{
    public float maxTime= 1;
    public float timer = 0;
    public GameObject pipe;
    public float height;
    

    private void Start()
    {
        GameObject acilanpipe = Instantiate(pipe);
        
    }

    private void Update()
    {
        if (timer>maxTime)
        {
            GameObject newpipe = Instantiate(pipe);
            
            newpipe.transform.position += new Vector3(0,Random.Range(-height,height),0);
            Destroy(newpipe,10);
            timer = 0;
            
        }

        timer += Time.deltaTime;
    }



   
        
}

