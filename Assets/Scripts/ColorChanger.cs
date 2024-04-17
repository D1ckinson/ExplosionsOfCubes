using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Color[] _colors;

    private void Awake() =>
        _colors = new Color[] { Color.red, Color.green, Color.blue };

    private void Start()
    {
        if (TryGetComponent(out Renderer renderer))
            ChangeColor(renderer);
    }

    private void ChangeColor(Renderer renderer) =>
        renderer.material.color = _colors[Random.Range(0, _colors.Length)];
}
