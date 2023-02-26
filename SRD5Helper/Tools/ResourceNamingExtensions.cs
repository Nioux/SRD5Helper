namespace SRD5Helper.Tools;

public static class ResourceNamingExtensions
{
    public static string ToResourceID(this object enumID)
    {
        return enumID?.ToString().ToLower().Replace("_", "-");
    }
    public static string ToResourceName(this object enumID)
    {
        return ToResourceID(enumID) + "-name";
    }
    public static string ToResourceFName(this object enumID)
    {
        return ToResourceID(enumID) + "-fname";
    }
    public static string ToResourceMName(this object enumID)
    {
        return ToResourceID(enumID) + "-mname";
    }
    public static string ToResourceNName(this object enumID)
    {
        return ToResourceID(enumID) + "-nname";
    }
    public static string ToResourceIName(this object enumID)
    {
        return ToResourceID(enumID) + "-iname";
    }
    public static string ToResourceBrief(this object enumID)
    {
        return ToResourceID(enumID) + "-brief";
    }
    public static string ToResourceDescription(this object enumID)
    {
        return ToResourceID(enumID) + "-description";
    }
    public static string ToResourcePicture(this object enumID)
    {
        return ToResourceID(enumID) + "-picture";
    }

    public static string GetName(this System.Resources.ResourceManager manager, object enumID)
    {
        return enumID != null ? manager.GetString(enumID.ToResourceName()) ?? enumID.ToString().ToLower() : null;
    }
    public static string GetFName(this System.Resources.ResourceManager manager, object enumID)
    {
        return enumID != null ? manager.GetString(enumID?.ToResourceFName()) : null;
    }
    public static string GetMName(this System.Resources.ResourceManager manager, object enumID)
    {
        return enumID != null ? manager.GetString(enumID?.ToResourceMName()) : null;
    }
    public static string GetNName(this System.Resources.ResourceManager manager, object enumID)
    {
        return enumID != null ? manager.GetString(enumID?.ToResourceNName()) : null;
    }
    public static string GetIName(this System.Resources.ResourceManager manager, object enumID)
    {
        return enumID != null ? manager.GetString(enumID?.ToResourceIName()) : null;
    }
    public static string GetBrief(this System.Resources.ResourceManager manager, object enumID)
    {
        return enumID != null ? manager.GetString(enumID?.ToResourceBrief()) : null;
    }
    public static string GetDescription(this System.Resources.ResourceManager manager, object enumID)
    {
        return enumID != null ? manager.GetString(enumID?.ToResourceDescription()) : null;
    }
    public static string GetPicture(this System.Resources.ResourceManager manager, object enumID)
    {
        return enumID != null ? manager.GetString(enumID?.ToResourcePicture()) : null;
    }
}

