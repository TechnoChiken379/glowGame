using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyHealthBar4 : MonoBehaviour
{
    public bossCheckIndicator bossCheckIndicator;

    public float xScale;
    public static float totalCGHP;

    // Start is called before the first frame update
    void Start()
    {
        bossCheckIndicator.boss4Check = false;

        xScale = 35.6f;
    }

    // Update is called once per frame
    void Update()
    {
        bossFightingTimer.bossFightingTimerFLOAT += Time.deltaTime;
        bossFightingTimer.bossFightingTimerINT = Mathf.FloorToInt(bossFightingTimer.bossFightingTimerFLOAT);
        bossFightingTimerInBoss.bossFightingTimerFLOAT += Time.deltaTime;
        bossFightingTimerInBoss.bossFightingTimerINT = Mathf.FloorToInt(bossFightingTimer.bossFightingTimerFLOAT);

        totalCGHP = boss4a.CGHP + boss4b.CGHP + boss4c.CGHP;
        transform.localScale = new Vector3(xScale, 9f, 1f);
        xScale = 0.475f * totalCGHP;

        if (totalCGHP <= 0)
        {
            bossCheckIndicator.boss4Check = true;

            characterCube.HP = characterCube.backUpHP;
            characterCube.bossBuildIndex = 5;

            winScreenChecker();
        }

        void winScreenChecker()
        {
            if (bossCheckIndicator.boss4Check == true && bossCheckIndicator.allBossesDead == true)
            {
                SceneManager.LoadScene("epicWinScreen");
            }
            else if (bossCheckIndicator.boss4Check == true && bossCheckIndicator.allBossesDead == false)
            {
                SceneManager.LoadScene("winScreen");
            }
        }
    }
}
