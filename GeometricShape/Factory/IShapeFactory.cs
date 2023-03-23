using GeometricShape.Model.CreatingInfo;
using GeometricShape.Model.Figures;

namespace GeometricShape.Factory;

/// <summary>
/// Интерфейс фабрики геометрических фигур
/// </summary>
public interface IShapeFactory
{
    /// <summary>
    /// Создание экземпляра фигуры.
    /// </summary>
    /// <param name="shapeInit"><see cref="ShapeInitBase"/>.</param>
    /// <returns>Экземпляр класса, реализующий интерфейс <see cref="IGeometricShape"/>.</returns>
    IGeometricShape Create(ShapeInitBase shapeInit);
}