using UnityEngine;

public class TowerBase : MonoBehaviour
{
    private Renderer rend;
    private GameObject tower;
    public Vector3 positionOffset;

    public Color hoverColor;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (tower != null)
        {
            Debug.Log("Can't build there! = TODO: Display on screen.");
            return;
        }

        // Build a tower
        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
        tower = (GameObject)Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);
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
