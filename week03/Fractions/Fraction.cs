public class Fraction
{
    // BEFORE: public int top; public int bottom;
    // Public fields let outside code change values directly (f1.top = 999),
    // breaking encapsulation. Fixed by making them private with a "_" prefix.
    private int _top;
    private int _bottom;

    public Fraction()
    {
        // renamed to match new private fields — logic was already correct.
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int top)
    {
        // BEFORE: top = top; bottom = 1;
        // "top = top" assigned the parameter to itself because the parameter
        // and field had the same name — the field silently stayed 0.
        // FIX: renaming the field to "_top" removes the name collision.
        _top = top;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        // BEFORE: top = top; bottom = bottom;
        // FIX: assign parameters to the renamed private fields.
        _top = top;
        _bottom = bottom;
    }

    public int GetTop()
    {
        // Updated to read from the renamed private field.
        return _top;
    }

    public void SetTop(int t)
    {
        // Updated to write to the renamed private field.
        _top = t;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int b)
    {
        _bottom = b;
    }

    public string GetFractionString()
    {
        // Updated to reference the renamed fields — no logic change.
        return _top + "/" + _bottom;
    }

    public double GetDecimalValue()
    {
        // BEFORE: return top / bottom;
        // int / int did INTEGER division first (truncates), then converted the result
        // to double. So 3 / 4 became 0, not 0.75.so i had to cast the top to double before dividing to get the correct decimal value.
        // FIX: cast _top to double BEFORE dividing, forcing decimal division.
        return (double)_top / _bottom;
    }
}