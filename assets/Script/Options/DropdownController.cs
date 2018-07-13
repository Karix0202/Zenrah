using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownController : MonoBehaviour 
{

    List<string> types = new List<string>() { "JOYSTICK", "ACCELERATION" };

    #region CLASS_VARIAVLES

    public Dropdown dropdown;

	#endregion

	void Start () 
	{
        PopulateList(types, dropdown);
	}

    void PopulateList(List<string> list, Dropdown drop)
    {
        drop.AddOptions(list);
    }

    public void Dropdown_IndexChanged(int index)
    {
        PlayerPrefs.SetString("PLAYER_MOVING", types[index]);
        Debug.Log(PlayerPrefs.GetString("PLAYER_MOVING"));
    }

}
