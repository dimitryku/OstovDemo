using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


public class Verticle
{
    public string name { get { return name; } set { name = value + ""; } }
    public Point point { get; set; }

    public Verticle(string name)
    {
        this.name = name;
        point = new Point(0, 0);
    }

    public Verticle(Verticle verticle)
    {
        this.name = verticle.name;
        this.point = new Point(verticle.point.X, verticle.point.Y);
    }

    public void SetPoint(int a, int b)
    {
        this.point = new Point(a, b);
    }

    public override bool Equals(object obj)
    {
        Verticle newWert = obj as Verticle;
        if (newWert == null)
            return false;
        return (this.name.Equals(newWert.name) || this.point.Equals(newWert.point));
    }

    public override int GetHashCode()
    {
        int code = 0;
        foreach (char c in name)
            code += (int)c;
        return code;
    }
}