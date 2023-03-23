namespace GeometricShape
{
    /// <summary>
    /// Интерфейс геометрической фигуры.
    /// </summary>
    public interface IGeometricShape
    {
        /// <summary>
        /// Вычисление площади фигуры.
        /// </summary>
        /// <returns>Площадь фигуры.</returns>
        double GetArea();
    }
}