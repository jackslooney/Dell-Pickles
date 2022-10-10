using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static Score instance;
    public GameObject[] cupList;
    public int cupCount;
    

    // Start is called before the first frame update
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            if (gameObject == null)
            {
                Destroy(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        cupList = GameObject.FindGameObjectsWithTag("Cup");
        cupCount = cupList.Length;
    }

    // Update is called once per frame
    void LateUpdate()
    {

       if(cupCount <=0)
        {
            SceneManager.LoadScene(2);
        }
        //Debug.Log(cupCount);
    }

    

    
}
