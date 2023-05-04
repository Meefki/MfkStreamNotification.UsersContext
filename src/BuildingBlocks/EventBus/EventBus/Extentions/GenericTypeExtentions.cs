namespace EventBus.Extentions;

public static class GenericTypeExtentions
{
    public static string GetGenericTypeName(this Type type)
    {
        string typeName = string.Empty;

        if (type.IsGenericType)
        {
            var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());
            typeName = $"{type.Name.Remove(type.Name.IndexOf("`"))}<{genericTypes}>";
        }
        else
        {
            typeName = type.Name;
        }

        return typeName;
    }

    public static string GetGenericTypeName(this object obj)
    {
        return obj.GetType().GetGenericTypeName();
    }
}
