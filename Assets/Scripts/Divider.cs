using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Divider : MonoBehaviour
{
    private float _divisoinChance = 100;
    private float _maxDivisoinChance = 100;
    private float _divisoinChanceDivider = 2;
    private float _scaleRatio = 2;
    private int _minDivision = 2;
    private int _maxDivision = 6;

    private void OnMouseDown()
    {
        if (_divisoinChance <= Random.Range(0, _maxDivisoinChance))
        {
            Destroy(gameObject);
            return;
        }

        int objectQuantity = Random.Range(_minDivision, _maxDivision + 1);

        for (int i = 0; i < objectQuantity; i++)
        {
            Divider child = Instantiate(this, transform.position, Quaternion.identity);
            child.transform.localScale /= _scaleRatio;
            child.transform.parent = null;
            child.SetDivisoinChance();
        }

        Destroy(gameObject);
    }

    private void SetDivisoinChance() =>
        _divisoinChance /= _divisoinChanceDivider;
}
