namespace GeometricShape.Model.Figures;

/// <summary>
/// Интерфейс треугольника.
/// </summary>
public interface ITriangle : IGeometricShape
{
    /// <summary>
    /// Получает значение, показывающее, что треугольник является прямоугольным.
    /// </summary>
    bool IsRight { get; }
}