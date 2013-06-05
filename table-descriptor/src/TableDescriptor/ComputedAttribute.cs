using System;

namespace TableDescriptor
{
    /// <summary>
    /// The database generates this column, so don't try to insert it. 
    /// <remarks>
    /// Use it for database columns with a system-generated default (newid(), newsequentialid(), getdate(), etc.) and for columns designated read-only.
    /// </remarks>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ComputedAttribute : Attribute
    {

    }

    /// <summary>
    /// This is the database table's identity column.
    /// <remarks>
    /// Use this to force the identity column in situations where you want to use <see cref="SimpleDescriptor"/> but don't like
    /// the default behavior when multiple key fields are found.
    /// </remarks>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IdentityAttribute : Attribute
    {

    }
}