using System.Drawing;

public class Verticle
{
    private string _name;
    public int connections;
    public bool isSelected;

    public Verticle(string name)
    {
        this.name = name;
        point = new Point(0, 0);
        connections = 0;
    }

    public Verticle(Verticle verticle)
    {
        name = verticle.name;
        point = new Point(verticle.point.X, verticle.point.Y);
        connections = 0;
    }

    public string name
    {
        get => _name;
        set => _name = value + "";
    }

    public Point point { get; set; }

    public void SetPoint(int a, int b)
    {
        point = new Point(a, b);
    }

    public override bool Equals(object obj)
    {
        var newWert = obj as Verticle;
        if (newWert == null)
            return false;
        return name.Equals(newWert.name) || point.Equals(newWert.point);
    }

    public override int GetHashCode()
    {
        var code = 0;
        foreach (var c in name)
            code += c;
        return code;
    }
}