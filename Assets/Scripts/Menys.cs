﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menys : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }
}
