using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBase : MonoBehaviour
{
    private Renderer rend;
    private GameObject tower;
    public Vector3 positionOffset;

    public Color hoverColor;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        // Prevents tower placement is mouse is over the ui
        if (EventSystem.current.IsPointerOverGameObject())
          return;

        // Return if there is no tower selected
        if (buildManager.GetTowerToBuild() == null)
            return;

        if (tower != null)
        {
            Debug.Log("Can't build there! = TODO: Display on screen.");
            return;
        }

        // Build a tower
        GameObject towerToBuild = buildManager.GetTowerToBuild();
        tower = (GameObject)Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        // Prevents tower placement is mouse is over the ui
        if (EventSystem.current.IsPointerOverGameObject())
          return;
        
        // Return if there is no tower selected
        if (buildManager.GetTowerToBuild() == null)
            return;

        if (tower == null)
            rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
