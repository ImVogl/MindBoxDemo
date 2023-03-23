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
            return new Circle(initCircle.Radius);

        if (shapeInit is TriangleInit initTriangle)
            return new Triangle(initTriangle.EdgeA, initTriangle.EdgeB, initTriangle.EdgeA);

        throw new ArgumentOutOfRangeException(nameof(shapeInit));
    }
}