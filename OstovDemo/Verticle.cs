using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


public class Verticle
{
    private string _name;
    private Point _point;

    public string name { get { return _name; } private set { _name = value; } }
    public Point point { get { return _point; } private set { point = value; } }


    public Verticle()
    {
        name = "v" + (1).ToString(); //добавить номер
    }

    public Verticle(string name)
    {
        this.name = name;
    }

    public Verticle(Verticle verticle)
    {
        this.SetName(verticle.GetName());
        this.SetPosition(verticle.GetPosition());
    }


    public string GetName()
    {
        return this.name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public void SetPosition(Point point)
    {
        this.point = new Point(point.X, point.Y);
    }

    public void SetPosition(int a, int b)
    {
        this.point = new Point(a, b);
    }

    public Point GetPosition()
    {
        return point;
    }

    public override bool Equals(object obj)
    {
        Verticle newWert = obj as Verticle;
        if (newWert == null)
            return false;
        return this.name.Equals(newWert.GetName());
    }

    public override int GetHashCode()
    {
        int code = 0;
        foreach (char c in name)
            code += (int)c;
        return code;
    }
}