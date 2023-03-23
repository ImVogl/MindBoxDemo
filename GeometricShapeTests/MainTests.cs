using GeometricShape.Factory;

namespace GeometricShapeTests
{
    using GeometricShape.Model.CreatingInfo;
    using GeometricShape.Model.Figures;
    using NUnit.Framework;

    public class MainTests
    {
        private static readonly IShapeFactory Factory = new ShapeFactory();

        [Test]
        [Description("Создание окружности и вычисление площади.")]
        public void CreateCircleTest()
        {
            const double radius = 25D;
            const double expectedArea = Math.PI * radius * radius;

            var init = new CircleInit { Radius = radius };
            var circle =  Factory.Create(init);
            Assert.That(Math.Abs(circle.GetArea() - expectedArea), Is.LessThan(double.Epsilon));
        }

        [Test]
        [Description("Передача некорректных данных при создании окружности.")]
        public void BadCircleInitTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>Factory.Create(new CircleInit { Radius = 0D }));
            Assert.Throws<ArgumentOutOfRangeException>(() =>Factory.Create(new CircleInit { Radius = -100D }));
        }

        [Test]
        [Description("Передача неизвестного типа фигуры конструктору фигур.")]
        public void BadInitTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Factory.Create(new BadInit()));
        }

        [Test]
        [Description("Передача некорректных данных при создании треугольника.")]
        public void BadTriangleInitTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Factory.Create(new TriangleInit { EdgeA = 0D, EdgeB = 100D, EdgeC = 100D }));
            Assert.Throws<ArgumentOutOfRangeException>(() => Factory.Create(new TriangleInit { EdgeA = -100D, EdgeB = 100D, EdgeC = 100D }));

            Assert.Throws<ArgumentOutOfRangeException>(() => Factory.Create(new TriangleInit { EdgeA = 100D, EdgeB = 0D, EdgeC = 100D }));
            Assert.Throws<ArgumentOutOfRangeException>(() => Factory.Create(new TriangleInit { EdgeA = 100D, EdgeB = -100D, EdgeC = 100D }));

            Assert.Throws<ArgumentOutOfRangeException>(() => Factory.Create(new TriangleInit { EdgeA = 100D, EdgeB = 100D, EdgeC = 0D }));
            Assert.Throws<ArgumentOutOfRangeException>(() => Factory.Create(new TriangleInit { EdgeA = 100D, EdgeB = 100D, EdgeC = -100D }));
        }

        [Test]
        [Description("Создание треугольника и вычисление площади.")]
        public void CreateTriangleTest()
        {
            const double edge = 10D;
            var expectedArea = 0.5 * edge * edge * Math.Sin(Math.PI / 3);   // Половина основания умноженная на высоту.

            var init = new TriangleInit { EdgeA = edge, EdgeB = edge, EdgeC = edge };
            var triangle = Factory.Create(init);
            var convertedTriangle = triangle as ITriangle;
            Assert.That(convertedTriangle, Is.Not.Null);

#pragma warning disable CS8602
            Assert.That(Math.Abs(convertedTriangle.GetArea() - expectedArea), Is.LessThan(double.Epsilon));
            Assert.That(convertedTriangle.IsRight, Is.False);
#pragma warning restore CS8602
        }

        [Test]
        [Description("Создание прямоугольного треугольника и вычисление площади.")]
        public void CreateRightTriangleTest()
        {
            const double expectedArea = 6D;
            var init = new TriangleInit { EdgeA = 3D, EdgeB = 4D, EdgeC = 5D };
            var triangle = Factory.Create(init);
            var convertedTriangle = triangle as ITriangle;
            Assert.That(convertedTriangle, Is.Not.Null);

#pragma warning disable CS8602
            Assert.That(Math.Abs(convertedTriangle.GetArea() - expectedArea), Is.LessThan(double.Epsilon));
            Assert.That(convertedTriangle.IsRight, Is.True);
#pragma warning restore CS8602
        }
    }

    internal class BadInit : ShapeInitBase
    {
    }
}