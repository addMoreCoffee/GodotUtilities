namespace GodotUtilities;

/// <summary>
/// Provides extension methods for vectors.
/// </summary>
public static class VectorExtension
{
    private const float ALPHA_2D = .9604339f;
    private const float BETA_2D = .3978247f;

	private const float ALPHA_3D = 0.9375f;
	private const float BETA_3D = 0.375f;

	/// <summary>
	/// Creates a new <see cref="Vector2"/> with the provided <paramref name="value"/> for all axes.
	/// </summary>
	public static Vector2 Splat2D(float value) =>
		new Vector2(value, value);

	/// <summary>
	/// Creates a new <see cref="Vector3"/> with the provided <paramref name="value"/> for all axes.
	/// </summary>
	public static Vector3 Splat3D(float value) =>
		new Vector3(value, value, value);

	/// <summary>
	/// Gets the approximate length of the provided <paramref name="vector"/>.
	/// </summary>
    public static float ApproximateLength(this Vector2 vector)
    {
        var absVec = vector.Abs();

        var min = Mathf.Min(absVec.X, absVec.Y);
        var max = Mathf.Max(absVec.X, absVec.Y);

        return (ALPHA_2D * max) + (BETA_2D * min);
    }

    /// <summary>
    /// Gets the approximate length of the provided <paramref name="vector"/>.
    /// </summary>
    public static float ApproximateLength(this Vector3 vector)
    {
		var absVec = vector.Abs();

        float max = Mathf.Max(absVec.X, Mathf.Max(absVec.Y, absVec.Z));
        float min = Mathf.Min(absVec.X, Mathf.Min(absVec.Y, absVec.Z));
        float mid = absVec.X + absVec.Y + absVec.Z - max - min;

        return (ALPHA_3D * max) + (BETA_3D * mid);
    }

	/// <summary>
	/// Gets a new <see cref="Vector2"/> with the provided <paramref name="degrees"/>.
	/// </summary>
    public static Vector2 RotatedDegrees(this Vector2 vector, float degrees) =>
        vector.Rotated(Mathf.DegToRad(degrees));

	/// <summary>
	/// Gets a new <see cref="Vector3"/> with the provided <paramref name="degrees"/>.
	/// </summary>
    public static Vector3 RotatedDegrees(this Vector3 vector, float degrees) =>
        vector.Rotated(Mathf.DegToRad(degrees));

	/// <summary>
	/// Checks the squared distance between the provided <see cref="Vector2"/>s.
	/// </summary>
	/// <remarks>
	/// The provided <paramref name="distance"/> will be squared for the distance comparison.
	/// </remarks>
    public static bool IsWithinDistanceSquared(this Vector2 fromVector, Vector2 toVector, float distance) =>
        fromVector.DistanceSquaredTo(toVector) <= distance * distance;

	/// <summary>
	/// Checks the squared distance between the provided <see cref="Vector2"/>s.
	/// </summary>
	/// <remarks>
	/// The provided <paramref name="distance"/> will be squared for the distance comparison.
	/// </remarks>
    public static bool IsWithinDistanceSquared(this Vector3 fromVector, Vector3 toVector, float distance) =>
        fromVector.DistanceSquaredTo(toVector) <= distance * distance;

	/// <summary>
	/// Creates a new <see cref="Vector2"/> with the provided <paramref name="x"/> value.
	/// </summary>
	public static Vector2 WithX(this Vector2 vector, float x) =>
		new Vector2(x, vector.Y);

	/// <summary>
	/// Creates a new <see cref="Vector3"/> with the provided <paramref name="x"/> value.
	/// </summary>
	public static Vector3 WithX(this Vector3 vector, float x) =>
		new Vector3(x, vector.Y, vector.Z);

	/// <summary>
	/// Creates a new <see cref="Vector2"/> with the provided <paramref name="y"/> value.
	/// </summary>
	public static Vector2 WithY(this Vector2 vector, float y) =>
		new Vector2(vector.X, y);

	/// <summary>
	/// Creates a new <see cref="Vector3"/> with the provided <paramref name="y"/> value.
	/// </summary>
	public static Vector3 WithY(this Vector3 vector, float y) =>
		new Vector3(vector.X, y, vector.Z);

	/// <summary>
	/// Creates a new <see cref="Vector3"/> with the provided <paramref name="z"/> value.
	/// </summary>
	public static Vector3 WithZ(this Vector3 vector, float z) =>
		new Vector3(vector.X, vector.Y, z);

	/// <summary>
	/// Creates a new <see cref="Vector3"/> that extends the <paramref name="vector"/> with <paramref name="z"/>
	/// </summary>
	public static Vector3 Extend(this Vector2 vector, float z) =>
		new Vector3(vector.X, vector.Y, z);

	/// <summary>
	/// Creates a new <see cref="Vector2"/> that removes the <see cref="Vector3.Z"/>.
	/// </summary>
	public static Vector2 Truncate(this Vector3 vector) =>
		new Vector2(vector.X, vector.Y);
}
