using UnityEngine;

public class DestroyService : MonoBehaviour
{
    [SerializeField] private Divider _divider;
    [SerializeField] private Explosion _explosion;

    [SerializeField] private float _divisionChance;
    private float _maxDivisionChance = 100;
    private float _divisionChanceDivider = 2;

    private void OnMouseDown()
    {
        Debug.Log(_divisionChance);

        if (_divisionChance <= Random.Range(0, _maxDivisionChance))
        {
            _explosion.UpStrength();
            _explosion.Explode();
        }
        else
        {
            _divisionChance /= _divisionChanceDivider;
            _divider.Divide();
        }

        Destroy(gameObject);
    }
}
