using System;

namespace shapeTest {
    internal class Program {
        public static void Main(string[] args) {
            
            Random random = new Random();
            shapeFactory factory = new shapeFactory();
            
            int ran;
            shape[] sh = new shape[10];
            for (int i = 0; i < 10; i++) {
                ran = random.Next(3);
                switch (ran) {
                    case 0:
                        sh[i] = factory.CreateShape("rectangle");
                        break;
                    case 1:
                        sh[i] = factory.CreateShape("square");
                        break;
                    case 2:
                        sh[i] = factory.CreateShape("triangle");
                        break;
                }
                
                Console.WriteLine(sh[i].ToString());
                
                if (sh[i].is_OK()) {
                    
                    Console.WriteLine("该" + sh[i].getName() +"合法");
                    Console.WriteLine("该" + sh[i].getName() +"的面积为：" + sh[i].area());
                    
                } else {
                    Console.WriteLine("该形状不合法");
                }
            }
        }
    }
}

class shapeFactory {
    private Random random = new Random();
    public shape CreateShape(string shapeType) {
        if (shapeType.Equals("rectangle",StringComparison.OrdinalIgnoreCase)) {
            return new rectangle(random.Next(200) - 100,random.Next(200) - 100);
        } else if (shapeType.Equals("square", StringComparison.OrdinalIgnoreCase)) {
            return new square(random.Next(200) - 100);
        } else if (shapeType.Equals("triangle",StringComparison.OrdinalIgnoreCase)) {
            return new triangle(random.Next(200) - 100,random.Next(200) - 100);
        } else {
            throw new ArgumentException("您输入的形状种类不正确。");
        }
    }
}
abstract class shape {
    public abstract double area();
    public abstract bool is_OK();
    public new abstract string ToString();
    public abstract string getName();
}
class rectangle : shape {
    
    private double length;
    private double width;

    public rectangle() {}

    public rectangle(double length, double width) {
        this.length = length;
        this.width = width;
    }

    public void setLength(double length) {
        this.length = length;
    }

    public double getLength() {
        return length;
    }

    public void setWidth(int width) {
        this.width = width;
    }

    public double getWidth() {
        return width;
    }
    
    public override double area() {
        if (!is_OK()) {
            return 0;
        }
        return length * width;
    }

    public override bool is_OK() {
        return (length > 0) && (width > 0);
    }

    public override string ToString() {
        return ("矩形的长为：" + length + "，宽为：" + width + "。");
    }

    public override string getName() {
        return "矩形";
    }
}
class square : shape {
        
    private double length;

    public square() { }

    public square(int length) {
        this.length = length;
    }
    
    public void setLength(int length) {
        this.length = length;
    }

    public double getLength() {
        return length;
    }

    public override double area() {
        if (!is_OK()) {
            return 0;
        }
        return length * length;
    }

    public override bool is_OK() {
        return (length > 0);
    }
    
    public override string ToString() {
        return ("正方形的边长为：" + length + "。");
    }

    public override string getName() {
        return "正方形";
    }
}
class triangle : shape {
    
    private double length;
    private double high;

    public triangle() { }

    public triangle(int length, int high) {
        this.length = length;
        this.high = high;
    }

    public void setLength(int length) {
        this.length = length;
    }

    public double getLength() {
        return length;
    }

    public void setHigh() {
        this.high = high;
    }

    public double getHigh() {
        return high;
    }

    public override double area() {
        if (!is_OK()) {
            return 0;
        }
        return length * high / 2;
    }

    public override bool is_OK() {
        return (length > 0) && (high > 0);
    }
    
    public override string ToString() {
        return ("三角形的长为：" + length + "，高为：" + high + "。");
    }

    public override string getName() {
        return "三角形";
    }
}