using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PrefabsCreate : MonoBehaviour

{

    [SerializeField] GameObject prefab;
    [SerializeField] int amount_of_enemies = 10;
    [SerializeField] GameObject min_marker;
    [SerializeField] GameObject max_marker;
   
    

    void Start()
    {
        if(prefab==null)
        {
            Debug.LogError("you missing a prefab");
        }
        StartCoroutine(Enemy());

    }

    IEnumerator Enemy()
    {

       
            for (int i = 0; i < amount_of_enemies; i++)
            {
                yield return new WaitForSeconds(0.5f);
                var position = new Vector2(Random.Range(min_marker.transform.position.x, max_marker.transform.position.x), min_marker.transform.position.y);
                Instantiate(prefab, position, Quaternion.identity);

            }
       
               
         
  
        
    }

    

    
}
