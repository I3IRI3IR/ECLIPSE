using UnityEngine;

[System.Serializable]
public class TileData
{
    public int ID = 0; // 板塊類型
    public int[] Resources; //三種資源和三種爛地、灰地的數量
    public int ancient; //遠古飛船數量
    public bool star; // 星星板塊否
    public int prize; //獎勵板塊數量
    public int score; //此板塊的分數
    public bool[] Facility; //(Starbase,人造衛星,方尖碑)的數量; should be refactored
}