using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUnit : MonoBehaviour
{

    public int money = 0 ;

    public int hamburger = 0;
    public int cola = 0;
    public int fries = 0;

    public int ATbooster = 0;
    public int fullHeal = 0;

    public bool gun = false;
    public bool knife = false;
    public bool ATgauge = false;

    public void buyOrUseHamburger(int count) 
    {
        if (count > 0)
        {
            if (money - 50 * count < 0)
            {
                return;
            }

            money -= 50 * count;
            hamburger++;
        }
        else if (count == -1) 
        {
            hamburger--;
        }


    }
    public void buyOrUseCola(int count)
    {
        if (count > 0)
        {
            if (money - 20 * count < 0)
            {
                return;
            }

            money -= 20 * count;
            cola++;
        }
        else if (count == -1)
        {
            cola--;
        }


    }
    public void buyOrUseFries(int count)
    {
        if (count > 0)
        {
            if (money - 30 * count < 0)
            {
                return;
            }

            money -= 30 * count;
            fries++;
        }
        else if (count == -1) {
            fries--;
        }


    }
    public void buyOrUseATbooster(int count)
    {
        if (count > 0)
        {
            if (money - 500 * count < 0)
            {
                return;
            }

            money -= 500 * count;
            ATbooster++;
        }
        else if (count == -1) 
        {
            ATbooster--;
        }


    }
    public void buyOrUseFullHeal(int count)
    {
        if (count > 0)
        {
            if (money - 150 * count < 0)
            {
                return;
            }

            money -= 150 * count;
            fullHeal++;
        }
        else if (count == -1) 
        {
            fullHeal--;
        }


    }
    public void buyGun()
    {
        if (money - 300 < 0)
        {
            return;
        }

        money -= 300;
        gun = true;


    }
    public void buyKnife()
    {
        if (money - 150 < 0)
        {
            return;
        }

        money -= 150;
        knife = true;


    }

    public void buyATgauge()
    {
        if (money - 500 < 0)
        {
            return;
        }

        money -= 500;
        ATgauge = true;


    }

}
