namespace GeometricShape.Model.CreatingInfo;

/// <summary>
/// Класс со сведениями для создания треугольника.
/// </summary>
public class TriangleInit: ShapeInitBase
{
    /// <summary>
    /// Получает или задает длину первого ребра треугольника.
    /// </summary>
    public double EdgeA { get; set; }

    /// <summary>
    /// Получает или задает длину второго ребра треугольника.
    /// </summary>
    public double EdgeB { get; set; }

    /// <summary>
    /// Получает или задает длину третьего ребра треугольника.
    /// </summary>
    public double EdgeC { get; set; }
}