using UnityEngine;

public class DestoryOtherBlocks : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);//уничтожение блоков, которые пролетают мимо игрока
    }
}
