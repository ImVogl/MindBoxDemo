namespace GeometricShape.Model.Figures;

/// <summary>
/// Класс, описывающий треугольник.
/// </summary>
internal class Triangle : ITriangle
{
    /// <summary>
    /// Длина первого ребра треугольника.
    /// </summary>
    private readonly double _edgeA;

    /// <summary>
    /// Длина второго ребра треугольника.
    /// </summary>
    private readonly double _edgeB;

    /// <summary>
    /// Длина третьего ребра треугольника.
    /// </summary>
    private readonly double _edgeC;
    
    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Triangle"/>.
    /// </summary>
    /// <param name="edgeA">Длина первого ребра треугольника.</param>
    /// <param name="edgeB">Длина второго ребра треугольника.</param>
    /// <param name="edgeC">Длина третьего ребра треугольника.</param>
    public Triangle(double edgeA, double edgeB, double edgeC)
    {
        _edgeA = edgeA;
        _edgeB = edgeB;
        _edgeC = edgeC;
    }

    /// <inheritdoc />
    public bool IsRight => CheckIsRight();

    /// <inheritdoc />
    public double GetArea()
    {
        var halfPerimeter = _edgeA + _edgeB + _edgeC;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - _edgeA) * (halfPerimeter - _edgeB) * (halfPerimeter - _edgeB));   // Формула Герона
    }

    /// <summary>
    /// Проверяет является ли треугольник прямоугольным.
    /// </summary>
    /// <returns>Значение, показывающее, что треугольник является прямоугольным.</returns>
    private bool CheckIsRight()
    {
        // Точность. При значениях меньше данной величины, считаем, что величина равна нулю.
        const double precision = 1E-300;

        // Сторона A является гипотенузой.
        if (_edgeA > _edgeB && _edgeA > _edgeC)
            return Math.Abs(Math.Pow(_edgeB, 2) + Math.Pow(_edgeC, 2) - Math.Pow(_edgeA, 2)) < precision;

        // Сторона B является гипотенузой.
        if (_edgeB > _edgeA && _edgeB > _edgeC)
            return Math.Abs(Math.Pow(_edgeA, 2) + Math.Pow(_edgeC, 2) - Math.Pow(_edgeB, 2)) < precision;
        
        // Сторона C является гипотенузой.
        return Math.Abs(Math.Pow(_edgeA, 2) + Math.Pow(_edgeB, 2) - Math.Pow(_edgeC, 2)) < precision;
    }
}