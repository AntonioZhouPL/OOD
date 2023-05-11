using System;
using Shapes;

namespace TaskX.Shapes
{

    interface IExporter
    {
        void Export(IShape shape);
    }

    class SvgExporter : IExporter
    {
        public void Export(IShape shape)
        {
            Console.WriteLine($"Exporting {nameof(shape)}: {shape.ToString()}");
        }
    }

 

    class JpegExporter : IExporter
    {
        IShape _shape;
        public int _compressionLevel = 0;
        public Random _rng;

        public void Export(IShape shape)
        {
            _shape = (IShape)shape.Clone();
            Compress();
            Console.WriteLine($"Exporting {nameof(_shape)}: {_shape.ToString()}");
        }
        private void Compress()
        {
            _rng = new Random();
            _shape.Scale(_rng.NextDouble() + 0.1 * _compressionLevel);
            _shape.Translate(_rng.Next(-_compressionLevel, _compressionLevel), _rng.Next(-_compressionLevel, _compressionLevel));
        }

        public JpegExporter(int complressionLevel)
        {
            _compressionLevel = complressionLevel;
        }
    }



}
