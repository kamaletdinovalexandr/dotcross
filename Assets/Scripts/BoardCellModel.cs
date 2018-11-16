using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardCellModel : MonoBehaviour {

	public Vector2Int Position { get; set; }
	public ElementTypes ElementType { get; set; }
	public Players Players { get; set; }
	 
}