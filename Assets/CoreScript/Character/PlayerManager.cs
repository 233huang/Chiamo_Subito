using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public int PlyaerID{ get; set; }
    public string PlyaerName { get; set; }
    public int CharacterID { get; set; }
}
