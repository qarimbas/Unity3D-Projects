using System.Collections;
using UnityEngine;

public class Kapı : MonoBehaviour
{
    [SerializeField]
    private GameObject anahtarVar;
    [SerializeField]
    private GameObject kapiAcik;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && anahtarVar.activeSelf)
        {
            kapiAcik.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
}
