using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBase : MonoBehaviour
{
    private Renderer rend;

    [Header("Optional")]
    public GameObject tower;
    public Vector3 positionOffset;
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        // Prevents tower placement is mouse is over the ui
        if (EventSystem.current.IsPointerOverGameObject())
          return;

        // Return if there is no tower selected
        if (!buildManager.CanBuild)
            return;

        if (tower != null)
        {
            Debug.Log("Can't build there! = TODO: Display on screen.");
            return;
        }

        buildManager.BuildTowerOn(this);
    }

    void OnMouseEnter()
    {
        // Prevents tower placement is mouse is over the ui
        if (EventSystem.current.IsPointerOverGameObject())
          return;
        
        // Return if there is no tower selected
        if (!buildManager.CanBuild)
            return;

        // Choose rock color based on whether the play has enough currency or not
        if (buildManager.HasMoney)
			rend.material.color = hoverColor;
		else
			rend.material.color = notEnoughMoneyColor;

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
