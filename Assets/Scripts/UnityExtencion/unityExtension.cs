using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class unityExtension
{
    //si el primer parametro es this, es un extencion al tipo de variable que viene indicado despues
    public static int GetRandomIndex(this int[] _array)
    {
        int index = Random.Range(0, _array.Length);
        return index;
    }

    public static void SetPosX(this Transform _t, float _x)
    {
        Vector3 pos = _t.position;
        pos.x = _x;
        _t.position = pos;
    }

    public static Vector2 ToVector2(this Vector3 _v)
    {
        return _v;
    }

    public static Vector3 ToVector3(this Vector3 _v)
    {
        return _v;
    }
}
