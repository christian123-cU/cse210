public class Fraction
{
    public int top;
    public int bottom;

    public Fraction()
    {
        top = 1;
        bottom = 1;
    }

    public Fraction(int top)
    {
        top = top;
        bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        top = top;
        bottom = bottom;
    }

    public int GetTop()
    {
        return top;
    }

    public void SetTop(int t)
    {
        top = t;
    }

    public int GetBottom()
    {
        return bottom;
    }

    public void SetBottom(int b)
    {
        bottom = b;
    }

    public string GetFractionString()
    {
        return top + "/" + bottom;
    }

    public double GetDecimalValue()
    {
        return top / (double)bottom;
    }
}