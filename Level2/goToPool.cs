using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToPool : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)

    {

        Debug.Log("�浹 ����!");
        SceneManager.LoadScene("pool");


    }
}
