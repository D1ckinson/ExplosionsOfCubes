using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Divider : MonoBehaviour
{
    [SerializeField] private Explosion _explosion;

    private float _divisoinChance = 100;
    private float _maxDivisoinChance = 100;
    private float _divisoinChanceDivider = 2;
    private float _scaleRatio = 2;
    private int _minDivision = 2;
    private int _maxDivision = 6;

    private Color[] _colors;

    private void Awake() =>
        SetColors();

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
            child.SetColor();
        }

        Destroy(gameObject);
    }

    private void OnDestroy() =>
        _explosion.Explode();

    private void SetColor() =>
        GetComponent<Renderer>().material.color = _colors[Random.Range(0, _colors.Length)];

    private void SetDivisoinChance() =>
        _divisoinChance /= _divisoinChanceDivider;

    private void SetColors() =>
        _colors = new Color[] { Color.green, Color.red, Color.blue };
}
