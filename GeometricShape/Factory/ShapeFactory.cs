using GeometricShape.Model.CreatingInfo;
using GeometricShape.Model.Figures;

namespace GeometricShape.Factory;

/// <summary>
/// Фабрика геометрических фигур.
/// </summary>
public class ShapeFactory: IShapeFactory
{
    /// <inheritdoc />
    public IGeometricShape Create(ShapeInitBase shapeInit)
    {
        if (shapeInit == null)
            throw new ArgumentNullException(nameof(shapeInit));

        if (shapeInit is CircleInit initCircle)
        {
            if (initCircle.Radius <= 0) throw new ArgumentOutOfRangeException(nameof(initCircle.Radius));
            return new Circle(initCircle.Radius);
        }

        if (shapeInit is TriangleInit initTriangle)
        {
            if (initTriangle.EdgeA <= 0) throw new ArgumentOutOfRangeException(nameof(initTriangle.EdgeA));
            if (initTriangle.EdgeB <= 0) throw new ArgumentOutOfRangeException(nameof(initTriangle.EdgeB));
            if (initTriangle.EdgeC <= 0) throw new ArgumentOutOfRangeException(nameof(initTriangle.EdgeC));

            return new Triangle(initTriangle.EdgeA, initTriangle.EdgeB, initTriangle.EdgeA);
        }

        throw new ArgumentOutOfRangeException(nameof(shapeInit));
    }
}