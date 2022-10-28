
using TMPro;
using UnityEngine;

namespace UIScripts
{
    public class GameScreen : Screen
    {
        [SerializeField] private TMP_Text currentMagazineAmmo;
        [SerializeField] private TMP_Text totalAmmo;

        public void SetAmmo(int currentMagazine, int total)
        {
            currentMagazineAmmo.text = currentMagazine.ToString();
            totalAmmo.text = total.ToString();
        }
    }
}