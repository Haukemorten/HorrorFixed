using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTriggerZone : MonoBehaviour
{
    [SerializeField] int indexScene;

    private void OnTriggerEnter(Collider _othercol)
    {
        SceneManager.LoadScene(indexScene);
    }
    

    private void OnDrawGizmos ()
    {
          Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
