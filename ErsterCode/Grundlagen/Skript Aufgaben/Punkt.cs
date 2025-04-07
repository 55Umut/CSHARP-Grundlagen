using System;

public class Punkt
{
    private double x;
    private double y;

    public Punkt()
    {
        this.x = 0;
        this.y = 0;
    }

    public Punkt(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double GetX()
    {
        return x;
    }

    public double GetY()
    {
        return y;
    }

    public void SetX(double wert)
    {
        this.x = wert;
    }

    public void SetY(double wert)
    {
        this.y = wert;
    }
} 