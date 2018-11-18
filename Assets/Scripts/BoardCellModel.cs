using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardCellModel : MonoBehaviour {

	public ElementTypes ElementType { get; set; }
	 
    public BoardCellModel(ElementTypes type) {
        ElementType = type;      
    }
}