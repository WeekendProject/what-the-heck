using UnityEngine;
using UnityEditor;

using System.Collections;

using LunarPlugin;

[CCommand("explode")]
class Cmd_explode : CCommand
{
    void Execute()
    {
        GameObject[] selection = Selection.gameObjects;
        foreach (GameObject obj in selection)
        {
            Explodable explodable = obj.GetComponent<Explodable>();
            if (explodable != null)
            {
                explodable.Explode();
            }
        }
    }
}
