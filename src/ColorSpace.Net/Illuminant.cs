namespace ColorSpace.Net;

/// <summary>
/// Represents an illuminant with X, Y, Z values and descriptive information.
/// </summary>
public class Illuminant
{
    /// <summary>
    /// Gets the X value of the illuminant.
    /// </summary>
    public double X { get; }

    /// <summary>
    /// Gets the Y value of the illuminant.
    /// </summary>
    public double Y { get; }

    /// <summary>
    /// Gets the Z value of the illuminant.
    /// </summary>
    public double Z { get; }

    /// <summary>
    /// Gets the name of the illuminant.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the description of the illuminant.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Illuminant"/> class with specified X, Y, Z values, name, and description.
    /// </summary>
    /// <param name="x">The X value of the illuminant.</param>
    /// <param name="y">The Y value of the illuminant.</param>
    /// <param name="z">The Z value of the illuminant.</param>
    /// <param name="name">The name of the illuminant.</param>
    /// <param name="description">The description of the illuminant.</param>
    public Illuminant(double x, double y, double z, string name, string description)
    {
        X = x;
        Y = y;
        Z = z;
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is null || GetType() != obj.GetType()) return false;

        Illuminant other = (Illuminant)obj;
        return X == other.X && Y == other.Y && Z == other.Z &&
               Name == other.Name && Description == other.Description;
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        // Initialize a large prime number
        int hash = 17;

        // Multiply by a prime number (e.g., 31) and add field hashes
        hash = hash * 31 + X.GetHashCode();
        hash = hash * 31 + Y.GetHashCode();
        hash = hash * 31 + Z.GetHashCode();
        hash = hash * 31 + (Name?.GetHashCode() ?? 0);        // Handle null Name
        hash = hash * 31 + (Description?.GetHashCode() ?? 0); // Handle null Description

        return hash;
    }

}
