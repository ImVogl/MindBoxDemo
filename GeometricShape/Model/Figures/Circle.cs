namespace GeometricShape.Model.Figures;

/// <summary>
/// Класс, содержащий сведения окружности.
/// </summary>
internal class Circle : IGeometricShape
{
    /// <summary>
    /// Радиус окружности.
    /// </summary>
    private readonly double _radius;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Circle"/>.
    /// </summary>
    /// <param name="radius">Радиус окружности.</param>
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentOutOfRangeException(nameof(radius));

        _radius = radius;
    }

    /// <inheritdoc />
    public double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}