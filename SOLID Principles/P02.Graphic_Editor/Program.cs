using System;

namespace P02.Graphic_Editor
{
    public class Program
    {
        public static void Main()
        {
            var editor = new GraphicEditor();

            editor.DrawShape(new Circle());
            editor.DrawShape(new Rectangle());
            editor.DrawShape(new Square());
            editor.DrawShape(new Octagon());
        }
    }
}
