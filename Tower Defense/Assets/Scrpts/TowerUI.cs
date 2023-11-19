using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
	public GameObject ui;
	public Text upgradeCost;
	public Text sellAmount;
	public Button upgradeButton;

	private TowerBase target;

	public void SetTarget (TowerBase _target)
	{
		target = _target;

		transform.position = target.GetBuildPosition();
        

		if (!target.isUpgraded)
		{
			sellAmount.text = "$" + target.towerBlueprint.GetSellAmount();
			upgradeCost.text = "$" + target.towerBlueprint.upgradeCost;
			upgradeButton.interactable = true;
		} else
		{
			sellAmount.text = "$" + (target.towerBlueprint.GetSellAmount() + (target.towerBlueprint.upgradeCost/2));
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
    	}

		ui.SetActive(true);
    }

    public void Hide ()
    {
        ui.SetActive(false);
    }

    public void Upgrade ()
    {
        target.UpgradeTower();
        BuildManager.instance.DeselectTower();
    }

    public void Sell ()
    {
        target.SellTower();
        BuildManager.instance.DeselectTower();
    }
}
