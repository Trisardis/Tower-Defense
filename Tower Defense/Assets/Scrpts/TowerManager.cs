using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{

    // Stores the amount of each tower
    public static int orangeCatAmount;
    public static int whiteCatAmount;
    public static int fatCatAmount;
    public int startingOrangeCatAmount = 1;
	public int startingWhiteCatAmount = 1;
	public int startingFatCatAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        orangeCatAmount = startingOrangeCatAmount;
        whiteCatAmount = startingWhiteCatAmount;
        fatCatAmount = startingFatCatAmount;
    }
}
