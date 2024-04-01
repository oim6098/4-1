using DataStrucuture;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float BulletSpeed;
    public float BulletRotationSpeed;
    public Vector3 BulletDirection;
    public Queue<GameObject> list;

    // Start is called before the first frame update
    void Start()
    {
        Init(new Vector3(0,0,0), null);
        BulletDirection.Normalize();
    }

    public void Init(Vector3 InitialPos, Queue<GameObject> queue)
    {
        gameObject.transform.position = InitialPos;
        list = queue;
    }

   
    void Update()
    {
        gameObject.transform.position += BulletDirection * BulletSpeed;
        
        
        transform.Rotate(BulletDirection, BulletRotationSpeed);

       
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(0.5f,0.5f,0.5f));

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("RedCube"))
            {
                
                gameObject.SetActive(false);
                list.Enqueue(gameObject);
                break; 
            }
        }


    }
}
