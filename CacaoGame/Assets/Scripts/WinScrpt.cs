using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScrpt : MonoBehaviour
{
    // If tag "Player" enters designated trigger game continues...
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(5);
        }
    }
}
