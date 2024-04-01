using DataStrucuture;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Bullet;
    public Queue<GameObject> queue;

    void Start()
    {
        queue = new Queue<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(Bullet);
            obj.GetComponent<Bullet>().Init(transform.position, queue);
            queue.Enqueue(obj);
        }
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GameObject Bul = queue.Dequeue();
        Bul.GetComponent<Bullet>().Init(transform.position, queue);
        Bul.SetActive(true);       

    }
}
