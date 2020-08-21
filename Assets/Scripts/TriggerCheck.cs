using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    [SerializeField]
    GameObject loseScreen;
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Let")
        {
            loseScreen.SetActive(true); 
        }
    }
    
}

