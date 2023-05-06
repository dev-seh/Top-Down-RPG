using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinManager : MonoBehaviour
{
    public Animator animator;
    private int currentSkinLayerIndex = 0;


    private void Start()
    {
    }


    public void SetSkin(int skinLayerIndex)
    {
        if (currentSkinLayerIndex == skinLayerIndex)
        {
            skinLayerIndex = 0;
        }
        if (skinLayerIndex >= 0 && skinLayerIndex < animator.layerCount)
        {
            for (int i = 0; i < animator.layerCount; i++)
            {
                if (i != skinLayerIndex)
                {
                    animator.SetLayerWeight(i, 0f);
                }
                else
                {
                    animator.SetLayerWeight(i, 1f);
                }
            }
            currentSkinLayerIndex = skinLayerIndex;
        }
    }
}














