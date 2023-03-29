using UnityEngine;

public class TowerBase : MonoBehaviour
{
    private Renderer rend;
    
    public Color hoverColor;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
       rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
