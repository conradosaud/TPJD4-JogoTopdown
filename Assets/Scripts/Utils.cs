using UnityEngine;

public class Utils : MonoBehaviour
{
    
    /// <summary>
    /// O transform de origem passado aqui irá olhar/rotacionar para o objeto alvo
    /// </summary>
    /// <param name="origem">QUEM vai olhar</param>
    /// <param name="objeto">Para ONDE vai olhar</param>
    public static void OlharParaObjeto( Transform origem, Vector3 objeto )
    {
        Vector3 direcao = (objeto - origem.position).normalized;

        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        
        if( origem.GetComponent<Rigidbody2D>())
        {
            origem.GetComponent<Rigidbody2D>().rotation = angulo;
        }
        else
        {
            origem.eulerAngles = new Vector3(0, 0, angulo);
        }
        
    }

}
