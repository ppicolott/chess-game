using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _SR;
    [SerializeField] private GameObject _highlight;
    private Vector2 _position;

    public void SetPosition(Vector2 position)
    {
        _position = position;
    }

    public void SetColor(bool isOffset)
    {
        _SR.color = isOffset ? _offsetColor : _baseColor;
    }

    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        Debug.Log("Tile: " + _position.x.ToString() + "," + _position.y.ToString());
    }
}
