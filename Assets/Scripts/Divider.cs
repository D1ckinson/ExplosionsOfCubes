using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Divider : MonoBehaviour
{
    private float _scaleRatio = 2;
    private int _minDivision = 2;
    private int _maxDivision = 6;

    public void Divide()
    {        
        int objectQuantity = Random.Range(_minDivision, _maxDivision + 1);

        for (int i = 0; i < objectQuantity; i++)
        {
            Divider child = Instantiate(this, transform.position, Quaternion.identity);
            child.transform.localScale /= _scaleRatio;
            child.transform.parent = null;
        }
    }
}
