using UnityEngine;
using UnityEditor;

public class Player  {
    public Players PlayerType  { get; set; }
    public ElementTypes Element { get; set; }

    public Player(Players playerType, ElementTypes element) {
        PlayerType = playerType;
        Element = element;
    }
}