using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField]
    List<Transform> SpawnerMassiv;

    [SerializeField]
    GameObject blockLet;
    [SerializeField]
    float speed = -10f;
    float time;
    [SerializeField]
    Material TopLet;
    [SerializeField]
    Material DownLet;
    Vector3 movedir;
    
    void Start()
    {
        movedir = new Vector3(0f, 0f, speed);// присваивание вектора
    }

    void Update()
    {
        instanitate();
    }

    void instanitate()
    {
        time += Time.deltaTime;// таймер

        if (time >= 0.5f)
        {
            time = 0;

            blockLet.GetComponent<MeshRenderer>().material = DownLet;//присваиваем цвет
            GameObject blockDown = Instantiate(blockLet, SpawnerMassiv[Random.Range(3, 6)]);//выбираем место спавна и спавним
            blockDown.GetComponent<Rigidbody>().AddForce(movedir);//толкаем блоки вперед

            blockLet.GetComponent<MeshRenderer>().material = TopLet;
            blockDown = Instantiate(blockLet, SpawnerMassiv[Random.Range(0, 3)]);
            blockDown.GetComponent<Rigidbody>().AddForce(movedir);
        }
    }
}