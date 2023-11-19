using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
            return;
            
        instance = this;
    }

    public GameObject fatCatPrefab;
    public GameObject orangeCatPrefab;
    public GameObject whiteCatPrefab;

    private TowerBlueprint towerToBuild;
    private TowerBase selectedTower;

	public TowerUI towerUI;

    public bool CanBuild { get { return towerToBuild != null; }}
    public bool HasMoney { get { return PlayerStats.Currancy >= towerToBuild.cost; } }

    void Start() 
    {
        towerUI.Hide();
    }

	public void SelectTower (TowerBase tower)
	{
		if (selectedTower == tower)
		{
			DeselectTower();
			return;
		}
        
		selectedTower = tower;
		towerToBuild = null;

		towerUI.SetTarget(tower);
	}

	public void DeselectTower()
	{
		selectedTower = null;
		towerUI.Hide();
	}

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
        selectedTower = null;
        DeselectTower();
    }

    public TowerBlueprint GetTowerToBuild ()
    {
        return towerToBuild;
    }
}
