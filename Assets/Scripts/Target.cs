using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] float time = 0.2f;
    private bool colided = false;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (colided)
            return;
        if(other.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(WaitToDestroy());
        }

        if(other.gameObject.CompareTag("Floor"))
        {
            StartCoroutine(WaitToDestroy());
        }
        
    }

   IEnumerator WaitToDestroy()
   {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
  }
}
