using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Logger.Templates
{
    class Paragraph : IDisposable
    {
        readonly int _margin;
        public Paragraph(int margin)
        {
            _margin = margin;

            WriteLines();            
        }
        public void Dispose()
        {
            WriteLines();
        }

        void WriteLines()
        {
            for (int i = 0; i < _margin; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
