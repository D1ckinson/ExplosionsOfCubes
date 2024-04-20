using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;

    private float _strengthMultiplier = 1.5f;

    public void Explode() =>
        GetExplodableObjects().ForEach(item => item.AddExplosionForce(_force, transform.position, _radius));

    public void UpStrength()
    {
        _force *= _strengthMultiplier;
        _radius *= _strengthMultiplier;
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);

        return hits.Where(hit => hit.attachedRigidbody != null).Select(hit => hit.attachedRigidbody).ToList();
    }
}
