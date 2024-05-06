﻿using System.Collections;
using System.Collections.Generic;
using Api.Common;
using TMPro;
using UnityEngine;

namespace Mono.GUI
{
    public class GameGUI : MonoBehaviour
    {
        private const int DistanceMantissaPrecision = 1;

        [SerializeField] public TextMeshProUGUI countdownText;
        [SerializeField] public TextMeshProUGUI healthText;
        [SerializeField] public List<GameObject> LifeIcons = new List<GameObject>();
        [SerializeField] public TextMeshProUGUI distanceText;

        public void UpdateCountdownText(int startingTime) => countdownText.text = $"Starting in {startingTime} ...";
        //public void UpdateHealth(int value) => healthText.text = $"Health: {value}";
        public void UpdateHealth(int value)
        {
            for (int i = LifeIcons.Count - 1; i >= 0; i--)
                LifeIcons[i].SetActive(value > i);
        }
        
        public void UpdateDistanceText(float value) => 
            distanceText.text = $"{MathUtil.TrimFloat(value, DistanceMantissaPrecision)} m";
        
        public void SetActive(bool active) => gameObject.SetActive(active);
        public bool IsActive() => gameObject.activeSelf;
    }
}