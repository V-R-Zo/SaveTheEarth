using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dartNotice : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)

    {

        //Debug.Log("�浹 ����!");
        Debug.Log("2");
        dartScore.dartTotalScore += 125;



    }
}
