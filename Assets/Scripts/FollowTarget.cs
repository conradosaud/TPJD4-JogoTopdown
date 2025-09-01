using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float suavidade = 5; // smooth

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 novaPosicao = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, novaPosicao, suavidade * Time.deltaTime);
    }
}
